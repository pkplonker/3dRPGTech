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
			saveableObjects = new List<ISaveLoadInterface>();
		}
/*
		private static List<ISaveLoadInterface> GetSaveableGameObjects()
		{
			IEnumerable<ISaveLoadInterface> data = FindObjectsOfType<MonoBehaviour>().OfType<ISaveLoadInterface>();
			return new List<ISaveLoadInterface>(data);
		}
*/
		public void NewGame()
		{
			gameData = new GameData();
			Debug.LogWarning("Created new save file");
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
			Debug.LogWarning("All objects loaded successfully");

		}
#if !UnityEditor
		private void OnApplicationQuit()
		{
			SaveGame();
		}
#endif
		public void Subscribe(ISaveLoadInterface saveLoadInterface)
		{
			if (!saveableObjects.Contains(saveLoadInterface))
			{
				saveableObjects.Add(saveLoadInterface);
			}
		}
		public void UnSubscribe(ISaveLoadInterface saveLoadInterface)
		{
			if (saveableObjects.Contains(saveLoadInterface))
			{
				saveableObjects.Remove(saveLoadInterface);
			}
		}
	}
}