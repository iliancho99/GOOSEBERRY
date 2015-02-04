using System;

namespace MonsterSpell.Core.Exceptions
{
    public class ServerException : ApplicationException
    {
        public ServerException(string msg)
            : base(msg) { }

        public ServerException(string msg, Exception inner)
            : base(msg, inner) { }
    }
}
