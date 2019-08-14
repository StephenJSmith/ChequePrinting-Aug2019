using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChequePrinting.Tests
{
    [TestClass]
    public class NumberSpellerTests
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
        [DataRow(101, "one hundred and one")]
        [DataRow(202, "two hundred and two")]
        [DataRow(310, "three hundred and ten")]
        [DataRow(411, "four hundred and eleven")]
        [DataRow(521, "five hundred and twenty-one")]
        [DataRow(644, "six hundred and forty-four")]
        [DataRow(765, "seven hundred and sixty-five")]
        [DataRow(999, "nine hundred and ninety-nine")]
        public void GetSpelt_NumberLessThan1000_SpeltInWords(int input, string expected)
        {
            // Arrange
            var sut = new NumberSpeller(new Thousands(new Units()));

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1000, "one thousand")]
        [DataRow(1001, "one thousand and one")]
        [DataRow(1087, "one thousand and eighty-seven")]
        [DataRow(1100, "one thousand, one hundred")]
        [DataRow(3199, "three thousand, one hundred and ninety-nine")]
        [DataRow(57000, "fifty-seven thousand")]
        [DataRow(123456, "one hundred and twenty-three thousand, four hundred and fifty-six")]
        [DataRow(123056, "one hundred and twenty-three thousand and fifty-six")]
        public void GetSpelt_NumbersInThousands_SpeltInWords(int input, string expected)
        {
            // Arrange
            var sut = new NumberSpeller(new Thousands(new Units()));

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1000000, "one million")]
        [DataRow(1000001, "one million and one")]
        [DataRow(1000087, "one million and eighty-seven")]
        [DataRow(1000100, "one million, one hundred")]
        [DataRow(123456000, "one hundred and twenty-three million, four hundred and fifty-six thousand")]
        [DataRow(52025025, "fifty-two million, twenty-five thousand and twenty-five")]
        public void GetSpelt_NumberInMillions_SpeltInWords(int input, string expected)
        {
            // Arrange
            var sut = new NumberSpeller(new Thousands(new Units()));

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1000000000, "one billion")]
        [DataRow(1000000001, "one billion and one")]
        [DataRow(1000000087, "one billion and eighty-seven")]
        [DataRow(1000000100, "one billion, one hundred")]
        [DataRow(1123456000, "one billion, one hundred and twenty-three million, four hundred and fifty-six thousand")]
        [DataRow(1052025025, "one billion, fifty-two million, twenty-five thousand and twenty-five")]
        public void GetSpelt_NumberInBillions_SpeltInWords(int input, string expected)
        {
            // Arrange
            var sut = new NumberSpeller(new Thousands(new Units()));

            // Act
            var actual = sut.GetSpelt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
