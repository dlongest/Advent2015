using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem6
{
    public class LightGrid
    {
        private int[][] grid;
        private int dimension = 1000;

        public LightGrid()
        {
            this.grid = new int[dimension][];

            foreach (var d in Enumerable.Range(0, dimension))
            {
                this.grid[d] = new int[dimension];
            }
        }

        public void Setup(Func<IEnumerable<Instruction>> instructions)
        {
            foreach (var instruction in instructions())
            {
                switch (instruction.Action)
                {
                    case InstructionAction.Toggle:
                        AdjustLights(instruction.Rectangle, light => light + 2);
                        break;
                    case InstructionAction.TurnOn:
                        AdjustLights(instruction.Rectangle, light => light + 1);
                        break;
                    case InstructionAction.TurnOff:
                        AdjustLights(instruction.Rectangle, light => light == 0 ? 0 : light - 1);
                        break;
                }
            }
        }

        public IEnumerable<Light> WhatLightsAreOn()
        {
            foreach (var column in Enumerable.Range(0, dimension))
            {
                foreach (var row in Enumerable.Range(0, dimension))
                {
                    if (this.grid[column][row] > 0)
                    {
                        yield return new Light(new Coordinate(column, row), this.grid[column][row]);
                    }
                }
            }
        }

        private void AdjustLights(CoordinateRectangle rectangle, Func<int, int> adjust)
        {
            foreach (var coordinate in rectangle.InBox())
            {                
                this.grid[coordinate.X][coordinate.Y] = adjust(this.grid[coordinate.X][coordinate.Y]);
            }
        }      
    }

    public class Light
    {
        public Light(Coordinate coordinate, int brightness)
        {
            this.Coordinate = coordinate;
            this.Brightness = brightness;
        }

        public Coordinate Coordinate { get; private set; }

        public int Brightness { get; private set;  }
    }
}
