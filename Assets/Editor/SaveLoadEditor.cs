using Player;
using Save;
using UnityEditor;
using UnityEngine;


    public class SaveLoadEditor : MonoBehaviour
    {
	   
	    [MenuItem("Stuart/SaveState/Save")]
	    static  void SaveGame()
	    {
		    var savingSystem = FindObjectOfType<SavingSystem>();
		    if (savingSystem == null) return;

		    savingSystem.SaveGame();
	    }
	    [MenuItem("Stuart/SaveState/Load")]
	    static  void LoadGame()
	    {
		    var savingSystem = FindObjectOfType<SavingSystem>();
		    if (savingSystem == null) return;

		    savingSystem.LoadGame();
	    }
	    [MenuItem("Stuart/SaveState/New Game")]
	    static  void NewGame()
	    {
		    var savingSystem = FindObjectOfType<SavingSystem>();
		    if (savingSystem == null) return;

		    savingSystem.NewGame();
	    }
    }

