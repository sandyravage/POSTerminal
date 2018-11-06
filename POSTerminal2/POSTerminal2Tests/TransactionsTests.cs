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
    public class TransactionsTests
    {
        [TestMethod()]
        public void CashReturnTest()
        {
            double actual = Transactions.CashReturn("88.8");
            Assert.AreEqual(88.8, actual);
        }

        [TestMethod()]
        public void PaymentTypeValidatorTest()
        {
            string actual = Transactions.PaymentTypeValidator("cash");
            Assert.AreEqual("cash", actual);
        }
    }
}