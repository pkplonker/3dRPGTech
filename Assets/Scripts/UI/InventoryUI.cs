using System;
using System.Collections.Generic;
using Player;
using SO;
using UnityEngine;

namespace UI
{
	public class InventoryUI : MonoBehaviour
	{
		[SerializeField] private GameObject inventorySlotPrefab;
		[SerializeField] private Transform slotContainer;
		private List<InventorySlotUI> inventorySlots = new();

		private Inventory inventory;
		[SerializeField] InventoryVariable inventoryVariable;

		private void Awake()
		{
			inventory= inventoryVariable.value;

		}

		private void Start()
		{
			if (inventory == null)
			{
				Debug.LogWarning("Missing inventory");
				return;
			}
		}

		private void OnEnable()
		{
			SetUpSlots();
			inventory.OnInventoryChanged += UpdateUI;
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
				inventorySlots.Add(Instantiate(inventorySlotPrefab, slotContainer).GetComponentInChildren<InventorySlotUI>().Init(inventory, i));
			}
		}
	}
}