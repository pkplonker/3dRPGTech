using Player;
using UnityEditor;
using UnityEngine;


    public class CharacterEditorMenu : MonoBehaviour
    {
	    [MenuItem("Stuart/Player/Revive")]
	    static  void Revive()
	    {
		    var stats = FindObjectOfType<PlayerStats>();
		    if (stats == null) return;

		    stats.Revive();
	    }
	    [MenuItem("Stuart/Player/Recover Run Energy")]
	    static  void RecoverRunEnergy()
	    {
		    var runManager = FindObjectOfType<RunManager>();
		    if (runManager == null) return;

		    runManager.RecoverRun(10000);
	    }
    }

