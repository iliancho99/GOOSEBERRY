using MonsterSpell.Core.Players;
using System.Net;

namespace MonsterSpell.Core
{
    /// <summary>
    /// This is the main game class.
    /// </summary>
    public static class GameEngine
    {
        private static readonly IPAddress ServerAddress = IPAddress.Parse("127.3.3.1");
        private const int DEFAULT_PORT = 7241;

        static GameEngine()
        {
            currentPlayer = new UserPlayer("a", "a"); // Temporary
        }

        private static UserPlayer currentPlayer = null;

        /// <summary>
        /// Returns the current player
        /// </summary>
        public static UserPlayer Player
        {
            get { return currentPlayer; }
        }
    }
}