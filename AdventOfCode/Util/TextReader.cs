using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Util
{
    public class TextReader : ITextReader
    {
        public string[] ReadLineByLine(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
