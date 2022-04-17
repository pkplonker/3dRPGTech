using Player;
using UnityEditor;
using UnityEngine;


    public class CharacterEditorMenu : MonoBehaviour
    {
	    [MenuItem("Stuart/Player/Revive")]
	    static  void Test()
	    {
		    var stats = FindObjectOfType<PlayerStats>();
		    if (stats == null) return;

		    stats.Revive();
	    }
    }

