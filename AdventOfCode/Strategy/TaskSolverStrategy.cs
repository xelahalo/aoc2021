using AdventOfCode.Solver;
using AdventOfCode.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Strategy
{
    public class TaskSolverStrategy : ITaskSolverStrategy
    {
        public string solve(ITask task)
        {
            task.solve();
            return task.Result;
        }
    }
}
