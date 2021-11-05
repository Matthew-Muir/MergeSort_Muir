using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 30, 900, 55, 54, 56, 71, -43, 0, 4529, 555, 639, 101, 102, 100, 5, 82, 50, -77, 14, 99, 104, 1 };
            int[] arraySingle = { 4,4,4,4 };
            int[] arrayAscSort = { 1,2,3,4,5,10 };
            int[] arraySingleVal = { 0 };

            MergeSort(array);
            MergeSort(arraySingle);
            MergeSort(arrayAscSort);
            MergeSort(arraySingleVal);
        }

        static void MergeSort(int[] arr)
        {
            SplitArray(arr, arr.Length - 1);
            printArray(arr);
        }

        static void SplitArray(int[] arr, int rightIndex, int leftIndex = 0) //breaks down my array into sub arrays
        {
            if (arr.Length < 2)
            {
                return; // Array already sorted or empty
            }


            else if (leftIndex < rightIndex) //end condition for when entire sub-array has been indexed
            {
                int middleIndex = leftIndex +  (rightIndex - leftIndex) / 2;

                SplitArray(arr, leftIndex:leftIndex, rightIndex:middleIndex); // break down left side

                SplitArray(arr, leftIndex:middleIndex + 1, rightIndex:rightIndex);// break down right side

                MergeSubArrays(arr, leftIndex, middleIndex, middleIndex + 1, rightIndex); //merge left and right arrays

            }
        }

        static void MergeSubArrays(int[] arr, int leftStart, int leftEnd, int rightStart, int rightEnd) // sorts two sub array's elements
        {
            if (arr[leftEnd] >= arr[rightStart])// sub-arrays already in desc order
            {
                return;
            }

            else
            {
                while (leftStart <= leftEnd && rightStart <= rightEnd) // left & right pointers not at end of sub arrays.
                {
                    if (arr[leftStart] >= arr[rightStart])
                    {
                        leftStart++; //elements in order. increment indexer.
                    }
                    else
                    {
                        var storeVal = arr[rightStart];
                        var index = rightStart;

                        while (index != leftStart) //shift all elements right.
                        {
                            arr[index] = arr[index - 1];
                            index--;
                        }
                        {
                            arr[leftStart] = storeVal; //store value in correct position.
                            leftStart++;
                            rightStart++;
                            leftEnd++;

                        }
                    }
                }
            }
        }

        static void printArray(int[] arr)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }







    }
}
