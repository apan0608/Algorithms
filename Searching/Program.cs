using System;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TwoDimensionalArray();
        }

        private static void JaggedArray() {
            // it is array of array, but each child array can have different size
            int[][] array = new int[2][];                        
        }

        private static void TwoDimensionalArray() {
            int[,] array = new int[2,3] {
                {1,2,3},
                {2,3, 4}
            };
                    
            for(int i = 0; i < array.GetLength(0); i++) {
                for(int j = 0; j < array.GetLength(1); j++) {                
                    Console.Write(array[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
