using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Util
{
    public interface ITextReader
    {
        string[] ReadAllString(string path);
        int[] ReadAllInt(string path);
    }
}
