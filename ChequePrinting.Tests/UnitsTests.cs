using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChequePrinting.Tests
{
    [TestClass]
    public class UnitsTests
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
        public void GetSpelt_MatchingInteger_SpeltInWords(int input, string expected)
        {
            // Arrange
            var sut = new Units();

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSpelt_NonMatchingInteger_EmptyString()
        {
            // Arrange
            var sut = new Units();
            const int input = 99;
           var expected = string.Empty;

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LanguageSpecificConstants()
        {
            // Arrange
            var sut = new Units();

            // Act

            // Assert
            Assert.AreEqual("and", sut.And);
            Assert.AreEqual(",", sut.Comma);
            Assert.AreEqual("thousand", sut.Thousand);
            Assert.AreEqual("million", sut.Million);
            Assert.AreEqual("billion", sut.Billion);
        }
    }
}
