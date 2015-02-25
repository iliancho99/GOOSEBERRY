
namespace MonsterSpell.Core.Characters
{
    public interface ISpell
    {
        string Name { get; }
        double AttackDamage { get; }
        double HealDamage { get; }
        int Level { get; set; }
    }
}
