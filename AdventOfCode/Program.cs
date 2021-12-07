using AdventOfCode.Solver;
using AdventOfCode.Strategy;
using AdventOfCode.Task;
using AdventOfCode.Task.Day1;
using AdventOfCode.Task.Day2;
using AdventOfCode.Task.Day3;
using AdventOfCode.Task.Day4;
using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            ITaskSolverStrategy strat = new TaskSolverStrategy();
            // ITask day1task1 = new Day1Task1();
            // ITask day1task2 = new Day1Task2();
            // ITask day2task1 = new Day2Task1();
            // ITask day2task2 = new Day2Task2();
            // ITask day3task1 = new Day3Task1();
            // ITask day3task2 = new Day3Task2();
            // ITask day4task1 = new Day4Task1();
            // ITask day4task2 = new Day4Task2();
            ITask day5task1 = new Day5Task1();

            //var day1answer1 = strat.solve(day1task1);
            //var day1answer2 = strat.solve(day1task2);
            //var day2answer1 = strat.solve(day2task1);
            //var day2answer2 = strat.solve(day2task2);
            //var day3answer1 = strat.solve(day3task1);
            //var day3answer2 = strat.solve(day3task2);
            //var day4answer1 = strat.solve(day4task1);
            var day5answer1 = strat.solve(day5task1);

            Console.WriteLine(day5answer1);
            Console.ReadKey();
        }
    }
}
