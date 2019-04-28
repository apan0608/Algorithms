using System;

namespace Problems
{
    /* this problem is from Amazon coding assignment. A file is devided into a list of sub filee in an order
     program need to merge them back to onw file. But it can only merge two at a time, the two need to be in right sequence.
    The problem is to find out the minimum merge time possible */
        public class MergeFile {
        public static int minimumTime(int numOfSubFiles, int[] files)
        {
            // keep merging files till size if only 1 
            while (files.Length > 1) {
                int mergeFileIndex = getIndexOfFileWithMinimumMergeSize(numOfSubFiles, files);   
                files = mergeFile(mergeFileIndex, files);
                numOfSubFiles = files.Length;
            }
            return files[0];
        }
	
        private static int[] mergeFile(int mergeFileIndex, int[] files) {
            // merged file will be 1 size shorter than original one
            int[] mergedFiles = new int[files.Length - 1];
            int newFileIndex = 0;
            // stop at the second last file
            for(int i = 0; i < files.Length; i++) {
                if (i == mergeFileIndex) {
                    int sizeOfMergedFiles = files[i] + files[i+1];
                    mergedFiles[newFileIndex] = sizeOfMergedFiles;
                    i++; //skip the next file as it is merged
                } else {
                    // copy the size of original file
                    mergedFiles[newFileIndex] = files[i];
                }
                newFileIndex++;
            }

            return mergedFiles;
        }
        
	// get the index of the file where the merge time will be minimum
        private static int getIndexOfFileWithMinimumMergeSize(int numOfSubFiles, int[] files) {
            int index = 0;
            int minimumTimeSum = 0;
            // stop loop at the second last file
            for (int i = 0; i < numOfSubFiles -1; i++) {
                if (i == 0) {
                    // set the initial minimumTimeSum
                    minimumTimeSum = files[i] + files[i + 1];
                    continue;
                }
                int timeSum = files[i] + files[i + 1];
                if (timeSum < minimumTimeSum) {
                    minimumTimeSum = timeSum;
                    index = i;
                }
            }
            return index;
        }
    }
}