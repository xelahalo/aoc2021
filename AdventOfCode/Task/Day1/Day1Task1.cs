using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Task.Day1
{
    public class Day1Task1 : ITask
    {
        private readonly int[] _input;
        public string Result { get; set; }

        public Day1Task1()
        {
            ITextReader textReader = new TextReader();
            _input = textReader.ReadAllInt("./Input/day1.txt");
        }

        public void Solve()
        {
            int i,c = 0;

            for(i = 1; i < _input.Length; i++)
            {
                if (_input[i - 1] < _input[i]) c++;
            }

            Result = c.ToString();
        }
    }
}
