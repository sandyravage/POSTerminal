using Microsoft.VisualStudio.TestTools.UnitTesting;
using POSTerminal2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal2.Tests
{
    [TestClass()]
    public class ValidatorTests
    {
        [TestMethod()]
        public void MenuValidatorTest()
        {
            string actual = Validator.MenuValidator("7");
            Assert.AreEqual("7", actual);
        }

        [TestMethod()]
        public void QuantityValidatorTest()
        {
            int actual = Validator.QuantityValidator("8");
            Assert.AreEqual(8, actual);
        }

        [TestMethod()]
        public void YesNoCheckerTest()
        {
            string actual = Validator.YesNoChecker("y");
            Assert.AreEqual("y", actual);
        }
    }
}