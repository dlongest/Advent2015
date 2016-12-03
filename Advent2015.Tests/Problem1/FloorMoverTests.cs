using Advent2015.Core.Problem1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent2015.Tests.Problem1
{
    public class FloorMoverTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("(", 1)]
        [InlineData("((", 2)]
        [InlineData("(((", 3)]
        [InlineData("((((", 4)]
        [InlineData("(((((", 5)]
        [InlineData("((((((", 6)]
        [InlineData(")", -1)]
        [InlineData("))", -2)]
        [InlineData(")))", -3)]
        [InlineData("))))", -4)]
        [InlineData(")))))", -5)]
        [InlineData("))))))", -6)]
        public void SingleTokens_Move_InCorrectDirection(string instructions, int expected)
        {
            var sut = new FloorMover();

            Assert.Equal(expected, sut.Move(instructions));
        }

        [Theory]

        [InlineData("(())", 0)]
        [InlineData("()()", 0)]
        [InlineData("(((", 3)]
        [InlineData("(()(()(", 3)]
        [InlineData("))(((((", 3)]
        [InlineData("())", -1)]
        [InlineData("))(", -1)]
        [InlineData(")))", -3)]
        [InlineData(")())())", -3)]
        public void BothTokenTypes_AreCountedCorrectly(string instructions, int expected)
        {
            var sut = new FloorMover();

            Assert.Equal(expected, sut.Move(instructions));
        }

        [Theory]        
        [InlineData(")", -1, 1)]
        [InlineData("())", -1, 3)]
        [InlineData("((()", -1, null)]
        public void FirstPosition_ReturnsIndexOfFirstTimeItReachesTarget(string instructions, int targetFloor, int? expected)
        {
            var sut = new FloorMover();

            Assert.Equal(expected, sut.FirstPosition(instructions, targetFloor));
        }
    }
}
