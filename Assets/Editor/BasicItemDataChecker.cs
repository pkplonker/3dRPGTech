using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SO;
using UnityEditor;
using UnityEngine;

public class BasicItemDataChecker : MonoBehaviour
{
    [MenuItem("Custom/Items/ItemChecker")]
    public static void ItemChecker()
    {
	    ItemBase[] items = Resources.FindObjectsOfTypeAll<ItemBase>();
	    Debug.Log("asd");
    }
    
    
}
