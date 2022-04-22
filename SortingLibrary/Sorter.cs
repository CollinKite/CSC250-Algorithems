using System;

namespace SortingLibrary
{
    public class Sorter<T> where T: IComparable<T> //T is generic, lets you pass through many objects
    {

        //inplace - inplace changes var, out of place does it to an external array

        //Compare to elements in array to each other and swap
        //Should be stable, shouldn't swap any values of the same value
        //Good for small amount of arrays and data is mostly sorted
        public static void BubbleSort(T[] arr)
        {
            bool sorted = false;
            while (!sorted)
            {
                bool swapped = false;
                int count = 1;
                for (int i = 0; i < arr.Length - count; i++)
                {
                    //if arr[0].CompareTo(arr[1] > 0); //0 is same value - no swap //-1 is the compared to value is greater - no swap //  1 initial value is bigger - needs to swap
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T x = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = x;
                        swapped = true;
                    }
                }
                if(swapped == false)
                {
                    sorted = true;
                }
                else
                {
                    count = +1;
                }
            }
            
            }

        //Start with second number in array because you can't compare the -1 index. Compare selected number to number before it, If the number proceeds then swap and compare to the number again to the one before and stop when you hit 1 or the number doesn't proceed anymore.
        public static void InsertionSort(T[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T value = arr[i];
                int j;
              
                for (j = (i - 1); j >= 0; j--)
                {
                    if(value.CompareTo(arr[j]) < 0)
                    {
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j + 1] = value;
            }
        }

        //Slowest, and bad sort tbh
        //Quadratic Big O
        //Sort is done by setting first number as lowest number (store index) and looping through and comparing it to numbers after it and updating our lowest number index if there are any numbers that proceed it.
        //This sort is bad because the time to completion will always be the worst and the array could be sorted and it wouldn't matter or help as it still would take the same amount of time.
        public static void SelectionSort(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int lowestIndex = i;
                for (int J = i + 1; J < arr.Length; J++)
                {
                    if (arr[lowestIndex].CompareTo(arr[J]) > 0)
                    {
                        lowestIndex = J;
                    }
                }
                if (lowestIndex != i)
                {
                    //Swap
                    T val = arr[i];
                    arr[i] = arr[lowestIndex];
                    arr[lowestIndex] = val;
                }
            }
        }

        /// <summary>
        /// Take First Item in array, (don't have too, research other theories for selecting piviot), find where pivot belongs in array, and split at the pivot recursivly and sort.
        /// time to sort depends on picking a good pivot
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(T[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
            
        }

        public static void QuickSort(T[] arr, int start, int end)
        {
            if(start>end)
            {
                return;
            }
            int num = Partition(arr, start, end);
            QuickSort(arr, num + 1, arr.Length - 1);
            QuickSort(arr, start , num - 1);
            //call quick sort with each half
        }

        public static int Partition(T[] arr, int start, int end)
        {
            T pivot = arr[start]; //select first number in array as pivot
            int larger = start;
            int smaller = end;
            while(larger != smaller)
            {
                while (arr[larger].CompareTo(pivot) < 0)
                {
                    larger++;
                }

                while (arr[smaller].CompareTo(pivot) > 0)
                {
                    smaller--;
                }
                

                //swap
                T item = arr[smaller];
                arr[smaller] = arr[larger];
                arr[larger] = item;
            }
            return larger;
           
            
        }

        //Merge sort breaks array all the way down into arrays of one elements by splitting it in half, and sorts them on the way back up.
        public static void MergeSort(T[] arr)
        {
            //If our array has 1 item, stop spliting
            if(arr.Length == 1)
            {
                return;
            }
            //Split and Create Arrays
            T[] arr1 = new T[arr.Length/2];
            T[] arr2 = new T[arr.Length - arr1.Length];
            //Fill Arrays
            for (int fillArr1 = 0; fillArr1 < arr1.Length; fillArr1++)
            {
                arr1[fillArr1] = arr[fillArr1];
            }
            for (int index = 0, fillArr2 = arr.Length/2; fillArr2 < arr.Length && index < arr2.Length; index++, fillArr2++)
            {
                arr2[index] = arr[fillArr2];
            }
            MergeSort(arr1);
            MergeSort(arr2);
            Merge(arr, arr1, arr2);
        }

        public static void Merge(T[] arr, T[] arr1, T[] arr2)
        {
            int mainCount = 0;
            int arr1Count = 0;
            int arr2Count = 0;
            //compare arrays and merge
            while(arr1Count < arr1.Length && arr2Count < arr2.Length)
            {
                if (arr1[arr1Count].CompareTo(arr2[arr2Count]) < 0){
                    arr[mainCount] = arr1[arr1Count];
                    arr1Count++;
                    mainCount++;
                }
                else
                {
                    arr[mainCount] = arr2[arr2Count];
                    arr2Count++;
                    mainCount++;
                }
            }
            //Copy remaining if one is empty
            while(arr1Count < arr1.Length)
            {
                arr[mainCount] = arr1[arr1Count];
                mainCount++;
                arr1Count++;
            }
            while(arr2Count < arr2.Length)
            {
                arr[mainCount] = arr2[arr2Count];
                mainCount++;
                arr2Count++;
            }

        }
        
    }
}
