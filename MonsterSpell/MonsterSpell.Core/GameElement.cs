using System;

namespace MonsterSpell.Core
{
    public abstract class GameElement
    {
        protected GameElement(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("ID cannot be null or empty!");
            }
            this.ID = id;
        }

        public string ID { get; private set; }
    }
}
