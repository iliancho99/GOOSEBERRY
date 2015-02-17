using MonsterSpell.Core.Characters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace MonsterSpell.Core.Players
{
    [KnownType(typeof(Character))]
    [KnownType(typeof(Warrior))]
    [DataContract(Name = "Player")]
    public class Player
    {
        [DataMember(Name = "Characters")]
        private List<ICharacter> characters = new List<ICharacter>();

        public Player(params ICharacter[] characters)
        {
            if (characters.Any(x => x == null))
            {
                throw new ArgumentNullException("Please enter non null characters!");
            }
            this.characters.AddRange(characters);
        }

        public delegate void CharacterAddedHandler(ICharacter character);

        public delegate void CharacterRemovedHandler(ICharacter character);

        public event CharacterAddedHandler OnCharacterAdded;

        public event CharacterRemovedHandler OnCharacterRemoved;

        public static Player FromXml(Stream xml)
        {
            var serializer = new DataContractSerializer(typeof(Player));
            var player = (Player)serializer.ReadObject(xml);
            return player;
        }

        public string ToXml()
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(Player));
                serializer.WriteObject(ms, this);
                ms.Position = 0;

                var streamReader = new StreamReader(ms);
                return streamReader.ReadToEnd();
            }
        }

        [IgnoreDataMember]
        public IEnumerable<ICharacter> Characters
        {
            get { return this.characters; }
        }

        public virtual void AddCharacter(ICharacter character)
        {
            if (character == null)
            {
                throw new ArgumentNullException("Please enter non null character!");
            }
            this.characters.Add(character);
            OnCharacterAdded(character);
        }

        public virtual bool RemoveCharacter(ICharacter character)
        {
            bool isRemoved = this.characters.Remove(character);
            if (isRemoved)
            {
                OnCharacterRemoved(character);
            }
            return isRemoved;
        }
    }
}
