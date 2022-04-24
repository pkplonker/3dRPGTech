using System;
using System.Collections.Generic;
using Interactables;
using Save;
using SO;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, ISaveLoad
{
	[SerializeField] private ItemBase item;
	private float colliderRadius = 0.5f;
	private List<GameObject> spawnedGameobjects = new List<GameObject>();

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			Spawn(item, 1, 5);
		}
	}

	public  void Spawn(ItemBase item, int quantity = 1, float despawnTime = 0, Vector3 position = new Vector3())
	{
		GameObject newGameObject= SpawnObject(item, quantity, despawnTime, position, colliderRadius,transform);
		if(newGameObject!=null)
		spawnedGameobjects.Add(newGameObject);
	}

	public static GameObject SpawnObject(ItemBase item, int quantity, float despawnTime, Vector3 position, float colliderRadius, Transform parent=null)
	{
		if (item == null || item.meshDetailsList == null || item.meshDetailsList.Count == 0)
		{
			Debug.Log("Item information missing");
			return null;
		}

	 GameObject	newGameObject = new GameObject();
		SetBasicDetails(item, newGameObject);
		SetMesh(item, newGameObject);
		SetTransform(position, newGameObject, item,parent);
		SetCollider(newGameObject, item, colliderRadius);
		Despawner despawner = null;
		if (despawnTime > 0)
		{
			despawner = newGameObject.AddComponent<Despawner>();
			despawner.Init( despawnTime);
		}

		newGameObject.AddComponent<Pickup>().Init(item, quantity);
		return null;
	}


	private static void SetCollider(GameObject newGameObject, ItemBase item, float colliderRadius)
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
			model.AddComponent<MeshFilter>().mesh = meshDetails.mesh;
			model.AddComponent<MeshRenderer>().material = meshDetails.material;
			model.transform.SetParent(newGameObject.transform);
			model.transform.localScale = Vector3.one;
			model.transform.rotation = Quaternion.identity;
		}
	}

	private static void SetTransform(Vector3 position, GameObject newGameObject, ItemBase item, Transform parent = null)
	{
		newGameObject.transform.position = position;
		newGameObject.transform.parent = parent;
		newGameObject.transform.localScale = new Vector3(item.scaleFactor, item.scaleFactor, item.scaleFactor);
		newGameObject.transform.rotation = item.spawnRotation;
	}

	private static void SetBasicDetails(ItemBase item, GameObject newGameObject)
	{
		newGameObject.name = item.itemName + " : " + Time.time;
	}


	public void LoadState(object data)
	{
		foreach (var obj in spawnedGameobjects)
		{
			if(obj!=null) Destroy(obj);
		}

		spawnedGameobjects = new List<GameObject>();
		List<SaveData> savedData = (List<SaveData>) data;
		if (data == null) return;
		foreach (var sData in savedData)
		{
			Spawn(ItemBase.GetItemFromID(sData.itemId),sData.quantity,sData.remainingTime,SerializableVector.GetVector(sData.position));
		}
	}

	public object SaveState()
	{
		List<SaveData> data = new List<SaveData>();
		foreach (var obj in spawnedGameobjects)
		{
			if(obj==null) continue;
			data.Add(new SaveData(obj));
		}
		return data;
	}

	[Serializable]
	private class SaveData
	{
		public string itemId;
		public float remainingTime;
		public int quantity;
		public SerializableVector position;
		public SaveData(GameObject obj)
		{
			if (obj.TryGetComponent( out Pickup pickup))
			{
				itemId = pickup.item.itemID;
				quantity = pickup.quantity;
			}
			if (obj.TryGetComponent( out Despawner despawner))
			{
				remainingTime = despawner.remainingTime;
			}

			position = new SerializableVector(obj.transform.position);
		}
	}
}