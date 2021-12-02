using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Task.Day2
{
    public class Day2Task2: ITask
    {
        private readonly List<KeyValuePair<string, int>> _input = new List<KeyValuePair<string, int>>();

        private int _depth;
        private int _horizontal;
        private int _aim;

        public string Result { get; set; }

        public Day2Task2()
        {
            ITextReader textReader = new TextReader();
            var raw = textReader.ReadAllString("../../../Input/day2.txt");
            ProcessInput(raw);
        }

        public void Solve()
        {
            foreach (var pair in _input)
            {
                switch (pair.Key)
                {
                    case "forward":
                        _horizontal += pair.Value;
                        _depth += _aim * pair.Value;
                        break;
                    case "down":
                        _aim += pair.Value;
                        break;
                    case "up":
                        _aim -= pair.Value;
                        break;
                }
            }

            Result = (_depth * _horizontal).ToString();
        }

        private void ProcessInput(string[] raw)
        {
            foreach (var pair in raw)
            {
                var split = pair.Split(' ');
                _input.Add(new KeyValuePair<string, int>(split[0], int.Parse(split[1])));
            }
        }
    }
}
