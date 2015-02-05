using MonsterSpell.Core.Characters;
using System;
using System.Net.Sockets;

namespace MonsterSpell.Core
{
    /// <summary>
    /// Base player class
    /// </summary>
    public class Player : IPlayer
    {
        public TcpClient Client { get; private set; }

        public string ID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string NickName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ICharacter[] Characters
        {
            get { throw new NotImplementedException(); }
        }

        public void AddCharacter(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void DeleteCharacter(ICharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
