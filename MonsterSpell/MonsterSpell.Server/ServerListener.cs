using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MonsterSpell.Server
{
    internal class ServerListener : TcpListener
    {
        internal ServerListener(IPAddress address, int port)
            : base(address, port)
        {
            this.Start();
            IPEndPoint endPoint = (IPEndPoint)this.LocalEndpoint;
            ServerLogger.LogMessage(
                    string.Format("Server is listening at address {0} and port {1}",
                    endPoint.Address, endPoint.Port));
        }

        internal new bool Active
        {
            get { return base.Active; }
        }

        /// <summary>
        /// Wait for connection
        /// </summary>
        /// <returns>Client object containing IO streams</returns>
        internal async Task<Client> WaitConnection()
        {
            var tcpClient = await this.AcceptTcpClientAsync();
            var client = new Client(tcpClient);
            return client;
        }
    }
}
