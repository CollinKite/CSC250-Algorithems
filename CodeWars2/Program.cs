using System;

namespace CodeWars2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] walk = { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" };
            Console.WriteLine(walk.Length);
            Console.WriteLine(IsValidWalk(walk)); 
        }

        public static bool IsValidWalk(string[] walk)
        {
            int NorthCount = 0;
            int EastCount = 0;
            int SouthCount = 0;
            int WestCount = 0;

            if (walk.Length != 10)
            {
                return false;
            }

            else
            {
                for (int i = 0; i < walk.Length; i++)
                {
                    if (walk[i] == "n")
                    {
                        NorthCount++;
                        SouthCount--;
                    }
                    else if (walk[i] == "s")
                    {
                        NorthCount--;
                        SouthCount++;
                    }
                    else if (walk[i] == "e")
                    {
                        EastCount++;
                        WestCount--;
                    }
                    else if (walk[i] == "w")
                    {
                        WestCount++;
                        EastCount--;
                    }
                }
                if(NorthCount != 0 || SouthCount != 0 || EastCount != 0 || WestCount != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
