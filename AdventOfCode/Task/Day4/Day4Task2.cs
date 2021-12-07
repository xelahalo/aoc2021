using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Task.Day4
{
    public class Day4Task2: ITask
    {
        private readonly string[] _input;
        private readonly List<Board> _boards = new List<Board>();
        private int[] _bingoNumbers;

        public string Result { get; set; }

        public Day4Task2()
        {
            ITextReader textReader = new TextReader();
            _input = textReader.ReadAllString("./Input/day4.txt");
            ProcessInput();
        }

        public void Solve()
        {
            List<Board> wonBoards = new List<Board>();

            foreach (int i in _bingoNumbers)
            {
                foreach (Board board in _boards)
                {
                    if (board.NewNumber(i))
                    {
                        wonBoards.Add(board);
                    }
                }

                if (_boards.Count == wonBoards.Count)
                {
                    Result = wonBoards.Last().GetResult(i).ToString();
                    break;
                }
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
            private bool _won;

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
                if(_won)
                {
                    return false;
                }

                for (int i = 0; i < 5; i++)
                {
                    int rowWon = 0;
                    int colWon = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        rowWon += _drawnNumbers.Contains(_board[i][j]) ? 1 : 0;
                        colWon += _drawnNumbers.Contains(_board[j][i]) ? 1 : 0;
                    }

                    if (rowWon == 5 || colWon == 5)
                    {
                        _won = true;
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
