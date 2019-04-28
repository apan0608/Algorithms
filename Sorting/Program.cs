using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //SolveWithCountingSort();
            //SolveWithInsertionSort();  
            string test = "170 45 75 90 802 24 2 66"; //"0 0 2 9 4 5 2 4 9 8 3 1 0";
            int[] testCase = GetTest(test, 8);
            Display(testCase);

            // replace the sort here with other sort algorithms
            ISort sort = new RadixSort();
            int[] result = sort.Sort(testCase);
            Display(result);
        }

        // there is another implementation of counting sort that caters for negative numbers in problems 
        private static void SolveWithCountingSort() {
            string test = "0 0 2 9 4 5 2 4 9 8 3 1 0";
            int[] testCase = GetTest(test, 13);
            Display(testCase);

            ISort sort = new CountingSort();
            int[] result = sort.Sort(testCase);
            Display(result);
        }

        private static void SolveWithInsertionSort() {
            int length = 100;
            string test = "100 99 98 97 96 95 94 93 92 91 90 89 88 87 86 85 84 83 82 81 80 79 78 77 76 75 74 73 72 71 70 69 68 67 66 65 64 63 62 61 60 59 58 57 56 55 54 53 52 51 50 49 48 47 46 45 44 43 42 41 40 39 38 37 36 35 34 33 32 31 30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1";
                
            int[] testCase = new int[length];
            string[] testInStr = test.Split(' ');
            for (int i = 0; i < length; i++) {
                testCase[i] = int.Parse(testInStr[i]);         
            }
            ISort sort = new InsertionSort();
            int[] result = sort.Sort(testCase);
            Display(result);
        }

        private static int[] GetTest(string test, int length) {            
            int[] testCase = new int[length];
            string[] testInStr = test.Split(' ');
            for (int i = 0; i < length; i++) {
                testCase[i] = int.Parse(testInStr[i]);         
            }
            return testCase;
        }
        private static void Display(int[] arr) {
            foreach(var item in arr) {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
        }
        
        private static ISort GetSorter() {
            return new MergeSort();
        }

    }
}
