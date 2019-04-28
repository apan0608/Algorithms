using System;


namespace Sorting{

     // Counting sort is good to sort array while items have multiple occurance
     public class CountingSort: ISort {

            public int[] Sort(int[] arr) {
                int[] aux = GetAuxillaryArray(arr);
                int[] sorted = new int[arr.Length];
                foreach(int item in arr) {
                    // get the start index of the item from aux
                    int index = aux[item];
                    sorted[index] = item;
                    aux[item]++;
                }
                return sorted;
            }

            // auxillary array stores the number of occurance of each item 
            // another way is to use dictionary, disctionary's keys are natually sorted 
            private int[] GetAuxillaryArray(int[] arr) 
            {
                int noOfAux = GetMaxItem(arr) + 1;
                Console.WriteLine("Max item is " + noOfAux);
                int[] count = new int[noOfAux];
                for(int i = 0; i < arr.Length; i++) {
                    count[arr[i]]++;
                }

                int[] startIndex = new int[noOfAux];
                // Convert count to be array of start index 
                int nextStartIndex = 0;
                for(int i = 0; i < count.Length; i++) {
                    if (count[i] > 0) {
                        startIndex[i] = nextStartIndex;
                        nextStartIndex += count[i];
                    }
                }
                return startIndex;
            }

            private int GetMaxItem(int[] arr) {
                int max = 0;
                foreach(int value in arr) {
                    if (value > max) {
                        max = value;
                    }
                }
                return max;
            }
        
     }
}