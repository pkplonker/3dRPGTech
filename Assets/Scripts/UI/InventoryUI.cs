using System;
using System.Collections.Generic;
using Player;
using SO;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class InventoryUI : MonoBehaviour
	{
		[SerializeField] private GameObject inventorySlotPrefab;
		[SerializeField] private Transform slotContainer;
		private List<InventorySlot> inventorySlots = new();

		private Inventory inventory;


		private void Start()
		{
			inventory= PlayerManager.Instance.GetComponent<Inventory>();
			if (inventory == null)
			{
				Debug.LogWarning("Missing inventory");
				return;
			}

			inventory.OnInventoryChanged += UpdateUI;

			SetUpSlots();
		}

		private void OnDisable()
		{
			if (inventory == null)
			{
				Debug.LogWarning("Missing inventory");
			}
			else
			{
				inventory.OnInventoryChanged -= UpdateUI;
			}
		}

	
		
		private void UpdateUI()
		{
			for (int i = 0; i < inventory.slots.Count; i++)
			{
				inventorySlots[i].UpdateUI(inventory.slots[i].item, inventory.slots[i].quantity);
			}
		}


		private void SetUpSlots()
		{
			for (int i = 0; i < inventory.GetCapacity(); i++)
			{
				inventorySlots.Add(Instantiate(inventorySlotPrefab, slotContainer).GetComponent<InventorySlot>().Init(inventory, i));
			}
		}
	}
}