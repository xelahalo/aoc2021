using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Task.Day4
{
    public class Day6Task1 : ITask
    {
        private readonly List<int> _input;
        public string Result { get; set; }

        public Day6Task1()
        {
            ITextReader textReader = new TextReader();
            _input = Array.ConvertAll(textReader.ReadAllString("./Input/day6.txt")[0].Split(','), s => int.Parse(s)).ToList();
        }

        public void Solve()
        {
            for (int i = 0; i < 256; i++)
            {
                int max = _input.Count;
                for (int j = 0; j < max; j++)
                {
                    if (_input[j] == 0)
                    {
                        _input.Add(8);
                        _input[j] = 6;
                    }
                    else
                    {
                        _input[j] = _input[j] - 1;
                    }
                }
            }

            Result = _input.Count.ToString();
        }
    }
}
