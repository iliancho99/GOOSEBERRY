using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterSpell.Core.Items
{
    public interface IItem
    {
        string Name { get; }
        int HealthPoints { get; }
        int ManaPoints { get; }
        int AttackPoints { get; }
    }
}
