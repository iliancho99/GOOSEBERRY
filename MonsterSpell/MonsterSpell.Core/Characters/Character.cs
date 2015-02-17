using MonsterSpell.Core.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace MonsterSpell.Core.Characters
{
    /// <summary>
    /// Base class for all characters.
    /// </summary>
    [DataContract(Name = "Character")]
    public abstract class Character : GameElement, ICharacter
    {
        private string name = string.Empty;
        private int healthPoints = 0;
        private int manaPoints = 0;
        private int attackPoints = 0;
        private int defensePoints = 0;
        [DataMember]
        private List<IItem> inventory = new List<IItem>();

        protected Character(string id, CharacterType type, int healthPoints,
            int manaPoints, int attackPoints, int defensePoints, string name)
            : base(id)
        {
            this.Type = type;
            this.HealthPoints = healthPoints;
            this.ManaPoints = manaPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Name = name;
        }

        /// <summary>
        /// Character's name
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }
                this.name = value;
            }
        }

        /// <summary>
        /// Character's health points
        /// </summary>
        [DataMember]
        public int HealthPoints
        {
            get { return this.healthPoints; }
            set
            {
                ValidateNumericInput(value);
                this.healthPoints = value;
            }
        }

        /// <summary>
        /// Character's attack points
        /// </summary>
        [DataMember]
        public int AttackPoints
        {
            get { return this.attackPoints; }
            set
            {
                ValidateNumericInput(value);
                this.attackPoints = value;
            }
        }

        /// <summary>
        /// Character's defense points
        /// </summary>
        [DataMember]
        public int DefensePoints
        {
            get { return this.defensePoints; }
            set
            {
                ValidateNumericInput(value);
                this.defensePoints = value;
            }
        }

        /// <summary>
        /// Character's mana points
        /// </summary>
        [DataMember]
        public int ManaPoints
        {
            get { return this.manaPoints; }
            set
            {
                ValidateNumericInput(value);
                this.manaPoints = value;
            }
        }

        /// <summary>
        /// Character's type
        /// </summary>
        [DataMember]
        public CharacterType Type { get; private set; }

        /// <summary>
        /// All items in the character's inventory
        /// </summary>
        [IgnoreDataMember]
        public IItem[] Inventory
        {
            get { return this.inventory.ToArray(); }
        }

        /// <summary>
        /// Adds item to the character's inventory.
        /// </summary>
        /// <param name="item">Item to be added</param>
        public virtual void AddItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot add null item!");
            }
            this.inventory.Add(item);
            ApplyItemEffects(item);
        }

        /// <summary>
        /// Removes item from the character's inventory.
        /// </summary>
        /// <param name="item">Item to be removed</param>
        public virtual bool RemoveItem(IItem item)
        {
            RemoveItemEffects(item);
            return this.inventory.Remove(item);
        }

        public override string ToString()
        {
            return string.Format("{0} | {1}", this.Name, this.Type);
        }

        protected virtual void ApplyItemEffects(IItem item)
        {
            this.HealthPoints += item.HealthPoints;
            this.ManaPoints += item.ManaPoints;
            this.AttackPoints += item.AttackPoints;
            this.DefensePoints += item.DefensePoints;
        }

        protected virtual void RemoveItemEffects(IItem item)
        {
            this.HealthPoints -= item.HealthPoints;
            this.ManaPoints -= item.ManaPoints;
            this.AttackPoints -= item.AttackPoints;
            this.DefensePoints -= item.DefensePoints;
        }

        protected void ValidateNumericInput(int input)
        {
            if (input < 0)
            {
                string propertyName = new StackFrame(1).GetMethod().Name;
                throw new ArgumentOutOfRangeException(
                    string.Format("{0} cannot be negative number!", propertyName));
            }
        }
    }
}