using MonsterSpell.Core.DBModels;
using MonsterSpell.Core.Events;
using System.Net.Sockets;

namespace MonsterSpell.Core.Players
{
    public class UserPlayer : Player
    {
        private MongoDB.Driver.MongoCollection<User> usersCollection = null;
        private User user = null;

        public UserPlayer(User user, MongoDB.Driver.MongoDatabase dataBase)
            : base(user)
        {
            this.user = user;
            this.usersCollection = dataBase.GetCollection<User>("users");
        }

        
        public delegate void OpponentChangedHandler(OponentChangedEventArgs eventArgs);

        public event OpponentChangedHandler OnOpponentAdded;

        public event OpponentChangedHandler OnOpponentRemoved;

        public override void AddCharacter(Characters.Character character)
        {
            base.AddCharacter(character);
            user.Characters.Add(character);
            this.usersCollection.Save(user);
        }

        public override void DeleteCharacter(Characters.Character character)
        {
            base.DeleteCharacter(character);
            user.Characters.Remove(character);
            this.usersCollection.Save(user);
        }

        public override void AddOpponent(IPlayer opponent)
        {
            base.AddOpponent(opponent);
        }

        public override void Attack(IPlayer opponent)
        {
            base.Attack(opponent);
        }
    }
}
