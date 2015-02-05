using MongoDB.Driver;
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
    internal static class UserManager
    {
        private static MongoCollection<User> users = null;

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
        /// <returns>Null if login is unsuccessful.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static User Login(string username, string password)
        {
            if (users == null)
                throw new InvalidOperationException("Please set user collection first!");
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Cannot login with empty username/password!");

            string md5Pass = GetMD5(password);
            var user = users.AsQueryable<User>()
                .FirstOrDefault(x => x.Username == username && x.Password == md5Pass);
            user.Password = string.Empty;

            return user;
        }

        /// <summary>
        /// Connects to mongodb and inserts new user with given information.
        /// </summary>
        /// <param name="user">Should contain login information</param>
        /// <returns>Null if registration is unsuccessful</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static User Register(string username, string password)
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

            var user = new User(username, GetMD5(password));
            users.Insert(user);
            user.Password = string.Empty;

            return user;
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
