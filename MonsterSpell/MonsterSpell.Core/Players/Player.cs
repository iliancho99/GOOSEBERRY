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
    public abstract class Player : IPlayer
    {
        private List<IPlayer> opponents = new List<IPlayer>();
        private List<Characters.Character> characters =
            new List<Characters.Character>();
        
        protected Player(string userId, string nickName)
        {
            this.UserId = userId;
            this.NickName = nickName;
        }

        protected Player(string id, IComputerCharacter character)
        {
            this.UserId = id;
            this.opponents = new List<IPlayer>();
            this.characters = new List<Characters.Character>();
        }

        public string UserId { get; private set; }

        public string NickName { get; private set; }

        public Characters.Character[] Characters
        {
            get { return this.characters.ToArray(); }
        }

        public IPlayer[] Opponents
        {
            get { return this.opponents.ToArray(); }
        }

        public virtual void AddOpponent(IPlayer opponent)
        {
            this.opponents.Add(opponent);
        }

        public virtual void Attack(IPlayer opponent)
        {
            throw new NotImplementedException();
        }

        public virtual void AddCharacter(Characters.Character character)
        {
            this.characters.Add(character);
        }

        public virtual void DeleteCharacter(Characters.Character character)
        {
            this.characters.Remove(character);
        }
    }
}
