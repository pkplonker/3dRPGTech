using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace SO
{
    public abstract class ItemBase : ScriptableObject, ISerializationCallbackReceiver
    {
	    public string itemName;
	    public string itemID = "";
	    [TextArea(5,10)] public string description;
	    public Sprite sprite;
	    public uint maxQuantity = uint.MaxValue;
	    public abstract bool Use(Inventory inventory);
	    static Dictionary<string, ItemBase> itemLookupCache;
	    public Mesh mesh;
	    public Material material;
	    public void OnBeforeSerialize()
	    {
		    if (string.IsNullOrWhiteSpace(itemID))
		    {
			    itemID = System.Guid.NewGuid().ToString();
		    }
	    }

	    public void OnAfterDeserialize()
	    {
	    }

	    public static ItemBase GetItemFromID(string id)
	    {
		    if (id == null) return null;
		    if (itemLookupCache == null)
		    {
			    itemLookupCache = new Dictionary<string, ItemBase>();
			    var itemList = Resources.LoadAll<ItemBase>("");
			    foreach (var item in itemList)
			    {
				    if (itemLookupCache.ContainsKey(item.itemID))
				    {
					    Debug.LogError(string.Format("Duplicate items: {0} and {1}", itemLookupCache[item.itemID], item));
					    continue;
				    }
				    itemLookupCache[item.itemID] = item;
			    }
		    }

		    return !itemLookupCache.ContainsKey(id) ? null : itemLookupCache[id];
	    }
    }
}
