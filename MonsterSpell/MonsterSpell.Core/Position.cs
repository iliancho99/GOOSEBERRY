using System;

namespace MonsterSpell.Core
{
    public struct Position : IEquatable<Position>
    {
        public Position(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public bool Equals(Position other)
        {
            return (this.X == other.X) && (this.Y == other.Y);
        }
    }
}
