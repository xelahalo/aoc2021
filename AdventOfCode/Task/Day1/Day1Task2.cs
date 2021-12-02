using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Task.Day1
{
    public class Day1Task2 : ITask
    {
        private readonly int[] _input;
        public string Result { get; set; }

        public Day1Task2()
        {
            ITextReader textReader = new TextReader();
            _input = textReader.ReadAllInt("../../../Input/day1.txt");
        }

        public void Solve()
        {
            int i, previous = -1, c = 0;

            for (i = 0; i < _input.Length; i++)
            {
                if (i >= _input.Length - 2) break;

                var sum = _input[i] + _input[i + 1] + _input[i + 2];

                if (previous != -1 && sum > previous) c++;
              
                previous = sum;
            }

            Result = c.ToString();
        }
    }
}
