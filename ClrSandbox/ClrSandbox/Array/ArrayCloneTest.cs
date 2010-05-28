using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ArrayCloneTest
    {
        
        [TestMethod]
        public void SimpleCloneEquality()
        {
            var source = new[] { "test0", "test1", "test2" };
            var target = (string[])source.Clone();

            Assert.AreNotSame(source, target);

            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreSame(source[i], target[i]);
            }
        }
    }
}
