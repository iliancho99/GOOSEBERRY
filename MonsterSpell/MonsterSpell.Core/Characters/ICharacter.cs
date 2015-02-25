using MonsterSpell.Core.Items;

namespace MonsterSpell.Core.Characters
{
    public interface ICharacter
    {
        string Id { get; }
        void AddItem(IItem item);
        double AttackPoints { get; set; }
        double DefensePoints { get; set; }
        double HealthPoints { get; set; }
        IItem[] Inventory { get; }
        ISpell[] Spells { get; }
        double ManaPoints { get; set; }
        string Name { get; set; }
        bool RemoveItem(IItem item);
        CharacterType Type { get; }
    }
}
