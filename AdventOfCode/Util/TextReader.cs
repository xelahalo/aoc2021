using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Util
{
    public class TextReader : ITextReader
    {
        public int[] ReadAllInt(string path)
        {
            return Array.ConvertAll(ReadAllString(path), s => int.Parse(s));
        }

        public string[] ReadAllString(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
