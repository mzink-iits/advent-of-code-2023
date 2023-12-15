// See https://aka.ms/new-console-template for more information

using aoc.Console.Puzzles;

//var calibrationValue = Trebuchet.GetCalibrationValue();
//Console.WriteLine($"Calibration value for day #1 is {calibrationValue}");
//var gameIdSum = CubeConundrum.GetIdSumResult(null, 12, 14, 13);
//Console.WriteLine($"Sum of valid game ids is {gameIdSum}");
//var powers = CubeConundrum.GetPowers();
//Console.WriteLine($"Sum of powers is {powers}");
var dishWeight = ParabolicReflectorDish.GetTotalWeight(1000000000);
Console.WriteLine($"Total stress on northern support beams is {dishWeight}");
