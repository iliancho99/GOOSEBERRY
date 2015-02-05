
namespace MonsterSpell.Core.Items
{
    /// <summary>
    /// Base class for all character items
    /// </summary>
    public abstract class Item : GameElement, IItem
    {
        protected Item(string id, string name, int healthPoints, int manaPoints, int attackPoints)
            : base(id)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.ManaPoints = manaPoints;
            this.AttackPoints = attackPoints;
        }

        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Item health points effect
        /// </summary>
        public int HealthPoints { get; private set; }

        /// <summary>
        /// Item mana points effect
        /// </summary>
        public int ManaPoints { get; private set; }

        /// <summary>
        /// Item attack points effect
        /// </summary>
        public int AttackPoints { get; private set; }
    }
}