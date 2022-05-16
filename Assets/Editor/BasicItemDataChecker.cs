
using System.Collections.Generic;
using SO;
using SO.Items;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class BasicItemDataChecker : EditorWindow
{
	[SerializeField] static List<ItemBase> failedItems = new();
	private static int totalItems = 0;
	[MenuItem("Custom/Items/ItemChecker")]
	public static void ItemChecker()
	{
		GetWindow(typeof(BasicItemDataChecker));
	}

	public static string ItemPassesChecks(ItemBase item)
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
		EditorGUILayout.Separator();
		EditorGUILayout.Separator();

		if (GUILayout.Button("Recheck All Items"))
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

		EditorGUILayout.Separator();
		GUILayout.Label(failedItems.Count + " failed out of "+ totalItems+".", EditorStyles.boldLabel);

		if (failedItems.Count > 0)
		{
			GUILayout.Label("The following objects failed their basic checks:", EditorStyles.boldLabel);

		}
		else
		{
			GUILayout.Label("All checks passed", EditorStyles.boldLabel);

		}
		EditorGUILayout.Separator();

		foreach (var i in objs)
		{
			Rect rect = EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(i.FindProperty("failedCheckWarning").stringValue);
			EditorGUILayout.ObjectField(i.targetObject, typeof(Object), false);
			EditorGUILayout.Separator();
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

		}

		if (GUILayout.Button("Close"))
		{
			this.Close();
		}
	}

	private void Check()
	{
		Resources.LoadAll("SO", typeof(ScriptableObject));
		ItemBase[] items = Resources.FindObjectsOfTypeAll<ItemBase>();
		if (items == null) return;
		totalItems = items.Length;
		foreach (var item in items)
		{
			string response = ItemPassesChecks(item);
			if (response != "PassedChecks")
			{
				item.failedCheckWarning = response;
				failedItems.Add(item);
			}
		}

	}
	
	

}