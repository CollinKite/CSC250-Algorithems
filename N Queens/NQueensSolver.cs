using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Queens
{
    public static class NQueensSolver
    {
        private static int steps = 0;
        public static void Go(int n)
        {
            int[] queens = new int[n];
            SolveNQueens(queens, n);
        }

        public static void SolveNQueens( int[] queens, int n)
        {
            
        }

        public static bool IsQueenSafe(int)
        {
            return false;
        }
    }
}
