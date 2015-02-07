using MonsterSpell.Core.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterSpell.Core.Players
{
    public class Bot : Player
    {
        private Player opponent = null;

        public Bot(string id, IComputerCharacter character, Player opponent)
            : base(id, character)
        {
            this.opponent = opponent;
        }
    }
}
