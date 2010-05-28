using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClrSandbox.List
{
    using System.Linq;

    [TestClass]
    public class ToArrayGivesTwoObjectsTest
    {

        private List<string> _theList;
        private string[] _firstArray;
        private string[] _secondArray;

        [TestMethod]
        public void DoesToArrayOfListGivesTwoObjectTest()
        {
            GetTarget();

            _firstArray = _theList.ToArray();
            _secondArray = _theList.ToArray();

            AssertTwoObjects();
        }

        private void AssertTwoObjects()
        {
            Assert.AreNotSame(_firstArray, _secondArray);
        }

        private void GetTarget()
        {
            _theList = new List<string>();

            _theList.AddRange(new[] { "test1", "test2", "test3" });
        }

        [TestMethod]
        public void ListOnLinqGivesTwoObjectTest()
        {
            GetTarget();

            _firstArray = _theList.Select(value => value).ToArray();
            _secondArray = _theList.Select(value => value).ToArray();

            AssertTwoObjects();
        }
    }
}
