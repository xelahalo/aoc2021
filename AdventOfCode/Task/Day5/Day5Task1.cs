using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Task.Day4
{
    public class Day5Task1 : ITask
    {
        private readonly string[] _input;
        private readonly int[][] _mineField = new int[1000][];

        public string Result { get; set; }

        public Day5Task1()
        {
            ITextReader textReader = new TextReader();
            _input = textReader.ReadAllString("./Input/day5.txt");
            Init();
        }

        public void Solve()
        {
            var result = 0;
            for (var i = 0; i < _input.Length; i++)
            {
                int x1, x2, y1, y2;
                var xy = _input[i].Split("->", StringSplitOptions.RemoveEmptyEntries);

                x1 = int.Parse(xy[0].Split(',')[0]);
                y1 = int.Parse(xy[0].Split(',')[1]);
                x2 = int.Parse(xy[1].Split(',')[0]);
                y2 = int.Parse(xy[1].Split(',')[1]);

                // for task1
                // if (x1 != x2 && y1 != y2) continue;

                int mx = 0, my = 0;
                if (x1 < x2) mx = 1;
                if (x1 > x2) mx = -1;
                if (y1 < y2) my = 1;
                if (y1 > y2) my = -1;

                while (Math.Abs(x1 - x2) > 0 || Math.Abs(y1 - y2) > 0)
                {
                    Draw(x1, y1, mx, my);
                    x1 += mx;
                    y1 += my;
                }

                Draw(x1, y1, mx, my);
            }

            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    if (_mineField[i][j] > 1) result++;
                }
            }

            Result = result.ToString();
        }

        private void Draw(int x, int y, int mx, int my)
        {
            if (mx == 0)
            {
                int c = x - y * my;
                x = my * y + c;
                _mineField[x][y] = _mineField[x][y] + 1;
            }
            else
            {
                int c = y - x * mx;
                y = mx * x + c;
                _mineField[x][y] = _mineField[x][y] + 1;
            }
        }

        private void Init()
        {
            for (var i = 0; i < 1000; i++)
            {
                _mineField[i] = new int[1000];
                for (var j = 0; j < 1000; j++)
                {
                    _mineField[i][j] = 0;
                }
            }
        }
    }
}
