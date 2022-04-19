using Player;
using UnityEngine;

namespace SO
{
    public abstract class ItemBase : ScriptableObject
    {
	    public string itemName;
	    [TextArea(5,10)] public string description;
	    public Sprite sprite;
	    public uint maxQuantity = uint.MaxValue;
	    public abstract bool Use(Inventory inventory);
    }
}
