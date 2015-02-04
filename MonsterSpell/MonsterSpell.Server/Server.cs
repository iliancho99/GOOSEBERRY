using MonsterSpell.Core;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MonsterSpell.Server
{
    internal class Server
    {
        private static readonly IPAddress DefaultAddress = IPAddress.Parse("127.3.3.1");
        private const int DEFAULT_PORT = 7241;

        private static HashSet<IPlayer> onlinePlayers = new HashSet<IPlayer>();

        private static void Main(string[] args)
        {
            var authenticationManager = new AuthenticationManager(DefaultAddress, DEFAULT_PORT);
            authenticationManager.OnUserLoggedIn += OnUserLoggedIn;
            authenticationManager.Start();

            while (authenticationManager.IsActive) { }
        }

        private static void OnUserLoggedIn(UserLoggedInEventArgs eventArgs)
        {
            if (!onlinePlayers.Contains(eventArgs.Player))
            {
                onlinePlayers.Add(eventArgs.Player);
                ListenForPlayerActions(eventArgs.Player);
            }
            else
            {
                // TODO: Return response
            }
        }

        private static async void ListenForPlayerActions(IPlayer player)
        {
            try
            {
                var streamReader = new StreamReader(player.Client.GetStream());
                while (player.Client.Connected)
                {
                    string message = await streamReader.ReadLineAsync();
                    ProcessPlayerAction(message);
                }
            }
            catch
            {
                // TODO: Process exceptions!
            }
            finally
            {
                player.Client.Close();
                onlinePlayers.Remove(player);
            }
        }

        private static void ProcessPlayerAction(string message)
        {
            switch (message)
            {
                default:
                    break;
            }
        }
    }
}
