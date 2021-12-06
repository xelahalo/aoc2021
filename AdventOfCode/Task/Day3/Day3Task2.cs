using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Task.Day3
{
    public class Day3Task2: ITask
    {
        private readonly char[][] _input;

        private int _o2;
        private int _co2;

        public string Result { get; set; }

        public Day3Task2()
        {
            ITextReader textReader = new TextReader();
            _input = textReader.ReadAllCharArray("../../../Input/day3.txt");
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

            var o2Rating = intArray.ToList();
            var co2Rating = o2Rating.Select(x => x).ToList();

            for (int i = 0; i < intArray[0].Length; i++)
            {
                var leastO = o2Rating.Select(x => x[i]).GroupBy(bin => bin).OrderBy(gp => gp.Count()).Take(1).Select(grp => grp.Key).ToList()[0];
                var mostO = 1- leastO;

                var leastCo = co2Rating.Select(x => x[i]).GroupBy(bin => bin).OrderBy(gp => gp.Count()).Take(1).Select(grp => grp.Key).ToList()[0];
                var mostCo = 1 - leastCo;

                if(o2Rating.Where(o => o[i] == mostO).ToList().Count == o2Rating.Where(o => o[i] == leastO).ToList().Count)
                {
                    mostO = 1;
                }

                if(co2Rating.Where(o => o[i] == mostCo).ToList().Count == co2Rating.Where(o => o[i] == leastCo).ToList().Count)
                {
                    leastCo = 0;
                }

                if(_o2 == 0)
                {
                    o2Rating = o2Rating.Where(o => o[i] == mostO).ToList();
                    
                    if(o2Rating.Count == 1)
                    {
                        foreach (int bit in o2Rating.First())
                        {
                            _o2 <<= 1;
                            _o2 |= bit;
                        }
                    }
                } 

                if(_co2 == 0)
                {
                    co2Rating = co2Rating.Where(co => co[i] == leastCo).ToList();

                    if(co2Rating.Count == 1)
                    {
                        foreach (int bit in co2Rating.First())
                        {
                            _co2 <<= 1;
                            _co2 |= bit;
                        }
                    }
                }
            }

            Result = (_o2 * _co2).ToString();
        }
    }
}
