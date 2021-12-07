using AdventOfCode.Util;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Task.Day3
{
    public class Day3Task1 : ITask
    {
        private readonly char[][] _input;

        private int _gamma;
        private int _eps;

        public string Result { get; set; }

        public Day3Task1()
        {
            ITextReader textReader = new TextReader();
            _input = textReader.ReadAllCharArray("./Input/day3.txt");
        }

        public void Solve()
        {
            var intArray = new int[_input.Length][];

            for (int i = 0; i < _input.Length; i++)
            {
                intArray[i] = new int[_input[i].Length];
                for (int j = 0; j < _input[0].Length; j++)
                {
                    intArray[i][j] = Convert.ToInt32(char.GetNumericValue(_input[i][j]));
                }
            }

            for (int i = 0; i < intArray[0].Length; i++)
            {
                _eps <<= 1;
                _gamma <<= 1;

                var least = Enumerable.Range(0, intArray.Length)
                .Select(x => intArray[x][i]).GroupBy(bin => bin).OrderBy(gp => gp.Count())
                .Take(1).Select(grp => grp.Key).ToList()[0];

                var most = 1 - least;

                _eps |= least;
                _gamma |= most;
            }

            Result = (_gamma * _eps).ToString();
        }
    }
}
