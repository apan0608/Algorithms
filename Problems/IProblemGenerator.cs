using Problems.Problem;

namespace Problems.ProblemGenerator {
    interface IProblemGenerator {
        IProblem GenerateProblem(string[] inputs);

    }
}