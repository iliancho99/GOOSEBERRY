using System;

namespace MonsterSpell.Server
{
    internal static class ServerLogger
    {
        public static void LogMessage(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                throw new ArgumentNullException("Please provide message!");

            Console.WriteLine(msg);
            //TODO : To be implemented!
        }

        public static void LogException(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException("Please provide exception!");

            //throw new NotImplementedException();
            //TODO : To be implemented!
        }
    }
}
