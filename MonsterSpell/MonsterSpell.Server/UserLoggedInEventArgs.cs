using MonsterSpell.Core;
using System;

namespace MonsterSpell.Server
{
    internal class UserLoggedInEventArgs : EventArgs
    {
        public UserLoggedInEventArgs(IPlayer player)
        {
            this.Player = player;
        }

        public IPlayer Player { get; private set; }
    }
}
