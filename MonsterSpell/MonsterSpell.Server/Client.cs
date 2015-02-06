using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace MonsterSpell.Server
{
    internal class Client : IDisposable
    {
        public Client(TcpClient client)
        {
            this.TcpClient = client;
            this.StreamReader = new StreamReader(client.GetStream());
            this.StreamWriter = new StreamWriter(client.GetStream());
        }

        public int Id { get; set; }

        public TcpClient TcpClient { get; private set; }

        public StreamReader StreamReader { get; private set; }

        public StreamWriter StreamWriter { get; private set; }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public void Dispose()
        {
            this.StreamReader.Close();
            this.StreamWriter.Close();
        }
    }
}
