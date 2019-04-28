using System.Collections.Generic;
using Problems.Problem;
using System;

namespace Problems.Solver {
    // this algorithm needs to cater for the negative values 
    public class FindingPairsSolver : ISolver<int>
    {
        int radix {get; set;}
        public List<int> SolveProblem(IProblem problem) {
            int[] arr = null;//new int[] {2, 1, 2, 3, 1};
            return new List<int>(getSorted(arr));
        }
        public int[] test(int[] arr) {
            return getSorted(arr);
        }
        private int[] getSorted(int[] arr) {
            int[] auxArr = getAuxiliaryArray(arr);
            int[] sorted = new int[arr.Length];

            foreach(int item in arr) {
                int auxArrIndex = getItemIndex(item, radix);
                int sortedIndex = auxArr[auxArrIndex]; // get index from auxArr
                sorted[sortedIndex] = item;
                auxArr[auxArrIndex]++;
            }

            return sorted;
        }

        private int[] getAuxiliaryArray(int[] arr) {
            int[] countingArr = getCountingArray(arr);
            int[] auxiliaryArr = new int[countingArr.Length]; // start index of each item 
            int accumulate = 0;
            // the below approach might be faseter
            for(int i = 0; i < countingArr.Length; i++) {      
                // thte first item need to start with 0           
                int count = countingArr[i];
                if (count == 0) continue; // 0 means no such item exists. ignore 
                auxiliaryArr[i] = accumulate;             
                accumulate += count;               
            }
            return auxiliaryArr;
        }

        private int[] getCountingArray(int[] arr) {
            var range = getRange(arr);
            int min = radix = range.Item1; // can be less than 0
            int max = range.Item2;
            int[] countingArr = new int[max - min + 1]; // account for 0 
            foreach(int item in arr) {
                // countingArr[item]++; this is based on the min item is 0.
                int index = getItemIndex(item, radix); // the min will be allpcated to 0
                countingArr[index]++;
            }
            return countingArr;
        }

        private int getItemIndex(int item , int radix) {
            return item - radix;
        }

        // get the maximum and minimum value of the array, the array can have negative values
        private (int, int) getRange(int[] arr) {
            int max = arr[0];
            int min = arr[0];
            foreach(int item in arr) {
                if (item > max) {
                    max = item;
                }
                if (item < min) {
                    min = item;
                }
            }
            return (min, max);
        }

    }
}