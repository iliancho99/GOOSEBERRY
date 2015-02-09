using MongoDB.Bson;

namespace MonsterSpell.Core.DBModels
{
    internal class Character
    {
        private string name = string.Empty;

        public Character(string characterId, string ownerId, string name)
        {
            this.CharacterId = characterId;
            this.OwnerId = ownerId;
            this.Name = name;
        }

        public ObjectId Id { get; set; }

        public string CharacterId { get; set; }

        public string OwnerId { get; set; }

        public string Name { get; set; }
    }
}
