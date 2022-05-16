using Player;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "InventoryReference", menuName = "SO/GlobalFields/Inventory")]
    public class InventoryVariable : ScriptableObject
    {
        public Inventory value;
    }
}
