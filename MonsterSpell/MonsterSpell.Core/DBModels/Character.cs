using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterSpell.Core.DBModels
{
    internal class Character
    {
        private string name = string.Empty;

        public Character(string userId, string name)
        {
            this.UserId = userId;
            this.Name = name;
        }

        public ObjectId Id { get; set; }

        public string UserId { get; private set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name cannot be null or empty!");
                this.name = value;
            }
        }
    }
}
