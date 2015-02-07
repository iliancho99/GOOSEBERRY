using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MonsterSpell.Core.DBModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MonsterSpell.Core
{
    /// <summary>
    /// Works with mongodb and manages the user login and registrations
    /// </summary>
    public static class UserManager
    {
        private static MongoCollection<User> users = null;
        private static User loggedInUser = null;

        public static User LoggedInUser
        {
            get { return loggedInUser; }
        }

        /// <summary>
        /// UserManager needs MongoCollection to work with.
        /// </summary>
        public static MongoCollection<User> Users
        {
            get { return users; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Cannot set null collection!");
                users = value;
            }
        }

        /// <summary>
        /// Connects to mongodb and login with the given information.
        /// </summary>
        /// <param name="username">Username to login with.</param>
        /// <param name="password">Password to login with.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Login(string username, string password)
        {
            if (users == null)
                throw new InvalidOperationException("Please set user collection first!");
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Cannot login with empty username/password!");

            string md5Pass = GetMD5(password);
            var user = users.AsQueryable<User>()
                .FirstOrDefault(x => x.Username == username && x.Password == md5Pass);
            user.Password = string.Empty;

            loggedInUser = user;
        }

        /// <summary>
        /// Connects to mongodb and inserts new user with given information.
        /// </summary>
        /// <param name="username">Username to register with.</param>
        /// <param name="password">Password to register with.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Register(string username, string password)
        {
            Debug.Assert(users != null);

            if (users == null)
                throw new InvalidOperationException("Please set user collection first!");
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Cannot register with empty username/password!");

            var userWithSameNameExists = users.AsQueryable<User>()
                .Any(x => x.Username == username);
            if (userWithSameNameExists)
            {
                throw new InvalidOperationException("There is already user with this name");
            }

            var userTemplate = new User(username, GetMD5(password));
            users.Insert(userTemplate);
            var query = Query<User>.EQ(e => e.Id, userTemplate.Id);
            var user = users.FindOne(query);
            user.Password = string.Empty;
            loggedInUser = user;
        }

        /// <summary>
        /// Log out the current logged in user
        /// </summary>
        public static void Logout()
        {
            loggedInUser = null;
        }

        /// <summary>
        /// Encrypts string with MD5 Algorythm
        /// </summary>
        /// <param name="input">The string to be encrypted</param>
        /// <returns>MD5 encrypted string</returns>
        private static string GetMD5(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                var sb = new StringBuilder();
                foreach (var _byte in inputBytes)
                {
                    sb.Append(_byte.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
