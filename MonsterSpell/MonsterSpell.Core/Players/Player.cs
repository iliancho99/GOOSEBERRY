using MonsterSpell.Core.Characters;
using MonsterSpell.Core.Characters.Warrior;
using MonsterSpell.Core.Characters.Warrior.Spells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace MonsterSpell.Core.Players
{
    [KnownType(typeof(Character))]
    [KnownType(typeof(Warrior))]
    [KnownType(typeof(BrutalAxe))]
    [DataContract(Name = "Player")]
    public class Player : IPlayer
    {
        [DataMember(Name = "Characters")]
        private List<ICharacter> characters = new List<ICharacter>();
        private Random random = new Random();
        private IPlayer focusedPlayer = null;
        private List<IPlayer> opponents = new List<IPlayer>();

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

        public ICharacter CurrentCharacter { get; private set; }

        public IPlayer[] Opponents { get { return this.opponents.ToArray(); } }

        public void FocusOpponent(IPlayer opponent)
        {
            if (opponent == null)
            {
                throw new ArgumentNullException("Cannot focus null player!");
            }

            this.focusedPlayer = opponent;
        }

        public void CastSpell(ISpell spell)
        {
            if (spell.HealDamage > 0)
            {
                double randomMultiplyer = this.random.NextDouble();
                double randomHealingEffect = randomMultiplyer * spell.HealDamage;
                this.CurrentCharacter.HealthPoints += randomHealingEffect;
            }
            else if (spell.AttackDamage > 0)
            {
                double playerMultiplyer = this.random.NextDouble();
                double opponentMultiplyer = this.random.NextDouble();
                double damage = (this.CurrentCharacter.AttackPoints + spell.AttackDamage) * playerMultiplyer;

                if (focusedPlayer == null)
                {
                    throw new InvalidOperationException("Cannot attack null target!");
                }
                focusedPlayer.OnAttacked(spell, this, damage);
            }
        }

        public void OnAttacked(ISpell spell, IPlayer player, double damage)
        {
            throw new NotImplementedException();
        }

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
