using System;

namespace MonsterSpell.Server
{
    public class AuthenticationException : ApplicationException
    {
        public AuthenticationException(string msg)
            : base(msg) { }

        public AuthenticationException(string msg, Exception inner)
            : base(msg, inner) { }
    }
}
