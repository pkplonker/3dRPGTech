using System;
using System.Collections.Generic;
using Interactables;
using Save;
using SO;
using SO.Items;
using UnityEngine;

public class WorldItemSpawner : MonoBehaviour
{
	private ItemSpawner itemSpawner;
	private void Awake()
	{
		itemSpawner = GetComponent<ItemSpawner>();
	}
	private void Spawn(ItemBase item, int quantity = 1, float despawnTime = 0, Vector3 position = new Vector3())
	{
		itemSpawner.Spawn(item, quantity, despawnTime, position);
	}



	


}