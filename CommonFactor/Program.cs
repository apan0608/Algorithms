using System;

namespace CommonFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int result = generalizedGCD(5, new int[] {2,4,6,8,10});
            Console.WriteLine(result);
        }
        public static int generalizedGCD(int num, int[] arr)
        {
            int hcf = 1; // 1 is the common factor of all numbers except for 0
            int largetCommentFactor = getSmallestNumber(arr);
            // try from the largest commen factor first
            for(int nextFactor = largetCommentFactor; nextFactor > 1; nextFactor--) {
                foreach(int item in arr) {
                    bool findCommonFactor = true;
                    if (!isCommonFactor(item, nextFactor)) {   
                        findCommonFactor = false;
                        break;
                    }
                    if (findCommonFactor) {
                        hcf = nextFactor;
                    }
                }
            }
            return hcf;
        }
        // METHOD SIGNATURE ENDS
        
        private static int getSmallestNumber(int[] arr) {
            int[] sorted = sortArrayAsscending(arr);
            int first = 0;
            return sorted[first];
        }
        
        private static int[] sortArrayAsscending(int[] arr){
            // to be implemented
            return arr;
        }
        
        
        private static bool isCommonFactor(int number, int factor) {
            return number / factor == 0;
        }

    }
}
