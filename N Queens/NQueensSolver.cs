using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Queens
{
    public static class NQueensSolver
    {
        //Solution List
        private static int Steps = 0;
        public static void Go(int n)
        {
            int[,] Board = new int[n, n];
            int[] Queens = new int[n];
            SolveNQueens(n);

        }

        public static void SolveNQueens(int row, )
        {
            if (!IsQueenSafe)
            {

                return;
            }
        }

        public static bool IsQueenSafe()
        { 
            return false;
        }
    }

    public static class Solution
    {
        
    }

}
