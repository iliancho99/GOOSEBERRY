using System.Net;

namespace MonsterSpell.Server
{
    class Program
    {
        private static readonly IPAddress DefaultAddress = IPAddress.Parse("127.3.3.1");
        private const int DEFAULT_PORT = 7241;

        static void Main(string[] args)
        {
            var authenticationManager = new AuthenticationManager(DefaultAddress, DEFAULT_PORT);
            authenticationManager.Start();
        }
    }
}
