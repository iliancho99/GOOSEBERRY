using MonsterSpell.Core.Characters;
using System.Net.Sockets;

namespace MonsterSpell.Core
{
    public interface IPlayer
    {
        TcpClient Client { get; }
        string ID { get; set; }
        string NickName { get; set; }
        ICharacter[] Characters { get; }
        void AddCharacter(ICharacter character);
        void DeleteCharacter(ICharacter character);
    }
}
