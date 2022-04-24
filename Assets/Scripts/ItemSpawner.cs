
using System.Collections.Generic;
using Interactables;
using SO;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	[SerializeField] private ItemBase item;
	private List<GameObject> items = new List<GameObject>();
	private float colliderRadius = 0.5f;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			Spawn(item, 1, 5);
		}
	}

	public void Spawn(ItemBase item, int quantity = 1, float despawnTime = 0, Vector3 position = new Vector3())
	{
		if (item == null || item.meshDetailsList == null || item.meshDetailsList.Count==0)
		{
			Debug.Log("Item information missing");
			return;
		}
		
		GameObject newGameObject = new GameObject();
		SetBasicDetails(item, newGameObject);
		items.Add(newGameObject);
		SetMesh(item, newGameObject);
		SetTransform(position, newGameObject, item);
		SetCollider(newGameObject, item);
		if (despawnTime > 0)
		{
			newGameObject.AddComponent<Despawner>().Init(this, despawnTime);
		}

		newGameObject.AddComponent<Pickup>().Init(item, quantity);
	}

	private void SetCollider(GameObject newGameObject, ItemBase item)
	{
		newGameObject.AddComponent<SphereCollider>().radius = colliderRadius / item.scaleFactor;
	}

	private static void SetMesh(ItemBase item, GameObject newGameObject)
	{
		foreach (var meshDetails in item.meshDetailsList)
		{
			if (meshDetails.material == null || meshDetails.mesh == null)
			{
				Debug.LogWarning("Missing meshDetails for " + item.itemName);
				continue;
			}
			GameObject model = new GameObject();
			model.name = meshDetails.mesh.name;
			MeshFilter meshFilter = model.AddComponent<MeshFilter>();
			meshFilter.mesh = meshDetails.mesh;
			MeshRenderer meshRenderer = model.AddComponent<MeshRenderer>();
			meshRenderer.material = meshDetails.material;
			model.transform.SetParent(newGameObject.transform);
			model.transform.localScale = Vector3.one;
			model.transform.rotation= Quaternion.identity;
			
		}
		
	}

	private void SetTransform(Vector3 position, GameObject newGameObject, ItemBase item)
	{
		newGameObject.transform.position = position;
		newGameObject.transform.parent = transform;
		newGameObject.transform.localScale = new Vector3(item.scaleFactor, item.scaleFactor, item.scaleFactor);
		newGameObject.transform.rotation = item.spawnRotation;
	}

	private static void SetBasicDetails(ItemBase item, GameObject newGameObject)
	{
		newGameObject.name = item.itemName + " : " + Time.time;
	}
}