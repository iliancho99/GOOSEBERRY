using MonsterSpell.Core.Characters;
using MonsterSpell.Core.DBModels;
using System.Net.Sockets;

namespace MonsterSpell.Core.Players
{
    public class UserPlayer : Player
    {
        public UserPlayer(string userId, string nickName)
            : base(userId, nickName) { }
    }
}
