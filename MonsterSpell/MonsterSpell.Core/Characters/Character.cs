using System;
using System.Collections.Generic;
using System.Diagnostics;
using MonsterSpell.Core.Interfaces;
using MonsterSpell.Core.Items;

namespace MonsterSpell.Core.Characters
{
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

        public int HealthPoints
        {
            get { return this.healthPoints; }
            set
            {
                ValidateNumericInput(value);
                this.healthPoints = value;
            }
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set
            {
                ValidateNumericInput(value);
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get { return this.defensePoints; }
            set
            {
                ValidateNumericInput(value);
                this.defensePoints = value;
            }
        }

        public int ManaPoints
        {
            get { return this.manaPoints; }
            set
            {
                ValidateNumericInput(value);
                this.manaPoints = value;
            }
        }

        public Position Position { get; private set; }

        public IItem[] Inventory
        {
            get { return this.inventory.ToArray(); }
        }

        public IEquipable[] EquippedItems
        {
            get { return this.equippedItems.ToArray(); }
        }

        public abstract void Move(Position newPosition);

        public virtual void AddItem(IItem item)
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
        }

        public virtual void RemoveItem(IItem item)
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
        }

        public virtual void EquipItem(IEquipable item)
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
        }

        public virtual void UnequipItem(IEquipable item)
        {
            // TODO: To be implemented!
            throw new NotImplementedException();
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