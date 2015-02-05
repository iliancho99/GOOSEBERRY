using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MonsterSpell.Server
{
    internal class ServerListener : TcpListener
    {
        public ServerListener(IPAddress address, int port)
            : base(address, port)
        {
            try
            {
                this.Start();
                ServerLogger.LogMessage(
                    string.Format("Server is listening at address {0} and port {1}",
                    address, port));
                WaitConnections();
            }
            catch (SocketException ex)
            {
                throw ex;
            }
        }

        private async void WaitConnections()
        {
            while (this.Active)
            {
                var client = await this.AcceptTcpClientAsync();
            }
        }
    }
}
