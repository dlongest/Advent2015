using Advent2015.Core.Problem3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Collections;

namespace Advent2015.Tests.Problem3
{
    public class SantaTests
    {
        [Theory]
        [ClassData(typeof(SantaTestCases))]
        public void ElfMovesThroughCorrectCoordinates(string moves, Coordinate[] expected)
        {
            var elf = new Santa();

            var actual = elf.HousesVisited(moves);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UniqueHouses_ComputedCorrectly()
        {
            var elf = new Santa();

            var houses = elf.HousesVisited("^v^v^v^v^v");

            Assert.Equal(2, houses.Distinct().Count());
        }
        
        
        private class SantaTestCases : IEnumerable<object[]>
        {
            private IList<object[]> data = new List<object[]>();

            public SantaTestCases()
            {
                this.data.Add(new object[] { "^", new[] { Coordinate.Origin, Coordinate.Origin.Up() } });
                this.data.Add(new object[] { "^>", new[] { Coordinate.Origin, Coordinate.Origin.Up(), Coordinate.Origin.Up().Right() } });
                this.data.Add(new object[] { "^>v<",
                                new[] { Coordinate.Origin,
                                        Coordinate.Origin.Up(),
                                        Coordinate.Origin.Up().Right(),
                                        Coordinate.Origin.Up().Right().Down(),
                                        Coordinate.Origin.Up().Right().Down().Left()}
                            });
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                return this.data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}
