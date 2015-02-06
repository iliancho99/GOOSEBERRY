using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MonsterSpell.Server
{
	internal class Server
	{
		private static readonly IPAddress DefaultAddress = IPAddress.Parse("127.3.3.1");
		private const int DEFAULT_PORT = 7241;
		private static readonly Random Random = new Random();

		private static HashSet<Client> onlinePlayers = new HashSet<Client>();
		private static AutoResetEvent stopWaitHandle = new AutoResetEvent(false);

		private static void Main(string[] args)
		{
			while (true)
			{
				var serverListener = new ServerListener(DefaultAddress, DEFAULT_PORT);
				Handshake(serverListener);

				// Pause the main thread
				stopWaitHandle.WaitOne();
			}
		}

		/// <summary>
		/// Main handshake procedure.
		/// Reads the first line of the input stream and parses the first character as
		/// integer and starts message loop
		/// </summary>
		/// <param name="serverListener">Listening TcpListener</param>
		private static async void Handshake(ServerListener serverListener)
		{
			while (serverListener.Active)
			{
				var client = await serverListener.WaitConnection();

				string clientIdAsString = await client.StreamReader.ReadLineAsync();
				try
				{
					// The first line should be integer number
					int clientId = int.Parse(clientIdAsString);
					client.Id = clientId;
					onlinePlayers.Add(client);
					ListenForMessages(client);
				}
				catch (Exception ex)
				{
					ServerLogger.LogException(ex);
					onlinePlayers.Remove(client);
					client.Dispose();
				}
			}

			// Resume the main thread
			stopWaitHandle.Set();
		}

		/// <summary>
		/// Enters message loop on client
		/// </summary>
		/// <param name="client">Client containing network streams</param>
		private static async void ListenForMessages(Client client)
		{
			while (client.TcpClient.Connected)
			{
				string message = await client.StreamReader.ReadLineAsync();
				string data = await client.StreamReader.ReadLineAsync();

				Execute(message, data);
			}
		}

		private static void Execute(string message, string data)
		{
			switch (message)
			{
				default:
					break;
			}
		}

		private static void SendMessage(string message, string data, TcpClient client)
		{
			throw new NotImplementedException();
		}

		private static async void BroadcastMessage(string message, string data)
		{
			foreach (var client in onlinePlayers)
			{
				if (client.TcpClient.Connected)
				{
					await client.StreamWriter.WriteLineAsync(message);
					await client.StreamWriter.WriteLineAsync(data);
				}
				else
				{
					client.Dispose();
					onlinePlayers.Remove(client);
				}
			}
		}
	}
}
