using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MonsterSpell.Core
{
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
        /// <param name="user">Should contain login information. Property is logged in is set to true when successful.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Login(User user)
        {
            if (users == null)
                throw new InvalidOperationException("Please set user collection first!");
            if (user == null)
                throw new ArgumentNullException("Cannot login with null user!");

            user.Password = GetMD5(user.Password);
            var userExists = users.AsQueryable<User>()
                .Any(x => x.Username == user.Username && x.Password == user.Password);
            if (userExists)
            {
                user.IsLoggedIn = true;
            }
            else
            {
                throw new InvalidOperationException("Invalid username/password");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Should contain login information</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Register(User user)
        {
            Debug.Assert(users != null);

            if (users == null)
                throw new InvalidOperationException("Please set user collection first!");
            if (user == null)
                throw new ArgumentNullException("Cannot register null user!");

            var userWithSameNameExists = users.AsQueryable<User>()
                .Any(x => x.Username == user.Username);
            if (userWithSameNameExists)
            {
                throw new InvalidOperationException("There is already user with this name");
            }

            user.Password = GetMD5(user.Password);
            users.Insert(user);
        }

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
