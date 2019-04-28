using System;
using System.Collections.Generic;
using Problems.ProblemGenerator;
using Problems.Problem;
using Problems.Solver;

namespace Problems
{
    class Program
    {
         // test id {23280666343178} for amazon coding assignment
        // AMCAT ID 23280666343178
        static void Main(string[] args)
        {
            //int[] files = new int[4] {20, 4, 8, 2};
           // Test();
           SolveFindingPair();
        }

        public static void SolveFindingPair() {
            // using console input to get the probelm 
            var generator = new FindingPairsGenerator();
            var solver = new FindingPairsSolver();
            // prpvide an array of problem
           // FindingPairs problem = generator.GenerateProblem(new string[]{}) as FindingPairs;
            //List<int> solution = solver.SolveProblem(problem);

            int[] arr = new int[] {1, 3, -2, 0, -1, 3, -10, 2, 8};
            var sorted = solver.test(arr);
            // display solution
            display(sorted);
        }

        private static void display(int[] arr) {
            foreach(var item in arr) {
                Console.Write(item + ", ");
            }
        }

       

    }
}
