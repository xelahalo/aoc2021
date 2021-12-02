using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Task
{
    public interface ITask
    {
        string Result { get; set; }
        void Solve();
    }
}
