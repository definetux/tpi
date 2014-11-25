using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1.Tests
{
    [TestClass]
    public class StringFormatterTests
    {
        private StringFormatter _formatter;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StringFormatterTestWithNullArgument()
        {
            // arrange
            _formatter = new StringFormatter();
            
            // act|assert
            _formatter.SafeString(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StringFormatterTestWithEmptyString()
        {
            // arrange
            _formatter = new StringFormatter();

            // act|assert
            _formatter.SafeString(String.Empty);
        }

        [TestMethod]
        public void StringFormatterTestWithGoodString()
        {
            // arrange
            _formatter = new StringFormatter();
            const string src = "'This string better'";
            const string dst = "\"This string better\"";            
            // act
            var result = _formatter.SafeString(src);

            // assert
            StringAssert.Contains(dst, result);
        }
    }
}