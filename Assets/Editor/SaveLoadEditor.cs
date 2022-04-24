using Player;
using Save;
using UnityEditor;
using UnityEngine;


public class SaveLoadEditor : MonoBehaviour
{
	[MenuItem("EasySave/Save")]
	static void SaveGame()
	{
		var savingSystem = FindObjectOfType<SavingSystem>();
		if (savingSystem == null) return;

		savingSystem.SaveGame();
	}

	[MenuItem("EasySave/Load")]
	static void LoadGame()
	{
		var savingSystem = FindObjectOfType<SavingSystem>();
		if (savingSystem == null) return;

		savingSystem.LoadGame();
	}

	[MenuItem("EasySave/ClearSaveData")]
	static void NewGame()
	{
		var savingSystem = FindObjectOfType<SavingSystem>();
		if (savingSystem == null) return;

		savingSystem.ClearSave();
	}

	[MenuItem("GameObject/EasySave/Create New Save System", false, 0)]
	static void NewSaveSystem()
	{
		var savingSystem = FindObjectOfType<SavingSystem>();
		if (savingSystem != null)
		{
			Debug.LogError("Saving system already in hierarchy. It is on GameObject named: " + savingSystem.gameObject.name);
			return;
		}

		GameObject obj = new GameObject();
		obj.AddComponent<SavingSystem>();
	}
}