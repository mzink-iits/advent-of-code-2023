using aoc.Console.Puzzles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.Tests.Puzzles
{
    public class CubeConundrumTests
    {
        public class TestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _games =
            [
                [
                    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                    new Game
                    {
                        Id = 1,
                        Draws = [
                            new Draw { Blue = 3, Red = 4 },
                            new Draw { Red = 1, Green = 2, Blue = 6 },
                            new Draw { Green = 2 }
                        ]
                    }
                ],
                [
                    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                    new Game
                    {
                        Id = 2,
                        Draws = [
                            new Draw { Blue = 1, Green = 2 },
                            new Draw { Red = 1, Green = 3, Blue = 4 },
                            new Draw { Green = 1, Blue = 1 }
                        ]
                    }
                ]
            ];

            public IEnumerator<object[]> GetEnumerator()
                => _games.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 3)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 4)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5)]
        [InlineData("Game 105: 2 green", 105)]
        public void LoadDataShouldExtractGameIdFromInput(string line, int expectedId)
        {
            var result = CubeConundrum.LoadData(line);

            Assert.Equal(expectedId, result.Id);
        }

        [Theory]
        [InlineData("3 blue, 4 red", 4, 3, 0)]
        [InlineData("1 red, 2 green, 6 blue", 1, 6, 2)]
        [InlineData("2 green", 0, 0, 2)]
        [InlineData("", 0, 0, 0)]
        public void GetItemsShouldLoadDataFromDraw(string draw, int red, int blue, int green)
        {
            var result = CubeConundrum.GetItems(draw);

            Assert.Equal(red, result["red"]);
            Assert.Equal(green, result["green"]);
            Assert.Equal(blue, result["blue"]);
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void Test(string line, Game expectedResult)
        {
            var game = CubeConundrum.LoadData(line);

            Assert.Equal(expectedResult.Id, game.Id);
            Assert.Equal(expectedResult.Draws.Count, game.Draws.Count);
            for (var i = 0; i < game.Draws.Count; i++)
            {
                var expected = expectedResult.Draws[i];
                var actual = game.Draws[i];
                Assert.Equal(expected.Red, actual.Red);
                Assert.Equal(expected.Blue, actual.Blue);
                Assert.Equal(expected.Green, actual.Green);
            }
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
        public void GetPowerShouldMultiplyMinOfEachColor(string line, int expectedResult)
        {
            var power = CubeConundrum.GetPowers(line);

            Assert.Equal(expectedResult, power);
        }
    }
}
