using Player;
using Save;
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
	    [MenuItem("Stuart/Player/DealDamage")]
	    static  void DealDamage()
	    {
		    var stats = FindObjectOfType<PlayerStats>();
		    if (stats == null) return;

		    stats.TakeDamage(stats.currentHealth/10);
	    }
	    [MenuItem("Stuart/Player/Recover Run Energy")]
	    static  void RecoverRunEnergy()
	    {
		    var runManager = FindObjectOfType<RunManager>();
		    if (runManager == null) return;

		    runManager.RecoverRun(10000);
	    }
	    [MenuItem("Stuart/Player/Reset Position")]
	    static  void ResetPosition()
	    {
		    var locomotion = FindObjectOfType<Locomotion>();
		    if (locomotion == null) return;
		    locomotion.currentTarget = null;
		    locomotion.Move(Vector3.zero);
		    locomotion.transform.position = Vector3.zero;
	    }
	   
    }

