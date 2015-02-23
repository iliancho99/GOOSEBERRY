using MonsterSpell.Core.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using MonsterSpell.Core.Characters;


namespace MonsterSpell.Core.Monster
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