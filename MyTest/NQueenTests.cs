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
            List<int> pass1 = new List<int>{ 1, 3 };
            bool result1 = NQueensSolver.IsQueenSafe(pass1, 4, 0);
            List<int> pass2 = new List<int> { 2, 1 };            
            bool result2 = NQueensSolver.IsQueenSafe(pass2, 4, 3);
            bool result = result1 == result2; //Both should be true
            Assert.IsTrue(result);
        }
    }
}
