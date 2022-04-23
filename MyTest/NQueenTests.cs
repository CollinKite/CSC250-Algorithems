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
            bool result = NQueensSolver.IsQueenSafe();
            Assert.IsFalse(result);
        }

        [Test]
        public void TestIsSafeWithvalidQueen()
        {
            bool result = NQueensSolver.IsQueenSafe();
            Assert.IsTrue(result);
        }
    }
}
