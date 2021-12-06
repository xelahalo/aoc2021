using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Task.Day4
{
    public class Day4Task1: ITask
    {
        private readonly string[] _input;
        private readonly List<Board> _boards = new List<Board>();
        private int[] _bingoNumbers;

        public string Result { get; set; }

        public Day4Task1()
        {
            ITextReader textReader = new TextReader();
            _input = textReader.ReadAllString("../../../Input/day4.txt");
            ProcessInput();
        }

        public void Solve()
        {
            foreach(int i in _bingoNumbers)
            {
                foreach(Board board in _boards)
                {
                    if(board.NewNumber(i))
                    {
                        Result = board.GetResult(i).ToString();
                        break;
                    }
                }

                if (!String.IsNullOrEmpty(Result)) break;
            }
        }

        private void ProcessInput()
        {
            _bingoNumbers = Array.ConvertAll(_input[0].Split(','), s => int.Parse(s));

            int[][] board = new int[5][];
            for (int i = 2, j = 0; i < _input.Length; i++)
            {
                if (String.IsNullOrEmpty(_input[i]) && i != 2)
                {
                    _boards.Add(new Board(board));
                    board = new int[5][];
                    j = 0;
                    continue;
                }

                board[j] = Array.ConvertAll(_input[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
                j++;
            }
        }

        private class Board
        {
            private readonly int[][] _board;
            private readonly List<int> _drawnNumbers = new List<int>();

            public Board(int[][] parsedBoard)
            {
                _board = parsedBoard;
            }

            public bool NewNumber(int number)
            {
                _drawnNumbers.Add(number);
                return CheckIfWon();
            }

            public int GetResult(int latest)
            {
                return latest * _board.SelectMany(number => number).Except(_drawnNumbers).Sum();
            }

            private bool CheckIfWon()
            {
                for(int i = 0; i < 5; i++)
                {
                    int rowWon = 0;
                    int colWon = 0;
                    for(int j = 0; j < 5; j++)
                    {
                        rowWon += _drawnNumbers.Contains(_board[i][j]) ? 1 : 0;
                        colWon += _drawnNumbers.Contains(_board[j][i]) ? 1 : 0;
                    }

                    if(rowWon == 5 || colWon == 5)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
