using System.Runtime.Serialization;

namespace MonsterSpell.Core.Characters
{
    [DataContract(Name = "Warrior")]
    public class Warrior : Character
    {
        public const int DEFAULT_HP = 200;
        public const int DEFAULT_MP = 200;
        public const int DEFAULT_AP = 50;
        public const int DEFAULT_DP = 100;

        public Warrior(string name, string id)
            : base(id, CharacterType.Warrior, DEFAULT_HP,
            DEFAULT_MP, DEFAULT_AP, DEFAULT_DP, name) { }
    }
}