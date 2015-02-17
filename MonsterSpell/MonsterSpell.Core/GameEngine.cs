using MonsterSpell.Core.Players;
using System.IO;
using System.Runtime.Serialization;

namespace MonsterSpell.Core
{
    /// <summary>
    /// This is the main game class.
    /// </summary>
    public static class GameEngine
    {
        public const string PLAYER_DATA_FILE_PATH = "./player.xml";

        private static Player player = null;

        static GameEngine()
        {
            try
            {
                using (var fs = File.OpenRead(PLAYER_DATA_FILE_PATH))
                {
                    player = Player.FromXml(fs);
                }
            }
            catch (FileNotFoundException)
            {
                player = new Player();
                SaveGame();
            }
            catch
            {

            }
            finally
            {
                player.OnCharacterAdded += character => SaveGame();
                player.OnCharacterRemoved += character => SaveGame();
            }
        }

        public static Player Player
        {
            get { return player; }
        }

        public static void SaveGame()
        {
            using (var fs = File.OpenWrite(PLAYER_DATA_FILE_PATH))
            using (var writer = new StreamWriter(fs))
            {
                writer.Write(player.ToXml());
            }
        }
    }
}