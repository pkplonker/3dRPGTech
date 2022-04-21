using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Save
{
	public class SavingSystem : MonoBehaviour
	{
		public static SavingSystem instance { get; private set; }
		private List<SaveableGameObject> saveableObjects;
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
			saveableObjects = new List<SaveableGameObject>();
		}

		public void NewGame()
		{
		}

		public void LoadGame()
		{
			LoadData(saveFileHandler.Load());
		}

		public void SaveGame()
		{
			var saveData = saveFileHandler.Load() ?? new Dictionary<string, object>();

			SaveData(saveData);
			saveFileHandler.Save(saveData);
		}

		private void LoadData(Dictionary<string, object> data)
		{
			foreach (var saveableObject in saveableObjects)
			{
				if (data.TryGetValue(saveableObject.id, out object saveData))
				{
					saveableObject.LoadState(saveData);
				}
			}
		}

		private void SaveData(Dictionary<string, object> data)
		{
			foreach (var saveableObject in saveableObjects)
			{
				data[saveableObject.id] = saveableObject.SaveState();
			}
		}


		public void Subscribe(SaveableGameObject saveLoadInterface)
		{
			if (!saveableObjects.Contains(saveLoadInterface))
			{
				saveableObjects.Add(saveLoadInterface);
			}
		}

		public void UnSubscribe(SaveableGameObject saveLoadInterface)
		{
			if (saveableObjects.Contains(saveLoadInterface))
			{
				saveableObjects.Remove(saveLoadInterface);
			}
		}
	}
}