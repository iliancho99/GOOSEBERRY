
namespace MonsterSpell.Core
{
    public struct Position
    {
        private int x;
        private int y;

        public Position(int X, int Y)
            : this()
        {
            this.X = X;
            this.Y = Y;
        }
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;

            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
    }
}
