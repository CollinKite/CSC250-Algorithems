using System;

namespace N_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number bigger than 0");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("n=" + n);
            NQueensSolver.Go(n);
        }

        //ughhhh I already wrote the print method in the NQueensSolver class and I'm too lazy to move it here
    }
}
