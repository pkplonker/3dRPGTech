using System;
using System.Collections;
using System.Collections.Generic;
using DebugScripts;
using SO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EditorItemSpawner : EditorWindow
{
	private ItemBase item = null;
	private int quantity = 1;
	private Vector3 gameObjectPosition = Vector3.zero;
	private Vector3 uiRequestedPosition = Vector3.zero;
	private string spawnObjectName = "Editor - Item Spawner Target";

	private float despawnTime = 0;
	private float colliderRadius = defaultColliderRadius;
	const float defaultColliderRadius = 0.5f;
	private bool automaticallyRespawn = true;
	private Transform sceneViewTransform;
	[MenuItem("Custom/Items/World Object Spawner")]
	public static void DisplayWindow()
	{
		GetWindow(typeof(EditorItemSpawner));
		PositionMarker[] pm = FindObjectsOfType<PositionMarker>();
		if (pm.Length > 0)
		{
			for (int i = 0; i < pm.Length; i++)
			{
				DestroyImmediate(pm[i].gameObject);
			}
		}
	}

	void OnFocus()
	{
		SpawnMarker();
	}

	private void SpawnMarker()
	{
		if (sceneViewTransform == null)
		{
			sceneViewTransform = new GameObject().transform;
			sceneViewTransform.gameObject.name = spawnObjectName;
			PositionMarker positionMarker = sceneViewTransform.gameObject.AddComponent<PositionMarker>();
			positionMarker.Init(Color.blue, "Item Spawn Point");
		}
	}

	void OnDestroy() {
		if (sceneViewTransform != null)
		{
			DestroyImmediate(sceneViewTransform.gameObject);
		}
	}

	private void Update()
	{
		if (sceneViewTransform == null)
		{
			SpawnMarker();
		}
		if (sceneViewTransform.position != uiRequestedPosition && uiRequestedPosition != gameObjectPosition)
		{
			sceneViewTransform.position = uiRequestedPosition;
			gameObjectPosition = uiRequestedPosition;
		}

		if (sceneViewTransform.position != gameObjectPosition)
		{
			uiRequestedPosition = sceneViewTransform.position;
			gameObjectPosition = sceneViewTransform.position;
			//gameObjectPosition = gameObjectPosition;
		}
	}

	private void OnGUI()
	{
		if (sceneViewTransform != null)
		{
			if (GUILayout.Button("Select sceneview target"))
			{
				Selection.activeGameObject = sceneViewTransform.gameObject;
			}
		}
		GUILayout.Label("Spawn new object", EditorStyles.boldLabel);
		item = EditorGUILayout.ObjectField("Item", item, typeof(ItemBase), true) as ItemBase;
		quantity = EditorGUILayout.IntField("Quantity", quantity);
		despawnTime = EditorGUILayout.FloatField("DespawnTime", despawnTime);
		//gameObjectPosition = EditorGUILayout.Vector3Field("Position", gameObjectPosition);

		uiRequestedPosition = EditorGUILayout.Vector3Field("Position", uiRequestedPosition);
		automaticallyRespawn = EditorGUILayout.Toggle("Automatically Respawn?", automaticallyRespawn);
		colliderRadius = EditorGUILayout.FloatField("ColliderRadius", colliderRadius);
		
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


	GameObject newObj = ItemSpawner.SpawnObject(item, quantity, despawnTime, gameObjectPosition, colliderRadius,null);
	//Selection.activeTransform = newObj.transform;
	//SceneView.lastActiveSceneView.FrameSelected();

	}
}