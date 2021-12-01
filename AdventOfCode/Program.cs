using AdventOfCode.Solver;
using AdventOfCode.Strategy;
using AdventOfCode.Task;
using AdventOfCode.Task.Day1;
using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            ITaskSolverStrategy strat = new TaskSolverStrategy();
            ITask day1task1 = new Day1Task1();
            ITask day1task2 = new Day1Task2();

            //var day1answer1 = strat.solve(day1task1);
            var day1answer2 = strat.solve(day1task2);

            Console.WriteLine(day1answer2);
            Console.ReadKey();
        }
    }
}
