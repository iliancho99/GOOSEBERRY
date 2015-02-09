using MonsterSpell.Core.Characters;

namespace MonsterSpell.Core.Players
{
    public class Bot : Player
    {
        public Bot(string id, IComputerCharacter character)
            : base(id, character) { }
    }
}
