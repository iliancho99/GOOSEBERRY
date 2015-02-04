using MonsterSpell.Core.Items;

namespace MonsterSpell.Core.Interfaces
{
    public interface IEquipable : IItem
    {
        void Equip();
        void Unequip();
    }
}
