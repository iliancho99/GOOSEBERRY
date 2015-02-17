using System;
using System.Runtime.Serialization;

namespace MonsterSpell.Core
{
    /// <summary>
    /// Base class for all game objects
    /// </summary>
    [DataContract()]
    public abstract class GameElement
    {
        protected GameElement(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("ID cannot be null or empty!");
            }
            this.Id = id;
        }

        /// <summary>
        /// Element ID
        /// </summary>
        public string Id { get; private set; }
    }
}
