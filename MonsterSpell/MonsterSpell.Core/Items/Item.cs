
namespace MonsterSpell.Core.Items
{
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

        public string Name { get; private set; }

        public int HealthPoints { get; private set; }

        public int ManaPoints { get; private set; }

        public int AttackPoints { get; private set; }
    }
}