using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
namespace Save
{
	[Serializable]
	public class GameData
	{
		public bool playerIsDead= false;

		public float playerCurrentHealth;

		public float playerMaxHealth = 100;
		public SerializableVector playerPosition;

		public List<Inventory.InventorySlot> inventorySlots;

		public GameData()
		{
			playerCurrentHealth = playerMaxHealth;
		}
	}
}