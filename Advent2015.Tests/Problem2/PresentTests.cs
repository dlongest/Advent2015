using Advent2015.Core.Problem2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent2015.Tests.Problem2
{
    public class PresentTests
    {
        [Theory]
        [InlineData("2x3x4", 58)]
        [InlineData("1x1x10", 43)]
        public void WrappingPaperArea_ComputedCorrectly(string dimensions, int expected)
        {
            var present = new Present(dimensions);

            Assert.Equal(expected, present.WrappingPaperAreaNeeded());
        }

        [Theory]
        [InlineData("2x3x4", 34)]
        [InlineData("1x1x10", 14)]
        public void RibbonNeeded_ComputedCorrectly(string dimensions, int expected)
        {
            var present = new Present(dimensions);

            Assert.Equal(expected, present.RibbonNeeded());
        }
    }
}
