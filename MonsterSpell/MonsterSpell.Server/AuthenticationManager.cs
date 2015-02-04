using MonsterSpell.Core;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MonsterSpell.Server
{
    internal class AuthenticationManager : TcpListener
    {
        public AuthenticationManager(IPAddress address, int port)
            : base(address, port) { }

        public delegate void UserLoggedInHandler(UserLoggedInEventArgs eventArgs);

        public event UserLoggedInHandler OnUserLoggedIn;

        public new void Start()
        {
            try
            {
                base.Start();
                Console.WriteLine("Listening for connections...");
            }
            catch (SocketException ex)
            {
                Console.Write("Couldn't start server: ");
                Console.WriteLine(ex.Message);
                ServerLogger.LogException(ex);
            }

            WaitAuthRequests();
        }

        private async void WaitAuthRequests()
        {
            while (this.Active)
            {
                var client = await this.AcceptTcpClientAsync();
                ServerLogger.LogMessage(
                    string.Format("Accepted client: {0}", client.Client.RemoteEndPoint));

                var clientStream = client.GetStream();
                var streamWriter = new StreamWriter(clientStream);
                try
                {
                    ProcessRequest(clientStream);
                }
                catch (AuthenticationException ex)
                {
                    streamWriter.WriteLine("Error:{0}", ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    streamWriter.WriteLine("Error:{0}", ex.Message);
                }
                catch (Exception ex)
                {
                    ServerLogger.LogException(ex);
                    streamWriter.WriteLine("Error:Internal server error: {0}", ex.Message);
                }
            }
        }

        private async void ProcessRequest(Stream stream)
        {
            var streamReader = new StreamReader(stream);

            string username = await streamReader.ReadLineAsync();
            string password = await streamReader.ReadLineAsync();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new AuthenticationException("Error: No username and/or password provided!");
            }

            switch (streamReader.ReadLine())
            {
                case "Login":
                    Login(username, password);
                    break;
                case "Register":
                    Register(username, password);
                    break;
                default:
                    throw new InvalidOperationException("Login/Register message expected first!");
            }
        }

        private void Login(string username, string password)
        {
            var isLoggedIn = true; //Simulate successful login
            var dbConnection = true; //Simulate successful db connection

            if (!dbConnection)
            {
                throw new SystemException("Couldn't connect to database!");
            }

            if (isLoggedIn)
            {
                var player = new Player();
                player.NickName = username;
                player.ID = "";

                this.OnUserLoggedIn(new UserLoggedInEventArgs(player));
            }
            else
            {
                throw new AuthenticationException("Invalid username/password!");
            }
        }

        private bool Register(string username, string password)
        {
            var dbConnection = true; //Simulate successful db connection

            if (!dbConnection)
            {
                throw new SystemException("Couldn't connect to database!");
            }

            throw new NotImplementedException();
        }
    }
}