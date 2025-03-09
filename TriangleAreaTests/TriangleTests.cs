using System;
using Xunit;
using TriangleAreaApp;

namespace TriangleAreaTests
{
    public class TriangleTests
    {
        [Fact]
        public void CalculateArea_ValidSides_ReturnsCorrectArea()
        {
            double area = Triangle.CalculateArea(10, 10, 10);
            Assert.Equal(43.301, area, 3);
        }

        [Fact]
        public void CalculateArea_InvalidSides_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Triangle.CalculateArea(1, 2, 10));
        }

        [Fact]
        public void CalculateArea_ValidCoordinates_ReturnsCorrectArea()
        {
            double area = Triangle.CalculateArea((0, 0), (0, 4), (3, 0));
            Assert.Equal(6, area, 3);
        }
    }
}
