using MonsterSpell.Core.Players;

namespace MonsterSpell.Core
{
    /// <summary>
    /// This is the main game class.
    /// </summary>
    public static class GameEngine
    {
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