using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChequePrinting.Tests
{
    [TestClass]
    public class CurrencySpellerTests
    {
        [TestMethod]
        [DataRow("0.00", "zero dollars and zero cents")]
        [DataRow("1.01", "one dollar and one cent")]
        [DataRow("1.0", "one dollar and zero cents")]
        [DataRow("0.85", "zero dollars and eighty-five cents")]
        [DataRow("1034", "one thousand and thirty-four dollars and zero cents")]
        [DataRow("123456789.12", "one hundred and twenty-three million, four hundred and fifty-six thousand, seven hundred and eighty-nine dollars and twelve cents")]
        public void GetSpelt_WithDollarsAndCents(string stringInput, string expected)
        {
            // Arrange
            var input = decimal.Parse(stringInput);
            var sut = new CurrencySpeller(new NumberSpeller(new Thousands(new Units())));

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
