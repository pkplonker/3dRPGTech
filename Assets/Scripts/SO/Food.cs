using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "New Food", menuName = "SO/Items/Consumables/Food")]
    public class Food : Consumable
    {
        public override bool Use()
        {
            throw new System.NotImplementedException();
        }
    }
}
