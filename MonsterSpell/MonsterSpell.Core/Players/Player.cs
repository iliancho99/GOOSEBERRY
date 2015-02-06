using MonsterSpell.Core.Characters;
using MonsterSpell.Core.DBModels;
using MonsterSpell.Core.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MonsterSpell.Core.Players
{
    /// <summary>
    /// Base player class
    /// </summary>
    public class Player : TcpClient, IPlayer
    {
        private List<IPlayer> opponents = new List<IPlayer>();

        public Player(int id)
        {
            this.Id = id;
            this.opponents = new List<IPlayer>();
        }

        public Player(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User cannot be null!");
            this.Id = user.Id;
            this.NickName = user.Username;
            this.opponents = new List<IPlayer>();
        }

        public delegate void OpponentChangedHandler(OponentChangedEventArgs eventArgs);

        public event OpponentChangedHandler OnOpponentAdded;

        public event OpponentChangedHandler OnOpponentRemoved;

        public int Id { get; private set; }

        public string NickName { get; private set; }

        public ICharacter[] Characters
        {
            get { throw new NotImplementedException(); }
        }

        public IPlayer[] Opponents
        {
            get { return this.opponents.ToArray(); }
        }

        public void AddOpponent(IPlayer opponent)
        {
            this.opponents.Add(opponent);
            OnOpponentAdded(new OponentChangedEventArgs(opponent));
        }

        public virtual void Attack(IPlayer opponent)
        {
            throw new NotImplementedException();
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
