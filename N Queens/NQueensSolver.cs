using system;
using system.collections.generic;
using system.linq;
using system.text;
using system.threading.tasks;

namespace n_queens
{
    public static class nqueenssolver
    {
        //solution list
        private static int steps = 0;
        public static void go(int n)
        {
            int[,] board = new int[n, n];
            int[] queens = new int[n];
            solvenqueens(n);

        }

        public static void solvenqueens(int row, )
        {
            if (!isqueensafe)
            {

                return;
            }
        }

        public static bool isqueensafe()
        {
            return false;
        }
    }

    public static class solution
    {

    }

}
