using MonsterSpell.Core.Players;
using System;

namespace MonsterSpell.Core.Events
{
    public class OponentChangedEventArgs : EventArgs
    {
        public OponentChangedEventArgs(IPlayer opponent)
        {
            this.Opponent = opponent;
        }

        public IPlayer Opponent { get; private set; }
    }
}
