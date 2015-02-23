using MonsterSpell.Core.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;


namespace MonsterSpell.Core.Monster
{
    /// <summary>
    /// Base class for all Monsters.
    /// </summary>
    [DataContract(Name = "Monster")]
    public abstract class Monster
    {
        private string name = string.Empty;
        private int healthPoints = 0;
        private int manaPoints = 0;
        private int attackPoints = 0;
        private int defensePoints = 0;        private List<IItem> inventory = new List<IItem>();

        protected Monster(string id, MonsterType type, int healthPoints,
            int manaPoints, int attackPoints, int defensePoints, string name)
        {
            this.Type = type;
            this.HealthPoints = healthPoints;
            this.ManaPoints = manaPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Name = name;
        }

        /// <summary>
        /// Monster's name
        /// </summary>
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
        /// Monster's health points
        /// </summary>
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
        /// Monsyer's defense points
        /// </summary>
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
        /// Monster's mana points
        /// </summary>
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
        public MonsterType Type { get; private set; }

    

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