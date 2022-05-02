using System;
using Player;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class DropReceiver : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("received");
            SwapItems(eventData.pointerDrag.GetComponent<DragDrop>().inventorySlotUI);
        }

        private void SwapItems(InventorySlotUI slotUI)
        {
            Inventory inventory = slotUI.inventory;
            InventorySlotUI thisInventorySlot = GetComponentInChildren<InventorySlotUI>();
            inventory.SwapSlots(slotUI.index, thisInventorySlot.index);
        }
    }
}
