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
        private const string DATABASE_URI = "mongodb://admin:qwerty@ds045998.mongolab.com:45998/monsterspell";

        private static MongoCollection<User> usersCollection = null;
        private static User loggedInUser = null;

        /// <summary>
        /// Connects to the db server
        /// </summary>
        static UserManager()
        {
            var mongoClient = new MongoClient(DATABASE_URI);
            var server = mongoClient.GetServer();
            var database = server.GetDatabase("monsterspell");
            usersCollection = database.GetCollection<User>("users");
        }

        /// <summary>
        /// Returns the current logged in user or null if not logged in
        /// </summary>
        public static User LoggedInUser
        {
            get { return loggedInUser; }
        }

        /// <summary>
        /// Logs in with the provided user information
        /// </summary>
        /// <param name="username">Username to login with</param>
        /// <param name="password">Password to login with</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Login(string username, string password)
        {
            Debug.Assert(usersCollection != null,
                "This shoudn't happen! It can be db server error.");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Cannot login with empty username/password!");

            string md5Pass = GetMD5(password);
            var user = usersCollection.AsQueryable<User>()
                .FirstOrDefault(x => x.Username == username && x.Password == md5Pass);
            user.Password = string.Empty;

            loggedInUser = user;
        }

        /// <summary>
        /// Registers new user with the provided informatio
        /// </summary>
        /// <param name="username">Username to register with</param>
        /// <param name="password">Password to register with</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static void Register(string username, string password)
        {
            Debug.Assert(usersCollection != null,
                "This shoudn't happen! It can be db server error.");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Cannot register with empty username/password!");
            }

            var findByUserNameQuery = Query<User>.EQ(e => e.Username, username);
            if (usersCollection.FindOne(findByUserNameQuery) != null)
            {
                throw new InvalidOperationException("There is already user with this name");
            }

            var user = new User(username, GetMD5(password));
            usersCollection.Insert(user);
            user.Password = string.Empty;
            loggedInUser = user;
        }

        /// <summary>
        /// Logs out the current logged in user
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
