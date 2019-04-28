
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sorting
{
    public class MergeSort: ISort {  

        public void Sorting()
        {  
            Console.WriteLine("Start sorting");
            var cases = GetTestCases();  
            foreach(var testCase in cases) {
                var merged = Sort(testCase);
                Console.WriteLine($"Merged array of length: {merged.Length}");
                string result = "";
                foreach(int item in merged) {
                result += item + " ";
                }         
                Console.WriteLine(result);
            }
        }

    private int[][] GetTestCases() {     
        int numOfCases = 2; //  todo int.Parse(Console.ReadLine());
        int[][] cases = new int[numOfCases][];
        for(int i = 0; i < numOfCases; i++) {
            // first line is length of array
            int length = 5; 
            //int length = int.Parse(Console.ReadLine());
            // second line is array seperated by space
           var rawData = "5 4 2 3 1".Split(' ');
            //var rawData =  Console.ReadLine().Split(' ');
            int[] array = new int[length];
            for (int j = 0; j < length; j++)
            {
                array[j] = int.Parse(rawData[j]);
            }
            cases[i] = array;
        }
        return cases;
    }
    
    
    public int[] Sort(int[] unsorted) {
        //Console.WriteLine(unsorted.Length);
        if (unsorted.Length == 1) {
            return unsorted;
        }
        // break one array up into 2
        int mid = unsorted.Length / 2;
        int[] firstHalf = GetPartOfArray(unsorted, 0, mid);
        int[] secondHalf = GetPartOfArray(unsorted, mid, unsorted.Length - mid);
    
        // the returned array is already sorted as recursively done by the merge method
        firstHalf = Sort(firstHalf);
        secondHalf = Sort(secondHalf);
        // the merge will return a sorted array from bubble up
        return Merge(firstHalf, secondHalf);
    }
    
    private static int[] GetPartOfArray(int[] original, int startIndex, int length) {
        int[] newArray = new int[length];
        for(int i = 0; i < length; i++) {
            newArray[i] = original[startIndex + i];
        }
        return newArray;
    }
    
    // the array can have 1 item only. It bubbles up therefore each arraies are sorted our already
    private static int[] Merge(int[] first, int[] second) {
        // take one item from array two, then insert into array one till the end of array 2
        List<int> sorted = new List<int>(first);
        int currentLoc = 0;
        for(int i = 0; i < second.Length; i++) {
            for(int j = currentLoc; j < sorted.Count; j++) { // sorted keeps growing
                if (second[i] > sorted[j]){
                    sorted.Insert(j, second[i]);                    
                    currentLoc = j + 1;
                } else {
                    // are there more items , then need to compare the one after this 
                    if (sorted.Count > j + 1) {
                        // compare with another item 
                        if (second[i] > sorted[j + 1]) {
                            // insert to j + 1
                            sorted.Insert(j + 1, second[i]);
                            currentLoc = j + 2;
                        } else {
                            continue;
                        }
                    } else {
                        // there is no more item
                        sorted.Add(second[i]);
                    }
                }
                break;
            }
        }
        return sorted.ToArray();
    }
    
    }
}