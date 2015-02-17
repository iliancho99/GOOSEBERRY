
namespace MonsterSpell.Core.Items
{
    public interface IItem
    {
        string Id { get; }
        int HealthPoints { get; }
        int ManaPoints { get; }
        int AttackPoints { get; }
        int DefensePoints { get; }
    }
}
