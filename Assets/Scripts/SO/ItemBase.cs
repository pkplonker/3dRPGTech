using UnityEngine;

namespace SO
{
    public abstract class ItemBase : ScriptableObject
    {
	    public string itemName;

	    public abstract bool Use();
    }
}
