using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Save
{
	[System.Serializable]
	public class GameData
	{
		public bool playerIsDead = false;

		public float playerCurrentHealth;

		public float playerMaxHealth = 100;
		//public Transform playerPosition;
		//public List<InventorySlot> inventorySlots;
	}
}