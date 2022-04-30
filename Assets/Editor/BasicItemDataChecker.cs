using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class BasicItemDataChecker : EditorWindow
{
	[SerializeField] static List<ItemBase> failedItems = new ();
	
	[MenuItem("Custom/Items/ItemChecker")]
	public static void ItemChecker()
	{
		 GetWindow(typeof(BasicItemDataChecker));
	}

	private static string ItemPassesChecks(ItemBase item)
	{
		if (item == null) return "Error";
		if (item.itemID == null) return "Missing item ID";
		if (string.IsNullOrEmpty(item.itemName)) return "Item name missing";
		if (string.IsNullOrEmpty(item.description)) return "Item description missing";
		if (item.sprite == null) return "Item Sprite Missing";
		if (item.meshDetailsList == null) return "Item Mesh Missing";
		if (item.meshDetailsList.Count == 0) return "Item Material Missing";
		foreach (var mesh in item.meshDetailsList)
		{
			if (mesh == null) return "Item Mesh list incomplete";
		}

		return "PassedChecks";
	}

	private void CreateGUI()
	{
		failedItems.Clear();
		Check();
	}

	private void OnGUI()
	{
		if (GUILayout.Button("Check"))
		{
			failedItems.Clear();
			Check();
		}
		
		//ItemBase[] fItems = failedItems.ToArray();
		List<SerializedObject> objs = new();
		foreach (var i in failedItems)
		{
			objs.Add(new UnityEditor.SerializedObject(i)); 

		}
		GUILayout.Label("The following objects failed their basic checks:", EditorStyles.boldLabel);
		foreach (var i in objs)
		{
			EditorGUILayout.PropertyField(i.FindProperty("failedCheckWarning"), new GUIContent("Failure = "), true);
			EditorGUILayout.ObjectField(i.targetObject, typeof(Object), false);

		}
		if (GUILayout.Button("Close"))
		{
			this.Close();
		}
	}

	private void Check()
	{
		ItemBase[] items = Resources.FindObjectsOfTypeAll<ItemBase>();
		if (items == null) return;
		foreach (var item in items)
		{
			string response = ItemPassesChecks(item);
			if (response!="PassedChecks")
			{
				item.failedCheckWarning = response;
				failedItems.Add(item);
			}
		}

		
	}
}