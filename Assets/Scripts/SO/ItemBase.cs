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
    }
}
