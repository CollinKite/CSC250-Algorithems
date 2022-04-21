using System;

namespace CodeWars3
{
    public class Kata
    {
        //End Unit Test
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine( FoldArray(input, 3)[0]);
        }

        public static int[] FoldArray(int[] array, int runs)
        {
            Console.WriteLine(array.Length);
            Console.WriteLine(runs);
            if (runs > 0)
            {
                double half = (double)(array.Length / 2.0);
                Console.WriteLine(half);
                int[] newArr = new int[(int)(Math.Ceiling(half))];
                Console.WriteLine(newArr.Length);
                if (array.Length > 1)
                {
                    for (int first = 0, last = array.Length - 1; first < (array.Length / 2) && last >= (array.Length / 2); first++, last--)
                    {
                        newArr[first] = array[first] + array[last];
                    }
                    if (array.Length % 2 == 1)
                    {
                        newArr[newArr.Length - 1] = array[(int)(Math.Floor(half))];
                    }
                    return FoldArray(newArr, runs - 1);
                }
                else
                {
                    return array;
                }
                
            }
            else
            {
                return array;
            }



        }
    }
}
