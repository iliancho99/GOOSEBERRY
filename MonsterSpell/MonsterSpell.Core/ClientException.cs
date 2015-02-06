using System;

namespace MonsterSpell.Core
{
    public class ClientException : ApplicationException
    {
        public ClientException(string msg)
            : base(msg) { }

        public ClientException(string msg, Exception inner)
            : base(msg, inner) { }
    }
}
