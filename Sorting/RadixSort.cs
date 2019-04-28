using System;

namespace Sorting {

    // this sorting algorithm uses the idea of counting sort. Sort by most insignificant digit first 
    /* original: 170 45 75 90 802 24 2 66
        step 1: 170 90 802 2 24 45 75 66 
        step 2: 802 2 24 45 66 170 75 90 
        step 3: 2 24 45 66 75 90 170 802 */
    public class RadixSort: ISort {
        public int[] Sort(int[] unsorted) {
            return radixSort(unsorted);
        }

        private static int[] radixSort(int[] arr) {
            int max = getMax(arr);
            int radix = 1;
            int[] sorted = arr;
            while (max / radix > 0) {
                sorted = countSort(radix, sorted);
                radix = radix * 10;
            }
            return sorted;
        }

        // radix starts from 10, 100, 1000...
        private static int[] countSort(int radix, int[] arr) {
            
            int[] auxiliaryArr = getAuxiliaryArr(radix, arr);
            int[] sorted = new int[arr.Length];
            foreach(var item in arr) {
                int auxIndex = getAuxIndex(item, radix);
                int sortedIndex = auxiliaryArr[auxIndex];
                sorted[sortedIndex] = item;
                auxiliaryArr[auxIndex]++;
            }
            return sorted;
        }

        private static int[] getAuxiliaryArr(int radix, int[] arr) {
            int length = 10; // always 10 if int array
            int[] countArr = new int[length];
            // get the count array
            foreach(var item in arr) {
                int index = getAuxIndex(item, radix);
                countArr[index]++;
            }
            int accumulate = 0;
            // convert count array to index array
            for(int i = 0; i < length; i++) {
                int count = countArr[i];
                countArr[i] = accumulate;
                accumulate += count;
            }
            return countArr;
        }

        // radix is 1, 10, 100, 1000
        private static int getAuxIndex(int item, int radix) {
            int radixValue = item / radix;
            int index = radixValue % 10; // index in an array of length 10
            return index;
        }

        private static int getMax(int[] arr) {
            int max = 0;
            foreach(var item in arr) {
                if(item > max)
                    max = item;
            }
            return max;
        }

    }
}