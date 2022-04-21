using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace BigO
{
    class Program
    {
        static void Main(string[] args)
        {
            Stuff algos = new Stuff();
            //int[] arr1 = algos.getRandomArray(999);
            //Stopwatch watch = Stopwatch.StartNew();
            //watch.Start();
            //algos.algorithm(arr1);
            //watch.Stop();
            //TimeSpan ts = watch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //Console.WriteLine("RunTime for First Algo" + elapsedTime);

            // //Second Algo Algo
            //int[] arr2 = algos.getRandomArray(5000);
            //int[] arr3 = algos.getRandomArray(5000);
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //stopwatch.Start();
            //int[] matches = algos.findMatches(arr2, arr3);
            //stopwatch.Stop();
            // //Get the elapsed time as a TimeSpan value.
            //ts = stopwatch.Elapsed;

            // //Format and display the TimeSpan value.
            //elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //Console.WriteLine("RunTime for Second Algo " + elapsedTime);
            bool test = algos.isPalindrome("bob");
            Console.WriteLine(test);
        }
    }

    class Stuff
    {
        public bool isPalindrome(string word)
        {
            word = word.Replace(" ",""); //Get rid of spaces
            for (int firstLetter = 0, lastLetter = (word.Length - 1); firstLetter < ((word.Length - 1) / 2) && lastLetter > ((word.Length - 1) / 2); firstLetter++, lastLetter--)
            {
                if (word[firstLetter] != word[lastLetter])
                {
                    return false;
                }
            }
            return true;
        }

        //First Number Is Result, second is iteration count
        public (int, int) algorithm(int[] A)
        {
            int count = 0;
            int x = A.Length - 1;
            int y = A[0];
            for (int i = 1; i < x; i++)
            {
                if (A[i] > y)
                {
                    y = A[i];
                }
                count++;
            }
            return (y, count);
        }



        public int[] getRandomArray(int size)
        {
            Random random = new();
            int arraySize = size;
            int[] randomArr = new int[arraySize];
            for (int i = 0; i < randomArr.Length; i++)
            {
                randomArr[i] = random.Next(1000);
            }
            return randomArr;
        }

        public int[] findMatches(int[] arr1, int[] arr2)
        {
            List<int> matches = new();
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        matches.Add(arr1[i]);
                    }
                }
            }
            return matches.ToArray();
        }
    }
}
