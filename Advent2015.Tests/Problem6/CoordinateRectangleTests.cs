using Advent2015.Core.Problem6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent2015.Tests.Problem6
{
    public class CoordinateRectangleTests
    {
        [Fact]
        public void CorrectlyChooses_CornerAndOppositeCorner_WhenOneIsRightAndUp()
        {
            var rectangle = new CoordinateRectangle(Coordinate.Origin, new Coordinate(2, 2));

            Assert.Equal(rectangle.Corner, Coordinate.Origin);
            Assert.Equal(rectangle.OppositeCorner, new Coordinate(2, 2));
        }

        [Fact]
        public void CorrectlyChooses_CornerAndOppositeCorner_WhenOneIsRightAndDown()
        {
            var rectangle = new CoordinateRectangle(new Coordinate(2, 2), new Coordinate(3, 1));

            Assert.Equal(rectangle.Corner, new Coordinate(2, 2));
            Assert.Equal(rectangle.OppositeCorner, new Coordinate(3, 1));
        }

        [Fact]
        public void CorrectlyChooses_CornerAndOppositeCorner_WhenRightAndUp_IsFlipped()
        {
            var rectangle = new CoordinateRectangle(new Coordinate(2, 2), Coordinate.Origin);

            Assert.Equal(rectangle.Corner, Coordinate.Origin);
            Assert.Equal(rectangle.OppositeCorner, new Coordinate(2, 2));
        }

        [Fact]
        public void CorrectlyChooses_CornerAndOppositeCorner_WheRightAndDown_IsFlipped()
        {
            var rectangle = new CoordinateRectangle(new Coordinate(3, 1), new Coordinate(2, 2));

            Assert.Equal(rectangle.Corner, new Coordinate(2, 2));
            Assert.Equal(rectangle.OppositeCorner, new Coordinate(3, 1));
        }

        [Fact]
        public void InBox_SelectsAllCoordinates_ForBox()
        {
            var expected = new[] { Coordinate.Origin, new Coordinate(0, 1), new Coordinate(0, 2),
                                    new Coordinate(1, 0), new Coordinate(1, 1), new Coordinate(1, 2),
                                    new Coordinate(2, 0), new Coordinate (2, 1), new Coordinate(2, 2) };

            var rectangle = new CoordinateRectangle(Coordinate.Origin, new Coordinate(2, 2));

            Assert.Equal(expected, rectangle.InBox());
        }
    }
}
