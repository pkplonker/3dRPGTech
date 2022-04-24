using System;
using Player;
using Save;
using SO;
using UnityEngine;

namespace Interactables
{

    public class Pickup : Interactable
    {
        public ItemBase item { get; private set; }
        public int quantity { get; private set; } = 1;
        protected override void Interact(Inventory inventory)
        {
            base.Interact(inventory);
            if (inventory.Add(item, quantity))
            {
                HandlePickedup();
            }
        }

        private void HandlePickedup()
        {
            Destroy(gameObject);
        }

        public void Init(ItemBase item, int quantity )
        {
            if (item == null || quantity <= 0) return;
            this.item = item;
            this.quantity = quantity;
        }



        
    }
}
