using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
	public class SaveableGameObject : MonoBehaviour, ISerializationCallbackReceiver
	{
		public string id { get; private set; }

		private void OnEnable()
		{
			SavingSystem.instance.Subscribe(this);
		}

		private void OnDisable()
		{
			SavingSystem.instance.UnSubscribe(this);
		}

	
		public void OnBeforeSerialize()
		{
			GenerateUniqueID();
		}

		private void GenerateUniqueID()
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				id = Guid.NewGuid().ToString();
			}
		}

		public void OnAfterDeserialize()
		{
		}


		public Dictionary<string, object> SaveState()
		{
			var saveData = new Dictionary<string, object>();
			foreach (var component in GetComponents<ISaveLoad>())
			{
				saveData[component.GetType().ToString()] = component.SaveState();
			}
			return saveData;
		}

		public void LoadState(object data)
		{
			var saveData = (Dictionary<string, object>) data;
			foreach (var component in GetComponents<ISaveLoad>())
			{
				string typeName = component.GetType().ToString();
				if (saveData.TryGetValue(typeName, out object componentSaveData))
				{
					component.LoadState(componentSaveData);
				}
			}
		}
	}
}