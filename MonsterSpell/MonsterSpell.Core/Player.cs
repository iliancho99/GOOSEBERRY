using MonsterSpell.Core.Characters;
using System;

namespace MonsterSpell.Core
{
    public class Player : IPlayer
    {
        public string ID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string NickName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ICharacter[] Characters
        {
            get { throw new NotImplementedException(); }
        }

        public void AddCharacter(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void DeleteCharacter(ICharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
