using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode.Task.Day4
{
    public class Day6Task2 : ITask
    {
        private readonly List<int> _input;
        public string Result { get; set; }

        public Day6Task2()
        {
            ITextReader textReader = new TextReader();
            _input = Array.ConvertAll(textReader.ReadAllString("./Input/day6.txt")[0].Split(','), s => int.Parse(s)).ToList();
        }

        public void Solve()
        {
            BigInteger[] buckets = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            _input.ForEach(fish => buckets[fish] = buckets[fish] + 1);

            for (var i = 0; i < 256; i++)
            {
                BigInteger newFish = buckets[0];
                for (var j = 0; j < 8; j++)
                {
                    buckets[j] = buckets[j + 1];
                }
                buckets[8] = newFish;
                buckets[6] = buckets[6] + newFish;
            }

            Result = buckets.Aggregate(BigInteger.Add).ToString();
        }
    }
}
