using MonsterSpell.Core.Items;

namespace MonsterSpell.Core.Characters
{
    public interface ICharacter
    {
        string Id { get; }
        void AddItem(IItem item);
        int AttackPoints { get; set; }
        int DefensePoints { get; set; }
        int HealthPoints { get; set; }
        IItem[] Inventory { get; }
        int ManaPoints { get; set; }
        string Name { get; set; }
        bool RemoveItem(IItem item);
        CharacterType Type { get; }
    }
}
