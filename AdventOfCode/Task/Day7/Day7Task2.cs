using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode.Task.Day4
{
    public class Day7Task2 : ITask
    {
        private readonly List<int> _input;
        public string Result { get; set; }

        public Day7Task2()
        {
            ITextReader textReader = new TextReader();
            _input = Array.ConvertAll(textReader.ReadAllString("./Input/day7.txt")[0].Split(','), s => int.Parse(s)).ToList();
        }

        public void Solve()
        {
            var poss = new List<int>();
            int max = _input.Max();

            for (var pos = 0; pos < max; pos++)
            {
                int sum = 0;
                _input.ForEach(crab => sum += (1 + Math.Abs(crab - pos)) * Math.Abs(crab - pos) / 2);
                poss.Add(sum);
            }

            Result = poss.Min().ToString();
        }
    }
}
