using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChequePrinting.Tests
{
    [TestClass]
    public class ThousandsTests
    {
        [TestMethod]
        [DataRow(0, "zero")]
        [DataRow(1, "one")]
        [DataRow(2, "two")]
        [DataRow(3, "three")]
        [DataRow(9, "nine")]
        [DataRow(10, "ten")]
        [DataRow(13, "thirteen")]
        [DataRow(19, "nineteen")]
        [DataRow(20, "twenty")]
        [DataRow(50, "fifty")]
        [DataRow(90, "ninety")]
        [DataRow(100, "one hundred")]
        [DataRow(700, "seven hundred")]
        [DataRow(900, "nine hundred")]
        public void GetSpelt_NumbersInUnitsDictonary_NumberSpeltInWords(int input, string expected)
        {
            // Arrange
            var sut = new Thousands(new Units());

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(21, "twenty-one")]
        [DataRow(29, "twenty-nine")]
        [DataRow(32, "thirty-two")]
        [DataRow(38, "thirty-eight")]
        [DataRow(43, "forty-three")]
        [DataRow(47, "forty-seven")]
        [DataRow(54, "fifty-four")]
        [DataRow(65, "sixty-five")]
        [DataRow(76, "seventy-six")]
        [DataRow(87, "eighty-seven")]
        [DataRow(99, "ninety-nine")]
        public void GetSpelt_NumbersLessThanOneHundred_SpeltInWords(int input, string expected)
        {
            // Arrange
            var sut = new Thousands(new Units());

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(101, "one hundred and one")]
        [DataRow(202, "two hundred and two")]
        [DataRow(310, "three hundred and ten")]
        [DataRow(411, "four hundred and eleven")]
        [DataRow(521, "five hundred and twenty-one")]
        [DataRow(644, "six hundred and forty-four")]
        [DataRow(765, "seven hundred and sixty-five")]
        [DataRow(999, "nine hundred and ninety-nine")]
        public void GetSpelt_NumberGreaterThanOneHundred_SpeltInWords(int input, string expected)
        {
            // Arrange
            var sut = new Thousands(new Units());

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(1000)]
        public void GetSpelt_InputOutsideOfRange_RangeException(int input)
        {
            // Arrange
            var sut = new Thousands(new Units());

            // Act
            try
            {
                sut.GetSpelt(input);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            Assert.Fail();
        }
    }
}
