using MonsterSpell.Core.Characters.Mage.Spells;
using System.Runtime.Serialization;

namespace MonsterSpell.Core.Characters.Mage
{
    [DataContract(Name = "Mage")]
    public class Mage : Character
    {
        public const int DEFAULT_HP = 200;
        public const int DEFAULT_MP = 200;
        public const int DEFAULT_AP = 50;
        public const int DEFAULT_DP = 100;

        [DataMember]
        private readonly ISpell[] spells = null;

        public Mage(string name, string id)
            : base(id, CharacterType.Warrior, DEFAULT_HP,
            DEFAULT_MP, DEFAULT_AP, DEFAULT_DP, name)
        {
            this.spells = new ISpell[] { new BrutalAxe(),  };
        }

        public override ISpell[] Spells
        {
            get { return this.spells; }
        }
    }
}