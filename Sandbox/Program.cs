using System;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "c";
            string b = "b";
            if (a[0] < b[0])
            {
                Console.WriteLine("a is less than b");
            }
            else
            {
                Console.WriteLine("a is not less than b");
            }
        }
    }
}
