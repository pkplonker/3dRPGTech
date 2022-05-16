using System;
using Player;
using Save;
using SO;
using SO.Items;
using UnityEngine;

namespace Interactables
{

    public class Pickup : Interactable
    {
        [SerializeField] private ItemBase item;
        public ItemBase Item => item;
        public int quantity { get; private set; } = 1;
        protected override void Interact(Inventory inventory)
        {
            base.Interact(inventory);
            if (inventory.Add(item, quantity))
            {
                HandlePickedUp();
            }
        }

        private void HandlePickedUp()
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
