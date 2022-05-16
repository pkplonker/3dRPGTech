using System;
using SO;
using UnityEngine;

namespace InventorySystem
{
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
			item = slot.item;
			quantity = slot.quantity;
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

		public bool AddQuantity(int i)
		{
			if (quantity + i > item.maxQuantity) return false;
			quantity += i;
			return true;
		}
	}
}