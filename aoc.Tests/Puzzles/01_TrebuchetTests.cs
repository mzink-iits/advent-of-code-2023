using aoc.Console.Puzzles;

namespace aoc.Tests.Puzzles
{
    public class TrebuchetTests
    {
        [Theory]
        [InlineData("1abc2", 12)]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("treb7uchet", 77)]
        public void GetLineValuesShouldReturnSumOfFirstAndLastNumberOfString(string line, int sum)
        {
            // Act
            var actual = Trebuchet.GetLineValues(line);

            // Assert
            Assert.Equal(sum, actual);
        }

        [Fact]
        public void GetCalibrationValueShouldReturnSumOfAllLines()
        {
            // Arrange
            var expected = 142;
            var input = "1abc2\r\npqr3stu8vwx\r\na1b2c3d4e5f\r\ntreb7uchet\r\n";

            // Act
            var actual = Trebuchet.GetCalibrationValue(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("two1nine", 29)]
        [InlineData("eightwothree", 83)]
        [InlineData("abcone2threexyz", 13)]
        [InlineData("xtwone3four", 24)]
        [InlineData("4nineeightseven2", 42)]
        [InlineData("zoneight234", 14)]
        [InlineData("7pqrstsixteen", 76)]
        [InlineData("six4pqrstsixteen", 66)]
        public void GetLineValueShouldHandleWrittenNumbers(string line, int sum)
        {
            // Act
            var actual = Trebuchet.GetLineValues(line);

            // Assert
            Assert.Equal(sum, actual);
        }

        [Fact]
        public void GetCalibrationValueShouldReturnSumOfAllLinesWithStringValues()
        {
            // Arrange
            var expected = 281;
            var input = "two1nine\r\neightwothree\r\nabcone2threexyz\r\nxtwone3four\r\n4nineeightseven2\r\nzoneight234\r\n7pqrstsixteen";

            // Act
            var actual = Trebuchet.GetCalibrationValue(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
