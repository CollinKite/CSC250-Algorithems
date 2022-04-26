using System.Collections.Generic;
using NUnit.Framework;
using N_Queens;

namespace MyTest
{
    public class NQueenTests
    {
        [Test]
        public void TestIsSafeWithInvalidQueen()
        {
            //fails in column
            List<int> fail1 = new List<int> {1,3};
            //fails in diagonal
            List<int> fail2 = new List<int> { 1, 3 };
            bool column = NQueensSolver.IsQueenSafe(fail1, 4, 3);
            bool diagonal = NQueensSolver.IsQueenSafe(fail2, 4, 2);
            bool result = column != diagonal; //should be false if both fail
            Assert.IsFalse(result);
        }

        [Test]
        public void TestIsSafeWithvalidQueen()
        {
            List<int> pass = new List<int>{ 1, 3 };
            bool result = NQueensSolver.IsQueenSafe(pass, 4, 0);
            Assert.IsTrue(result);
        }
    }
}
