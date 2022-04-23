using Player;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "New Equipment", menuName = "SO/Items/Equipment/Equipment")]
    public class Equipment : ItemBase
    {
        public EquipmentSlot equipmentSlot;
        public override bool Use(Inventory inventory)
        {
            Equip();
            return false;
        }

        private void Equip()
        {
            throw new System.NotImplementedException();
        }
    }

    public enum EquipmentSlot
    {
        Null,
        Head,
        Necklace,
        Ring,
        Chest,
        Legs,
        Feet,
        Gloves,
        LeftHand,
        RightHand,
        Cape,
        Back
        
    }
}
