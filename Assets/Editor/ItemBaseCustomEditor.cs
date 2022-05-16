using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using SO.Items;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemBase),true)]
public class CheckItemBaseEditor : Editor
{
	GUIStyle myStyle = new GUIStyle();

	private void OnSceneGUI()
	{
		myStyle.fontSize = 15;
	}


	public override void OnInspectorGUI()
	{
		string s = BasicItemDataChecker.ItemPassesChecks((ItemBase) target) ;
		if (s== "PassedChecks")
		{
			DrawBasicChecksStatus(Color.green);
		}
		else
		{
			DrawBasicChecksStatus(Color.red,s);
		}
		base.OnInspectorGUI();
		
	}

	private static void DrawBasicChecksStatus(Color color,string messageToDisplay="")
	{
		int imageSize = 20;
		Color defaultcolor = GUI.contentColor;
		GUI.contentColor = color;
		EditorGUILayout.Separator();
		Rect rect = EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Basic checks status: ");
		EditorGUI.DrawRect(
			new Rect(EditorGUIUtility.currentViewWidth - (imageSize * 2) - imageSize, imageSize / 2, imageSize * 2,
				imageSize), color);
		EditorGUILayout.Separator();
		EditorGUILayout.EndHorizontal();
		if (!string.IsNullOrEmpty(messageToDisplay))
		{
			EditorGUILayout.LabelField(messageToDisplay);

		}
		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
		GUI.contentColor = defaultcolor;
	}
}
