using MonsterSpell.Core.Characters;
using System.Net.Sockets;

namespace MonsterSpell.Core.Players
{
    public interface IPlayer
    {
        int Id { get; }
        string NickName { get; }
        ICharacter[] Characters { get; }
        void AddCharacter(ICharacter character);
        void DeleteCharacter(ICharacter character);
    }
}
