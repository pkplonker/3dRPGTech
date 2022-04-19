using Player;
using SO;
using UnityEditor;
using UnityEngine;

namespace Interactables
{
    public class Pickup : Interactable
    {
        [SerializeField] private ItemBase item;
        [SerializeField] private int quantity=1;
        protected override void Interact(Inventory inventory)
        {
            base.Interact(inventory);
            if (inventory.Add(item, quantity))
            {
                Destroy(gameObject);
            }
        }
        
        
    }
}
