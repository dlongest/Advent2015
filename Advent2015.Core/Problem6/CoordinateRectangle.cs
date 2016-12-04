using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem6
{
    public class CoordinateRectangle
    {
        public CoordinateRectangle(Coordinate corner, Coordinate oppositeCorner)
        {
            if (corner.X < oppositeCorner.X)
            {
                this.Corner = corner;
                this.OppositeCorner = oppositeCorner;
            }
            else
            {
                this.Corner = oppositeCorner;
                this.OppositeCorner = corner;
            }
        }

        public Coordinate Corner { get; private set; }

        public Coordinate OppositeCorner { get; private set; }

        public Coordinate[] InBox()
        {
            var columns = Enumerable.Range(this.Corner.X, this.OppositeCorner.X - this.Corner.X);

            var startRow = this.Corner.Y < this.OppositeCorner.Y ? this.Corner.Y : this.OppositeCorner.Y;
            var endRow = this.Corner.Y > this.OppositeCorner.Y ? this.Corner.Y : this.OppositeCorner.Y;

            return CreateCoordinates(startRow, endRow, this.Corner.X, this.OppositeCorner.X);
        }

        private Coordinate[] CreateCoordinates(int startRow, int endRow, int startColumn, int endColumn)
        {
            var coords = new List<Coordinate>();

            foreach (var column in Enumerable.Range(startColumn, endColumn - startColumn + 1))
            {
                foreach (var row in Enumerable.Range(startRow, endRow - startRow + 1))
                {
                    coords.Add(new Coordinate(column, row));
                }
            }

            return coords.ToArray();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var rect = obj as CoordinateRectangle;

            if (rect == null) return false;

            return rect.Corner.Equals(this.Corner) && rect.OppositeCorner.Equals(this.OppositeCorner);
        }

        public override int GetHashCode()
        {
            return this.Corner.GetHashCode() + 3 * this.OppositeCorner.GetHashCode();
        }
    }
}
