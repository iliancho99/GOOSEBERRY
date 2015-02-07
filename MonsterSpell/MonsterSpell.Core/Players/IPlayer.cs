using MonsterSpell.Core.Characters;
using System.Net.Sockets;

namespace MonsterSpell.Core.Players
{
    public interface IPlayer
    {
        string UserId { get; }
        string NickName { get; }
        Character[] Characters { get; }
        void AddCharacter(Character character);
        void DeleteCharacter(Character character);
    }
}
