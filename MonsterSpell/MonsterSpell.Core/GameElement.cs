using System;

namespace MonsterSpell.Core
{
    /// <summary>
    /// Base class for all game objects
    /// </summary>
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
