using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Queens
{
    public static class NQueensSolver
    {
        private static int Steps = 0;
        public static void Go(int n)
        {
            List<int> queens = new();
            //create list of all possible solutions in a tuple to store queeens and amount of steps
            List<(int[], int)> solutions = new List<(int[], int)>();

            //test PrintingSolutions method
            
            //(int[], int) test = (new int[] { 1, 3, 0, 2 }, 50);
            //solutions.Add(test);

            // / // / / / / / / / 
            
            
            SolveNQueens(queens, 0, n, solutions);
            Console.WriteLine("Total Solutions: " + solutions.Count);
            PrintSolutions(solutions);
        }

        public static void SolveNQueens(List<int> queens, int row, int n, List<(int[], int)> solutions)
        {
            // we hit the end of the board so we have a solution
            // save the queens and the amount of steps
            if (row == n)
            {
                //add solution to list
                solutions.Add((queens.ToArray(), Steps)); //Convert to array, because I Initially setup the print with array
                Steps = 0; //reset steps for next solution
                return;
            }
            
            for (int i = 0; i < n; i++)
            {
                if (IsQueenSafe(queens, row, i))
                {
                    queens.Add(i);
                    Steps++;
                    SolveNQueens(queens, row + 1, n, solutions);
                    //Remove queen from list
                    queens.RemoveAt(queens.Count - 1);
                }
            }


        }

        //Setup to compare current row with all previous rows for back tracking
        public static bool IsQueenSafe(List<int> queens, int sizeOfArray, int queen)
        {
            for (int i = 0; i < queens.Count; i++)
            {
                //Same Column
                if (queens[i] == queen)
                {
                    return false;
                }
                //Same Diagonal DONT USE ELSE IFS - we need to make sure we check it's not in the same column and diagonal as previous rows
                if (Math.Abs(queens[i] - queen) == Math.Abs(i - queens.Count))
                {
                    return false;
                }
            }
            return true;

        }

        public static void PrintSolutions(List<(int[], int)> solutions)
        {
            for (int i = 0; i < solutions.Count; i++)
            {
                Console.WriteLine("Solution " + (i + 1) + ": " + "found in " + solutions[i].Item2 + " steps");
                for (int j = 0; j < solutions[i].Item1.Length; j++)
                {
                    for (int k = 0; k < solutions[i].Item1.Length; k++)
                    {
                        // if the current queen is in the current row, print a Q on the board
                        if (solutions[i].Item1[j] == k)
                        {
                            Console.Write("Q ");
                        }
                        else
                        {
                            Console.Write("- ");
                        }
                    }
                    //create new line for each row
                    Console.WriteLine();
                }


            }
        }
    }
}
