using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MonsterSpell.Server
{
    internal class Server
    {
        private static readonly IPAddress DefaultAddress = IPAddress.Parse("127.3.3.1");
        private const int DEFAULT_PORT = 7241;
        private static Random random = new Random();
        private static List<StreamWriter> onlinePlayers = new List<StreamWriter>();

        private static void Main(string[] args)
        {
            var serverListener = new ServerListener(DefaultAddress, DEFAULT_PORT,
                (streamReader, streamWriter) =>
                {
                    onlinePlayers.Add(streamWriter);
                    WaitForClientData(streamReader);
                });
            while (serverListener.Active)
            {

            }
        }

        private static async void WaitForClientData(StreamReader streamReader)
        {
            while (streamReader != null)
            {
                string playerId = await streamReader.ReadLineAsync();
                string data = await streamReader.ReadLineAsync();
                Console.WriteLine(playerId);
            }
        }
    }
}
