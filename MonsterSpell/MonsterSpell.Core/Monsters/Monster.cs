using MonsterSpell.Core.Characters;

namespace MonsterSpell.Core.Monsters
{
    public abstract class Monster : Character
    {
        protected Monster(string id, CharacterType type, int healthPoints,
            int manaPoints, int attackPoints, int defensePoints, string name)
            : base(id, type, healthPoints, manaPoints, attackPoints, defensePoints, name)
        {
        }
    }
}