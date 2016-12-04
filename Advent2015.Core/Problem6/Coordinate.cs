using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem6
{
    public class Coordinate
    {
        public static Coordinate Origin = new Coordinate(0, 0);

        public static Coordinate Create(string commaSeparatedString)
        {
            var tokens = commaSeparatedString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            return new Coordinate(Int32.Parse(tokens[0]), Int32.Parse(tokens[1]));
        }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var coord = obj as Coordinate;

            if (coord == null) return false;

            return this.X == coord.X && this.Y == coord.Y;
        }

        public override int GetHashCode()
        {
            return this.X + 3 * this.Y;
        }
    }
}
