using aoc.Console.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.Tests.Puzzles
{
    public class ParabolicReflectorDishTests
    {
        private const string dish = @"O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....";

        [Fact]
        public void TiltLeverShouldMoveAllRocksNorthAsFarAsPossible()
        {
            var expected = @"OOOO.#.O..
OO..#....#
OO..O##..O
O..#.OO...
........#.
..#....#.#
..O..#.O.O
..O.......
#....###..
#....#....";

            var result = string.Join(Environment.NewLine, ParabolicReflectorDish
                .TiltLever(dish.Split(Environment.NewLine)));

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("O.OO#....#", ".....##...", "O.OO#....#", ".....##...")]
        [InlineData("..#....#.#", "..O..#.O.O", "..#....#.#", "..O..#.O.O")]
        [InlineData(".....##...", "OO.#O....O", "OO..O##..O", "...#......")]
        public void MoveNorthShouldSwapRoundRocksIntoNorthernRowIfSpaceIsAvailable(string north, string south, string expectedNorth, string expectedSouth)
        {
            var result = ParabolicReflectorDish.MoveNorth(north, south);

            Assert.Equal(expectedNorth, result[0]);
            Assert.Equal(expectedSouth, result[1]);
        }

        [Theory]
        [InlineData("OOOOOOOO", 10, 80)]
        [InlineData("OOOOOOOO", 1, 8)]
        [InlineData("........", 10, 0)]
        [InlineData("O.OO#....#", 5, 15)]
        public void CalculateWeigthShouldSumRoundRocksAndApplyWeightFactor(string line, int weight, int expected)
        {
            var result = ParabolicReflectorDish.CalculateRowWeight(line, weight);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetTotalWeightShouldCalcluateSumOfRowWeights()
        {
            var result = ParabolicReflectorDish.GetTotalWeight(0, dish);
            Assert.Equal(136, result);
        }

        [Theory]
        [InlineData(1, ".....#....\r\n....#...O#\r\n...OO##...\r\n.OO#......\r\n.....OOO#.\r\n.O#...O#.#\r\n....O#....\r\n......OOOO\r\n#...O###..\r\n#..OO#....")]
        [InlineData(2, ".....#....\r\n....#...O#\r\n.....##...\r\n..O#......\r\n.....OOO#.\r\n.O#...O#.#\r\n....O#...O\r\n.......OOO\r\n#..OO###..\r\n#.OOO#...O")]
        [InlineData(3, ".....#....\r\n....#...O#\r\n.....##...\r\n..O#......\r\n.....OOO#.\r\n.O#...O#.#\r\n....O#...O\r\n.......OOO\r\n#...O###.O\r\n#.OOO#...O")]
        public void CycleShouldTurnInputDataAround(int numberOfCycles, string expectedResult)
        {
            var split = dish.Split("\r\n");
            var result = ParabolicReflectorDish.Cycle(split, numberOfCycles);

            Assert.Equal(expectedResult, string.Join("\r\n", result));
        }
    }
}
