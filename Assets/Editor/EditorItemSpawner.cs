using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEditor;
using UnityEngine;

public class EditorItemSpawner : EditorWindow
{
	private ItemBase item = null;
	private int quantity = 1;
	private Vector3 gameObjectposition = Vector3.zero;
	private float despawnTime = 0;
	private float colliderRadius = defaultColliderRadius;
	const float defaultColliderRadius = 0.5f;
	private bool automaticallyRespawn = true;

	[MenuItem("Custom/Items/World Object Spawner")]
	public static void DisplayWindow()
	{
		GetWindow(typeof(EditorItemSpawner));
	}

	private void OnGUI()
	{
		GUILayout.Label("Spawn new object", EditorStyles.boldLabel);
		item = EditorGUILayout.ObjectField("Item", item, typeof(ItemBase), true) as ItemBase;
		quantity = EditorGUILayout.IntField("Quantity", quantity);
		despawnTime = EditorGUILayout.FloatField("DespawnTime", despawnTime);
		gameObjectposition = EditorGUILayout.Vector3Field("Position", gameObjectposition);
		automaticallyRespawn = EditorGUILayout.Toggle("Automatically Respawn?", automaticallyRespawn);
		colliderRadius = EditorGUILayout.FloatField("ColliderRadius", colliderRadius);

		item = EditorGUILayout.ObjectField("Item", item, typeof(ItemBase), true) as ItemBase;

		if (GUILayout.Button("Spawn Item"))
		{
			SpawnObject();
		}
	}

	private void SpawnObject()
	{
		if (item == null)
		{
			Debug.LogWarning("No item chosen");
			return;
		}

		if (quantity <= 0)
		{
			Debug.LogWarning("Quantity cannot be less than 0,defaulting to 1");
			quantity = 1;
		}

		if (despawnTime < 0)
		{
			despawnTime = 0;
			Debug.LogWarning("Despawn time cannot be less than 0, defaulting to no despawn");
		}

		if (colliderRadius < 0.01f)
		{
			colliderRadius = defaultColliderRadius;
			Debug.LogWarning("Collision radius cannot be 0, defaulting to " + defaultColliderRadius);
		}


	GameObject newObj = ItemSpawner.SpawnObject(item, quantity, despawnTime, gameObjectposition, colliderRadius,Selection.transforms.Length!=0? Selection.transforms[0]:null);
	//Selection.activeTransform = newObj.transform;
	//SceneView.lastActiveSceneView.FrameSelected();

	}
}