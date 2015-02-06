using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MonsterSpell.Server
{
    internal class ServerListener : TcpListener
    {
        public ServerListener(IPAddress address, int port, Action<StreamReader, StreamWriter> OnClientConnected)
            : base(address, port)
        {
            try
            {
                this.Start();
                ServerLogger.LogMessage(
                    string.Format("Server is listening at address {0} and port {1}",
                    address, port));
                WaitConnections(OnClientConnected);
            }
            catch (SocketException ex)
            {
                throw ex;
            }
        }

        public new bool Active
        {
            get { return base.Active;}
        }

        private async void WaitConnections(Action<StreamReader, StreamWriter> OnClientConnected)
        {
            while (this.Active)
            {
                var client = await this.AcceptTcpClientAsync();
                using (var streamReader = new StreamReader(client.GetStream()))
                using (var streamWriter = new StreamWriter(client.GetStream()))
                {
                    OnClientConnected(streamReader, streamWriter);
                }
            }
        }
    }
}
