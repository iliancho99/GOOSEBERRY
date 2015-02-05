using MonsterSpell.Core.Characters;
using MonsterSpell.Core.DBModels;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MonsterSpell.Core
{
    /// <summary>
    /// Base player class
    /// </summary>
    internal class Player : TcpClient
    {
        private StreamWriter streamWriter = null;
        private StreamReader streamReader = null;

        public Player(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User cannot be null!");
            this.Id = user.Id;
            this.NickName = user.Username;
        }

        public int Id { get; private set; }

        public string NickName { get; private set; }

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

        public async void ConnectToServer(IPAddress ip, int port)
        {
            await this.ConnectAsync(ip, port);
            this.streamReader = new StreamReader(this.GetStream());
            this.streamWriter = new StreamWriter(this.GetStream());

            //First we need to send some information about us
            
        }
    }
}
