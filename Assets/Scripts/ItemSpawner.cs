using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using SO;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	[SerializeField] private ItemBase item;
	private List<GameObject> items = new List<GameObject>();

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			Spawn(item, 1,5);
		}
	}

	public void Spawn(ItemBase item, int quantity = 1,  float despawnTime = 0,Vector3 position = new Vector3())
	{
		if (item == null || item.material == null || item.mesh == null)
		{
			Debug.Log("Item information missing");
		}

		GameObject newGameObject = new GameObject();
		SetBasicDetails(item, newGameObject);
		items.Add(newGameObject);
		SetTransform(position, newGameObject,item);
		SetMesh(item, newGameObject);
		SetCollider(newGameObject);
		if (despawnTime > 0)
		{
			newGameObject.AddComponent<Despawner>().Init(this, despawnTime);
		}

		newGameObject.AddComponent<Pickup>().Init(item, quantity);
	}

	private static void SetCollider(GameObject newGameObject)
	{
		newGameObject.AddComponent<SphereCollider>();
	}

	private static void SetMesh(ItemBase item, GameObject newGameObject)
	{
		MeshFilter meshFilter = newGameObject.AddComponent<MeshFilter>();
		meshFilter.mesh = item.mesh;
		MeshRenderer meshRenderer = newGameObject.AddComponent<MeshRenderer>();
		meshRenderer.material = item.material;
	}

	private void SetTransform(Vector3 position, GameObject newGameObject, ItemBase item)
	{
		newGameObject.transform.position = position;
		newGameObject.transform.parent = transform;
		newGameObject.transform.localScale = item.scale;

	}

	private static void SetBasicDetails(ItemBase item, GameObject newGameObject)
	{
		newGameObject.name = item.itemName+ " : "+Time.time;
	}
}