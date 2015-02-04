using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Linq;

namespace MonsterSpell.Core
{
    public static class GameEngine
    {
        private const string DB_URI = "mongodb://admin:qwerty@ds045998.mongolab.com:45998/monsterspell";

        private static MongoDatabase database = null;

        static GameEngine()
        {
            var mongoClient = new MongoClient(DB_URI);
            var server = mongoClient.GetServer();
            database = server.GetDatabase("monsterspell");

            UserManager.Users = database.GetCollection<User>("users");
        }

        public static void Login(string username, string password)
        {
            UserManager.Login(new User(username, password));
        }

        public static void Register(string username, string password)
        {
            UserManager.Register(new User(username, password));
        }
    }
}