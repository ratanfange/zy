using Book.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mstest
{
    [TestClass]
    public class UnitTest1
    {
        private BookLogic _logic = new BookLogic();

        [TestMethod]
        public void TestForTwoIsNull()
        {
            var actual = _logic.GetAlgorithm(null, null);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestForNull_AIsNull()
        {
            var actual = _logic.GetAlgorithm(null, "2");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestForNull_BIsNull()
        {
            var actual = _logic.GetAlgorithm("1", null);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestForCanNotConvertToInt_A()
        {
            var actual = _logic.GetAlgorithm("a", "2");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestForCanNotConvertToInt_B()
        {
            var actual = _logic.GetAlgorithm("1", "b");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestForCanNotConvertToInt_AB()
        {
            var actual = _logic.GetAlgorithm("a", "b");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestForA_ADD_B()
        {
            var actual = _logic.GetAlgorithm("1", "2");
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual);

        }

        [TestMethod]
        public void TestForA_Multiply_B()
        {
            var actual = _logic.GetAlgorithm("3", "3");
            Assert.IsNotNull(actual);
            Assert.AreEqual(9, actual);

        }

        [TestMethod]
        public void TestForA_Minus_B()
        {
            var actual = _logic.GetAlgorithm("3", "1");
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual);

        }

    }
}
