using Advent2015.Core.Problem6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent2015.Tests.Problem6
{
    public class LightGridTests
    {
        [Fact]
        public void TurnOn_TurnsOnTheCorrectLights()
        {
            var rect = new CoordinateRectangle(Coordinate.Origin, new Coordinate(1, 1));

            var grid = new LightGrid();

            grid.Setup(() => new[] { new Instruction(InstructionAction.TurnOn, rect) });

            var on = grid.WhatLightsAreOn().Select(c => c.Coordinate);

            Assert.Equal(4, on.Count());            
            Assert.True(on.Contains(new Coordinate(0, 0)));
            Assert.True(on.Contains(new Coordinate(0, 1)));
            Assert.True(on.Contains(new Coordinate(1, 0)));
            Assert.True(on.Contains(new Coordinate(1, 1)));          
        }

        [Fact]
        public void TurnOn_SetsLights_ToCorrectBrightness()
        {
            var rect = new CoordinateRectangle(Coordinate.Origin, new Coordinate(1, 1));

            var grid = new LightGrid();

            grid.Setup(() => new[] { new Instruction(InstructionAction.TurnOn, rect), new Instruction(InstructionAction.TurnOn, rect) });

            var brightnesses = grid.WhatLightsAreOn().Select(c => c.Brightness);

            Assert.Equal(4, brightnesses.Count());
            Assert.True(brightnesses.All(a => a == 2));
        }

        [Fact]
        public void Toggle_TurnsOnLightsThatAreOff()
        {
            var rect = new CoordinateRectangle(Coordinate.Origin, new Coordinate(1, 1));

            var grid = new LightGrid();

            grid.Setup(() => new[] { new Instruction(InstructionAction.Toggle, rect) });

            var on = grid.WhatLightsAreOn().Select(c => c.Coordinate);

            Assert.Equal(4, on.Count());
            Assert.True(on.Contains(new Coordinate(0, 0)));
            Assert.True(on.Contains(new Coordinate(0, 1)));
            Assert.True(on.Contains(new Coordinate(1, 0)));
            Assert.True(on.Contains(new Coordinate(1, 1)));
        }

        [Fact]
        public void Toggle_IncreasesBrightness()
        {
            var rect = new CoordinateRectangle(Coordinate.Origin, new Coordinate(1, 1));

            var grid = new LightGrid();

            grid.Setup(() => new[] { new Instruction(InstructionAction.Toggle, rect), new Instruction(InstructionAction.Toggle, rect) });

            var on = grid.WhatLightsAreOn();
            var coords = on.Select(c => c.Coordinate);
            var brightnesses = on.Select(c => c.Brightness);

            Assert.Equal(4, on.Count());
            Assert.True(coords.Contains(new Coordinate(0, 0)));
            Assert.True(coords.Contains(new Coordinate(0, 1)));
            Assert.True(coords.Contains(new Coordinate(1, 0)));
            Assert.True(coords.Contains(new Coordinate(1, 1)));
            Assert.True(brightnesses.All(b => b == 4));
        }
    }
}
