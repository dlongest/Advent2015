using Advent2015.Core.Problem6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent2015.Tests.Problem6
{
    public class InstructionTests
    {
        [Fact]
        public void TurnOff_Instruction_CreatedCorrectly()
        {
            var expected = new CoordinateRectangle(new Coordinate(660, 55), new Coordinate(986, 197));

            var instruction = Instruction.Create("turn off 660,55 through 986,197");

            Assert.Equal(InstructionAction.TurnOff, instruction.Action);
            Assert.Equal(expected, instruction.Rectangle);
        }

        [Fact]
        public void Toggle_Instruction_CreatedCorrectly()
        {
            var expected = new CoordinateRectangle(new Coordinate(322, 558), new Coordinate(977, 958));

            var instruction = Instruction.Create("toggle 322,558 through 977,958");

            Assert.Equal(InstructionAction.Toggle, instruction.Action);
            Assert.Equal(expected, instruction.Rectangle);
        }

        [Fact]
        public void TurnOn_Instruction_CreatedCorrectly()
        {
            var expected = new CoordinateRectangle(new Coordinate(809, 648), new Coordinate(826, 999));

            var instruction = Instruction.Create("turn on 809,648 through 826,999");

            Assert.Equal(InstructionAction.TurnOn, instruction.Action);
            Assert.Equal(expected, instruction.Rectangle);
        }
    }
}
