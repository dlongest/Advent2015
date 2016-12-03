using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem3
{
    public class MultipleSantas
    {        
        public int UniqueHousesVisited(IEnumerable<char> moves)
        {
            var santa = new Santa();
            var roboSanta = new Santa();

            var numberedMoves = moves.Zip(Enumerable.Range(1, moves.Count()), (c, n) => new { Number = n, Direction = c });

            var santaMoves = numberedMoves.Where(a => a.Number % 2 == 1).Select(a => a.Direction);
            var roboSantaMoves = numberedMoves.Where(a => a.Number % 2 == 0).Select(a => a.Direction);

            var santaHouses = santa.HousesVisited(santaMoves);
            var roboSantaHouses = roboSanta.HousesVisited(roboSantaMoves);

            return santaHouses.Concat(roboSantaHouses).Distinct().Count();
        }
    }
}
