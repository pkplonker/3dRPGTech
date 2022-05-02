using System;
using Player;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class InventorySlotUI : MonoBehaviour
    {
	    [SerializeField] private TextMeshProUGUI textMesh;
	    [SerializeField] private Image iconImage;
	    private Button button;
	    private ItemBase item;
	    public Inventory inventory { get; private set; }
	    public int index { get; private set; }

	    private void Start()
	    {
		    button = GetComponent<Button>();
		    if(button==null) Debug.LogWarning("Button Missing");
		    button.onClick.AddListener(ButtonClick);
	    }

	    public InventorySlotUI Init(Inventory inventory, int index)
	    {
		    if (inventory == null)
		    {
			    Debug.LogWarning("Inventory not passed");
			    return null;
		    }

		    this.index = index;
		    this.inventory = inventory;
		    UpdateUI(null,-1);
		    return this;
	    }

	    public void UpdateUI( ItemBase item, int quantity)
	    {
		    if (item == null) ClearUI();
		    else AddItemToUI( item,quantity);
	    }

	    private void ClearUI()
	    {
		    iconImage.sprite = null;
		    iconImage.enabled = false;

		    textMesh.text = "";
	    }

	    private void AddItemToUI(ItemBase item, int quantity)
	    {
		    if (item == null)
		    {
			    Debug.LogWarning("Missing item");
			    return;
		    }
		    this.item = item;
		    if (item.sprite != null)
		    {
			    iconImage.sprite = item.sprite;
			    iconImage.enabled = true;
		    }
		    else Debug.LogWarning("Missing sprite on" + item.itemName +" : " + item.itemID);
		    if (quantity <= 0) Debug.LogWarning("Incorrect quantity for " + item.itemName +" : " + item.itemID);
		    else textMesh.text = quantity.ToString();
	    }
	    private void ButtonClick()
	    {
		    if (item == null) return;
		    if (item.Use(inventory))
		    {
			    inventory.RemoveItemFromSlot(index, 1);
		    }
	    }

    }
}
