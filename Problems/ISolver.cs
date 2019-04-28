using System.Collections.Generic;
using Problems.Problem;

namespace Problems.Solver {
    interface ISolver<T> {
        List<T> SolveProblem(IProblem problem);
    }
}