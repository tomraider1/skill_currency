using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesetApp.Controllers;
using System.Collections.Generic;

namespace TesetApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expectedValue = "value";

            string actualValue = new ValuesController().Get(1);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
