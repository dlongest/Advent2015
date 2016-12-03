using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem1
{
    public class FloorMover
    {
        public int Move(string instructions)
        {
            var tokens = instructions.Select(c => c);

            var up = tokens.Where(c => c == '(');
            var down = tokens.Where(c => c == ')');

            return up.Count() - down.Count();
        }

        public int? FirstPosition(string instructions, int targetFloor)
        {
            var tokens = instructions.Select(c => c);
            int currentFloor = 0;
            int currentPosition = 0;

            foreach (var token in tokens)
            {
                currentFloor += token == '(' ? 1 : -1;
                currentPosition++;

                if (currentFloor == targetFloor)
                    return currentPosition;
            }

            return null;
        }
    }
}
