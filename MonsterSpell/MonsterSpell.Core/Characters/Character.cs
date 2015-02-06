using System;
using System.Collections.Generic;
using System.Diagnostics;
using MonsterSpell.Core.Interfaces;
using MonsterSpell.Core.Items;

namespace MonsterSpell.Core.Characters
{
    /// <summary>
    /// Base class for all characters.
    /// </summary>
    public abstract class Character : GameElement, ICharacter
    {
        private string name = string.Empty;
        private int healthPoints = 0;
        private int manaPoints = 0;
        private int attackPoints = 0;
        private int defensePoints = 0;
        private List<IItem> inventory = new List<IItem>();
        private List<IEquipable> equippedItems = new List<IEquipable>();

        protected Character(string id)
            : base(id) { }

        /// <summary>
        /// Character's name
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
        /// Character's health points
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
        /// Character's current position on the map
        /// </summary>
        public Position Position { get; private set; }

        /// <summary>
        /// All items in the character's inventory
        /// </summary>
        public IItem[] Inventory
        {
            get { return this.inventory.ToArray(); }
        }

        /// <summary>
        /// All equipped items on the character
        /// </summary>
        public IEquipable[] EquippedItems
        {
            get { return this.equippedItems.ToArray(); }
        }

        /// <summary>
        /// Adds item to the character's inventory.
        /// </summary>
        /// <param name="item">Item to be added</param>
        public virtual void AddItem(IItem item)
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes item from the character's inventory.
        /// </summary>
        /// <param name="item">Item to be removed</param>
        public virtual void RemoveItem(IItem item)
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
        }

        /// <summary>
        /// Equips item from the inventory. Applies its effects on the character.
        /// </summary>
        /// <param name="item">Item to be equipped</param>
        public virtual void EquipItem(IEquipable item)
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unequips item from the inventory. Removes its effects from the character.
        /// </summary>
        /// <param name="item">Item to be unequipped</param>
        public virtual void UnequipItem(IEquipable item)
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("ID: {0} Name: {1} Level: {2}",
                this.ID, this.Name, 3); // Hardcode for now
        }

        protected virtual void ApplyItemEffects()
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
        }

        protected virtual void RemoveItemEffects()
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
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