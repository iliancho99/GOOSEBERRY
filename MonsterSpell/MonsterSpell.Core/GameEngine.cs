using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MonsterSpell.Core.DBModels;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using MonsterSpell.Core.Players;

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
        private const int MAX_OPPONENTS_COUNT = 5;

        private static MongoDatabase database = null;
        private static Player currentPlayer = null;
        private static List<IPlayer> opponents = new List<IPlayer>();
        private static StreamReader streamReader = null;
        private static StreamWriter streamWriter = null;
        private static Random random = new Random();

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
        public static Player Player
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
            Init(user);
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
            Init(user);
        }

        /// <summary>
        /// Connects to the server and start listening for messages
        /// </summary>
        /// <param name="user">User contains necessary data</param>
        /// <exception cref="ArgumentNullException"></exception>
        private static async void Init(User user)
        {
            if (user == null)
                throw new ArgumentNullException("Please provide non null user!");

            currentPlayer = new Player(user);
            await currentPlayer.ConnectAsync(ServerAddress, DEFAULT_PORT);

            currentPlayer.OnOpponentRemoved += OnOpponentRemoved;

            while (currentPlayer.Connected)
            {
                string messageType = await streamReader.ReadLineAsync();
                string data = await streamReader.ReadLineAsync();

                ProcessMessage(int.Parse(messageType), data);
            }
        }

        private static void OnOpponentRemoved(Events.OponentChangedEventArgs eventArgs)
        {
            if (currentPlayer.Opponents.Length < MAX_OPPONENTS_COUNT)
            {
                var randomId = random.Next(0, int.MaxValue);
                var bot = new Bot(randomId, currentPlayer);
                currentPlayer.AddOpponent(bot);
            }
        }

        private static void ProcessMessage(int messageType, string data)
        {
            switch ((MessageType)messageType)
            {
                case MessageType.Attacked:
                    break;
                case MessageType.Attack:
                    break;
                default:
                    break;
            }
        }
    }
}