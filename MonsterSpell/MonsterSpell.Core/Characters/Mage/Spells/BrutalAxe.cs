using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MonsterSpell.Core.Characters.Mage.Spells
{
    [DataContract(Name = "BrutalAxe")]
    public class BrutalAxe : ISpell
    {
        private const string NAME = "Brutal Axe";
        private const double DEFAULT_ATTACK_DAMAGE = 50;
        private const double DEFAULT_HEAL_DAMAGE = 0;

        private int level = 1;

        public BrutalAxe() { }

        public string Name
        {
            get { return NAME; }
        }

        public double AttackDamage
        {
            get
            {
                double attackDamage = DEFAULT_ATTACK_DAMAGE + 20 * this.level;
                return attackDamage;
            }
        }

        public double HealDamage
        {
            get { return DEFAULT_HEAL_DAMAGE; }
        }

        public int Level
        {
            get { return this.level; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Level cannot be negative!");
                }
                this.level = value;
            }
        }
    }
}
