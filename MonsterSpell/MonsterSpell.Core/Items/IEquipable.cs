using MonsterSpell.Core.Items;

namespace MonsterSpell.Core.Items
{
    public interface IEquipable : IItem
    {
        void Equip();
        void Unequip();
    }
}
