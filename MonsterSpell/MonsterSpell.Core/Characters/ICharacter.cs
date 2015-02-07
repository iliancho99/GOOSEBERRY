using MonsterSpell.Core.Items;
using MonsterSpell.Core.Items;

namespace MonsterSpell.Core.Characters
{
    public interface ICharacter
    {
        CharacterType Type { get; }
        void AddItem(IItem item);
        int AttackPoints { get; set; }
        int DefensePoints { get; set; }
        void EquipItem(IEquipable item);
        IEquipable[] EquippedItems { get; }
        int HealthPoints { get; set; }
        IItem[] Inventory { get; }
        int ManaPoints { get; set; }
        string Name { get; set; }
        Position Position { get; }
        void RemoveItem(IItem item);
        void UnequipItem(IEquipable item);
    }
}
