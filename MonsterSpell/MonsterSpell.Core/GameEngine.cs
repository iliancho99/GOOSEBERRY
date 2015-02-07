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
using System.Diagnostics;
using System.Threading.Tasks;
using MonsterSpell.Core.Characters;

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
        private static UserPlayer currentPlayer = null;
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

        private static void OnOpponentRemoved(Events.OponentChangedEventArgs eventArgs)
        {
            if (currentPlayer.Opponents.Length < MAX_OPPONENTS_COUNT)
            {
                var randomId = random.Next(0, int.MaxValue);
                var bot = new Bot("", null, currentPlayer);
                currentPlayer.AddOpponent(bot);
            }
        }
    }
}