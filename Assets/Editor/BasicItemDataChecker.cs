using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEditor;
using UnityEngine;

public class BasicItemDataChecker : EditorWindow
{
	[SerializeField] static List<ItemBase> failedItems = new ();
	
	[MenuItem("Custom/Items/ItemChecker")]
	public static void ItemChecker()
	{
		ItemBase[] items = Resources.FindObjectsOfTypeAll<ItemBase>();
		if (items == null) return;
		foreach (var item in items)
		{
			if (!ItemPassesChecks(item))
			{
				failedItems.Add(item);
			}
		}

		if (failedItems.Count >= 0) GetWindow(typeof(BasicItemDataChecker));
	}

	private static bool ItemPassesChecks(ItemBase item)
	{
		if (item == null) return true;
		if (item.itemID == null) return false;
		if (string.IsNullOrEmpty(item.itemName)) return false;
		if (string.IsNullOrEmpty(item.description)) return false;
		if (item.sprite == null) return false;
		if (item.meshDetailsList == null) return false;
		if (item.meshDetailsList.Count == 0) return false;
		foreach (var mesh in item.meshDetailsList)
		{
			if (mesh == null) return false;
		}

		return true;
	}

	private void OnGUI()
	{
		//ItemBase[] fItems = failedItems.ToArray();
		List<SerializedObject> objs = new();
		foreach (var i in failedItems)
		{
			objs.Add(new UnityEditor.SerializedObject(i)); 

		}
		GUILayout.Label("FailedObjects", EditorStyles.boldLabel);
		foreach (var i in objs)
		{
			EditorGUILayout.PropertyField(i.FindProperty("itemName"), new GUIContent("Failed items"), true);

		}
		if (GUILayout.Button("Close"))
		{
			this.Close();
		}
	}
}