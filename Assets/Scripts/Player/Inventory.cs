using System;
using System.Collections.Generic;
using System.Linq;
using Save;
using SO;
using UnityEngine;

namespace Player
{
	[Serializable]
	public class Inventory : MonoBehaviour, ISaveLoad
	{
		private List<InventorySlot> slots;
		[SerializeField] private int capacity;

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

		public bool Add(ItemBase item, int quantity)
		{
			foreach (var t in slots.Where(t =>
				t.item != null && t.item == item && t.quantity + quantity <= t.item.maxQuantity))
			{
				t.Add(item, quantity);
				return true;
			}

			foreach (var t in slots.Where(t => t.item == null))
			{
				t.Add(item, quantity);
				return true;
			}

			return false;
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
				else
				{
					quantityRemaining -= t.quantity;
					t.Remove(t.quantity);
				}
			}

			return true;
		}

		#region SaveLoad

		#endregion

		[Serializable]
		public class InventorySlot
		{
			public ItemBase item { get; private set; }
			public int quantity { get; private set; }

			public InventorySlot(ItemBase item, int quantity)
			{
				this.item = item;
				this.quantity = quantity;
			}

			public InventorySlot(InventorySlot slot)
			{
				this.item = slot.item;
				this.quantity = slot.quantity;
			}


			public void Add(ItemBase item, int quantity)
			{
				if (item != this.item)
				{
					this.quantity = quantity;
				}
				else
				{
					this.quantity += quantity;
				}

				this.item = item;
			}

			public void Remove(int quantity)
			{
				quantity -= quantity;
				if (quantity < 0)
				{
					Debug.LogWarning("Some how managed to remove too many");
					item = null;
				}
				else if (quantity == 0)
				{
					item = null;
				}
			}
		}

		public void LoadState(object data)
		{
			List<SaveDataSlot> saveDataSlots = (List<SaveDataSlot>) data;
			slots = new List<InventorySlot>(capacity);
			for (int i = 0; i < slots.Count; i++)
			{
				slots[i] = new InventorySlot(ItemBase.GetItemFromID(saveDataSlots[i].itemId),
					saveDataSlots[i].quantity);
			}
		}

		public object SaveState()
		{
			List<SaveDataSlot> saveDataSlots = new List<SaveDataSlot>(capacity);
			for (int i = 0; i < slots.Count; i++)
			{
				saveDataSlots.Insert(i,new SaveDataSlot(slots[i])); 
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
	}
}