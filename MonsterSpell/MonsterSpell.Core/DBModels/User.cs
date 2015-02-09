using MongoDB.Bson;
using System.Collections.Generic;

namespace MonsterSpell.Core.DBModels
{
    /// <summary>
    /// Represents mongodb user model
    /// </summary>
    public class User
    {
        private string username = string.Empty;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Characters = new List<Character>();
        }

        public ObjectId Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<Character> Characters { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}", this.Id, this.Username);
        }
    }
}