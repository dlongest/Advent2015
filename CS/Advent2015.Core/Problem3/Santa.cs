using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem3
{
    public class Santa
    {
        private Coordinate currentPosition;
        private IDictionary<char, Func<Coordinate, Coordinate>> nextMove;
        private IList<Coordinate> visited = new List<Coordinate>();

        public Santa()
        {
            this.currentPosition = Coordinate.Origin;
            this.nextMove = new Dictionary<char, Func<Coordinate, Coordinate>>()
            {
                { '^', c => c.Up() },
                { '<', c => c.Left() },
                { '>', c => c.Right() },
                { 'v', c => c.Down() },
            };
        }

        public Coordinate[] HousesVisited(IEnumerable<char> moves)
        {
            visited.Add(this.currentPosition);

            foreach (var move in moves)
            {
                this.currentPosition = this.nextMove[move](this.currentPosition);
                visited.Add(this.currentPosition);
            }

            return visited.ToArray();
        } 
    }   

    public class Coordinate
    {
        public static Coordinate Origin = new Coordinate(0, 0);

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public Coordinate Up()
        {
            return new Coordinate(this.X, this.Y + 1);
        }

        public Coordinate Down()
        {
            return new Coordinate(this.X, this.Y - 1);
        }

        public Coordinate Right()
        {
            return new Coordinate(this.X + 1, this.Y);
        }

        public Coordinate Left()
        {
            return new Coordinate(this.X - 1, this.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var coord = obj as Coordinate;

            if (coord == null)
                return false;

            return this.X == coord.X && this.Y == coord.Y;
        }

        public override int GetHashCode()
        {
            return this.X + 3 * this.Y;
        }
    }
}
