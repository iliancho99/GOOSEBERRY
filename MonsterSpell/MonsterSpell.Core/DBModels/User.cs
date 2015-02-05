using System;
using System.Collections.Generic;

namespace MonsterSpell.Core.DBModels
{
    /// <summary>
    /// Represents mongodb model
    /// </summary>
    public class User
    {
        private string username = string.Empty;
        private string password = string.Empty;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Characters = new List<Characters.Character>();
        }

        public int Id { get; set; }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Username cannot be null or empty!");
                this.username = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Password cannot be null or empty!");
                this.password = value;
            }
        }

        public List<Characters.Character> Characters { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}", this.Id, this.Username);
        }
    }
}