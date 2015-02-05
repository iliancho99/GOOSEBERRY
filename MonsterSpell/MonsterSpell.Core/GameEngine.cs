using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MonsterSpell.Core.DBModels;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace MonsterSpell.Core
{
    /// <summary>
    /// This is the main game class.
    /// </summary>
    public static class GameEngine
    {
        private static readonly IPAddress ServerAddress = IPAddress.Parse("127.3.3.1");
        private const int DEFAULT_PORT = 7241;
        private const string DB_URI = "mongodb://admin:qwerty@ds045998.mongolab.com:45998/monsterspell";

        private static MongoDatabase database = null;
        private static IPlayer currentPlayer = null;

        static GameEngine()
        {
            var mongoClient = new MongoClient(DB_URI);
            var server = mongoClient.GetServer();
            database = server.GetDatabase("monsterspell");

            UserManager.Users = database.GetCollection<User>("users");
        }

        /// <summary>
        /// Returns the current logged in player
        /// </summary>
        public static IPlayer Player
        {
            get
            {
                return currentPlayer;
            }
        }

        /// <summary>
        /// Login with provided username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Login(string username, string password)
        {
            var user = UserManager.Login(username, password);
            ConnectToServer(user);
        }

        /// <summary>
        /// Register with provided username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Register(string username, string password)
        {
            var user = UserManager.Register(username, password);
            ConnectToServer(user);
        }

        private static void ConnectToServer(User user)
        {
            if (user == null)
                throw new ArgumentNullException("Please provide non null user!");

            //var player = new Player(user);
            //player.ConnectToServer(ServerAddress, DEFAULT_PORT);
        }
    }
}