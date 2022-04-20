using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Save
{
	public class SavingSystem : MonoBehaviour
	{
		public static SavingSystem instance { get; private set; }
		private List<ISaveLoadInterface> saveableObjects;
		private GameData gameData;
		[SerializeField] private string fileName;
		private SaveFileHandler saveFileHandler;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(this);
			}

			saveFileHandler = new SaveFileHandler(Application.persistentDataPath, fileName);
		}

		private void OnEnable()
		{
			saveableObjects = GetSaveableGameObjects();
		}

		private static List<ISaveLoadInterface> GetSaveableGameObjects()
		{
			IEnumerable<ISaveLoadInterface> data = FindObjectsOfType<MonoBehaviour>().OfType<ISaveLoadInterface>();
			return new List<ISaveLoadInterface>(data);
		}

		public void NewGame()
		{
			gameData = new GameData();
		}

		public void SaveGame()
		{
			foreach (var o in saveableObjects)
			{
				o.SaveState(gameData);
			}

			saveFileHandler.Save(gameData);
		}

		public void LoadGame()
		{
			gameData = saveFileHandler.Load();

			if (gameData == null)
			{
				Debug.LogWarning("No save state to load");
				NewGame();
			}

			foreach (var o in saveableObjects)
			{
				o.LoadState(gameData);
			}
		}
#if !UnityEditor
		private void OnApplicationQuit()
		{
			SaveGame();
		}
#endif
	}
}