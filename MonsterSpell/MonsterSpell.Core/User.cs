using System;

namespace MonsterSpell.Core
{
    /// <summary>
    /// Represents mongodb model
    /// </summary>
    internal class User
    {
        private string username = string.Empty;
        private string password = string.Empty;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public int Id { get; set; }

        public bool IsLoggedIn { get; set; }

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
    }
}