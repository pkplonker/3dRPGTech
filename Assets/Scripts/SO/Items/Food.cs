using Player;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "New Food", menuName = "SO/Items/Consumables/Food")]
    public class Food : Consumable
    {
        public override bool Use(Inventory inventory)
        {
            throw new System.NotImplementedException();
        }
    }
}
