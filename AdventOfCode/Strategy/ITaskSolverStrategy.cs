using AdventOfCode.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solver
{
    public interface ITaskSolverStrategy
    {
        string solve(ITask task);
    }
}
