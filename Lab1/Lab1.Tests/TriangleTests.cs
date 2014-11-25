

using System;
using NUnit.Framework;

namespace Lab1.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        private Triangle _triangle;

        [Test]
        [TestCase(-1, 1, 1)]
        [TestCase(2, -1, 3)]
        [TestCase(1, 3, -2)]
        public void TestSetSides_Argument_Less_Zerro(double a, double b, double c)
        {
            // arrange
            _triangle = new Triangle();

            // act/assert
            Assert.Throws<FormatException>(() => _triangle.SetSides(a, b, c));
        }

        [Test]
        [TestCase(4, 1, 2)]
        [TestCase(1, 6, 3)]
        [TestCase(5, 3, 2)]
        public void TestSetSides_Side_bigger_Than_Others(double a, double b, double c)
        {
            // arrange
            _triangle = new Triangle();

            // act/assert
            Assert.Throws<ArgumentException>(() => _triangle.SetSides(a, b, c));
        }

        [Test]
        [TestCase(2, 2, 3, 1.98)]
        [TestCase(4, 2, 5, 3.8)]
        [TestCase(1.2, 2.3, 3.2, 1.07)]
        public void TestArea(double a, double b, double c, double trueResult)
        {
            // arrange
            _triangle = new Triangle();
            _triangle.SetSides(a, b, c);
            // act
            var result = _triangle.Area();
            // assert

            Assert.That(Math.Round(result, 2), Is.EqualTo(trueResult));
        }
    }
}
