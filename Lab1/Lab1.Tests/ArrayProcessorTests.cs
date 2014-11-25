using System;
using NUnit.Framework;

namespace Lab1.Tests
{
    [TestFixture]
    public class ArrayProcessorTests
    {
        private ArrayProcessor _processor;

        [Test]
        public void SortAndFilterWithNullArgument()
        {
            // arrange
            _processor = new ArrayProcessor();

            // act|assert
            Assert.Throws<ArgumentNullException>(() => _processor.SortAndFilter(null));
        }

        [Test]
        public void SortAndFilterWithEmptyArray()
        {
            // arrange
            _processor = new ArrayProcessor();
            
            // act|assert
            Assert.Throws<ArgumentException>(() => _processor.SortAndFilter(new double[] {}));
        }

        [Test]
        public void SortAndFilterWithGoodArray()
        {
            // arrange
            _processor = new ArrayProcessor();
            var src = new[] {1.2, 3.1, 4.4, 3.5, 2, 1.7};
            var expected = new[] {15.9, 4.4, 3.5, 3.1, 2.65, 2, 1.7, 1.2, -13.5};  
            // act
            var result = _processor.SortAndFilter(src);

            // assert
            CollectionAssert.AreEquivalent(expected, result, "Collection aren't equivalent");
            CollectionAssert.AreEqual(expected, result, "Collection aren't equl");
        }

        [Test]
        public void SortAndFilterWithRepeatingArray()
        {
            // arrange
            _processor = new ArrayProcessor();
            var src = new[] { 4.3, 5.6, 1.1, 4.3, 6.8 };
            var expected = new[] { 22.1, 6.8, 5.6, 4.42, 4.3, 1.1, -13.5 };
            
            // act
            var result = _processor.SortAndFilter(src);

            // assert
            CollectionAssert.AreEquivalent(expected, result, "Collection aren't equivalent");
            CollectionAssert.AreEqual(expected, result, "Collection aren't equl");
        }
    }
}