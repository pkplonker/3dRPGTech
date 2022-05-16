using System;
using System.Collections.Generic;
using System.Linq;
using InventorySystem;
using Save;
using SO;
using SO.Items;
using UnityEngine;

namespace Player
{
	[Serializable]
	public class Inventory : MonoBehaviour, ISaveLoad
	{
		public List<InventorySlot> slots { get; private set; }
		[SerializeField] private int capacity;
		public event Action OnInventoryChanged;
		public int GetCapacity() => capacity;
		[SerializeField] private InventoryVariable inventoryVariable;

		private void Awake()
		{
			inventoryVariable.value = this;
		}

		private void Start()
		{
			FillSlotCapacity();
		}

		private void FillSlotCapacity()
		{
			slots ??= new List<InventorySlot>();
			if (slots.Capacity > capacity)
			{
				slots.Capacity = capacity;
			}
			else if (slots.Capacity < capacity)
			{
				slots.Capacity = capacity;
			}

			while (slots.Count < slots.Capacity)
			{
				slots.Add(new InventorySlot(null, 0));
			}
		}

		public bool AddItemToSlot(ItemBase item, int quantity, int slotIndex)
		{
			if (slotIndex > slots.Count || slots[slotIndex] == null) return false;
			if (slots[slotIndex].item != null || item.maxQuantity < quantity) return false;
			slots[slotIndex].Add(item, quantity);
			OnInventoryChanged?.Invoke();

			return true;
		}

		public bool RemoveItemFromSlot(int slotIndex, int quantity)
		{
			if (slotIndex > slots.Count || slots[slotIndex] == null) return false;
			if (slots[slotIndex].item == null) return false;
			if (quantity > slots[slotIndex].quantity) return false;
			slots[slotIndex].Remove(quantity);
			OnInventoryChanged?.Invoke();

			return true;
		}

		public bool Add(ItemBase item, int quantity)
		{
			if (item == null)
			{
				Debug.LogError("Cannot add null item");
				return false;
			}

			foreach (var t in slots.Where(t =>
				t.item != null && t.item == item && t.quantity + quantity <= t.item.maxQuantity))
			{
				return AddToSlot(item, quantity, t);
			}

			foreach (var t in slots.Where(t => t.item == null))
			{
				return AddToSlot(item, quantity, t);
			}

			return false;
		}

		private bool AddToSlot(ItemBase item, int quantity, InventorySlot t)
		{
			t.Add(item, quantity);
			OnInventoryChanged?.Invoke();
			return true;
		}

		public bool Remove(ItemBase item, int quantity)
		{
			List<InventorySlot> slotsWithItem = new List<InventorySlot>();
			int totalFound = 0;
			int quantityRemaining = quantity;
			foreach (var t in slots.Where(t => t.item == item))
			{
				slotsWithItem.Add(t);
				totalFound += t.quantity;
			}

			if (totalFound < quantity) return false; //not enough found

			foreach (var t in slotsWithItem)
			{
				if (t.quantity >= quantityRemaining)
				{
					t.Remove(quantityRemaining);
					break;
				}

				quantityRemaining -= t.quantity;
				t.Remove(t.quantity);
			}

			OnInventoryChanged?.Invoke();
			return true;
		}

		public void SwapSlots(int sender, int receiver)
		{
			if (slots[sender].item == slots[receiver].item)
			{
				if (slots[receiver].AddQuantity(slots[sender].quantity))
				{
					RemoveItemFromSlot(sender, slots[sender].quantity);
				}
				
			}else if (slots[receiver].item == null)
			{
				AddItemToSlot(slots[sender].item, slots[sender].quantity, receiver);
				RemoveItemFromSlot(sender, slots[sender].quantity);
			}
			else
			{
				//cache sender
				ItemBase cachedItem = slots[sender].item;
				int cachedQuantity = slots[sender].quantity;
				//remove sender
				RemoveItemFromSlot(sender, cachedQuantity);
				//add to sender
				AddItemToSlot(slots[receiver].item, slots[receiver].quantity, sender);
				//add to receiver
				RemoveItemFromSlot(receiver, slots[receiver].quantity);

				AddItemToSlot(cachedItem, cachedQuantity, receiver);
			}

			OnInventoryChanged?.Invoke();

		}
		
		#region SaveLoad

		public void LoadState(object data)
		{
			List<SaveDataSlot> saveDataSlots = (List<SaveDataSlot>) data;
			slots = new List<InventorySlot>(capacity);
			for (int i = 0; i < saveDataSlots.Count; i++)
			{
				slots.Insert(i, new InventorySlot(ItemBase.GetItemFromID(saveDataSlots[i].itemId),
					saveDataSlots[i].quantity));
			}

			OnInventoryChanged?.Invoke();
		}

		public object SaveState()
		{
			List<SaveDataSlot> saveDataSlots = new List<SaveDataSlot>(capacity);
			for (int i = 0; i < slots.Count; i++)
			{
				saveDataSlots.Insert(i, new SaveDataSlot(slots[i]));
			}

			return saveDataSlots;
		}

		[Serializable]
		private class SaveDataSlot
		{
			public string itemId;
			public int quantity;

			public SaveDataSlot(InventorySlot slot)
			{
				if (slot.item != null)
				{
					itemId = slot.item.itemID;
					quantity = slot.quantity;
				}
			}
		}

		#endregion

		
	}
}