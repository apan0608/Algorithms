using System;


namespace Sorting{

    // quick sort is using the pivot to sort, so the left is always less than the tightpivot
    public class InsertionSort: ISort {
        public int[] Sort(int[] arr) {
          
            // start from second itme to comparewith previous 
            for(int i = 1; i < arr.Length; i++) {
                // [i] to compare with [i-1]
                // compare from largest to smallest to the left
                int traveller = arr[i];
                for(int j = i -1; j >= 0; j--) {
                    
                    if (arr[j] > traveller) {
                        // set j to i' location
                        arr[j +1] = arr[j];
                        arr[j] = traveller;
                        //if (j == 0) { //j is the left most item 
                        //    arr[j] = traveller;
                        //}
                    } 
                }
            }  
            return arr;              
        }

    }
}