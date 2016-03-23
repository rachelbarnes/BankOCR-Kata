using ConsoleApplication3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class TestsForChecksum

    {
        [Test]
        public void testValidAccountNumber1()
        {
            var accountNumber = 123456789;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(true, Sum);
        }

        [Test]
        public void testValidAccountNumber3()
        {
            // 45750800;
        }

        [Test]
        public void testValidAccountNumber2()
        {
            var accountNumber = 345882865;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(true, Sum);
        }

        [Test]
        public void testIncorrectAccountNumber2()
        {
            var accountNumber = 554433995;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(false, Sum);
        }
        //these should not be passing; im just asking it to evaluate the
        //same set of positionValues in the for loop which is why everything
        //is passing. 



        [Test]
        public void testIncorrectAccountNumber()
        {
            var accountNumber = 664371495;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(false, Sum);
        }
        //this is testing false - it is coming back as true in a failed test. 

        [Test]
        public void testSumAllDigits()
        {
            var accountNumber = 111111111;
            var checksum = new CheckSum();
            var Sum = checksum.ChecksumAllDigits(accountNumber);
            Assert.AreEqual(45, Sum);
        }

        [Test]
        public void test_Inverse()
        {
            var checksum = new CheckSum();
            Assert.AreEqual(1, checksum.FindInverse(8));
            Assert.AreEqual(2, checksum.FindInverse(7));
            Assert.AreEqual(3, checksum.FindInverse(6));
            Assert.AreEqual(4, checksum.FindInverse(5));
            Assert.AreEqual(5, checksum.FindInverse(4));
            Assert.AreEqual(6, checksum.FindInverse(3));
            Assert.AreEqual(7, checksum.FindInverse(2));
            Assert.AreEqual(8, checksum.FindInverse(1));
            Assert.AreEqual(9, checksum.FindInverse(0));
        }

        [Test]
        public void TestValidAccountNumber()
        {
            var accountNumber = 345882865;
            var checksum = new CheckSum();
            //var textFile = "firstOCRFile.txt";
            var Sum = checksum.CheckValidAccountNumber(accountNumber.ToString());
            Assert.AreEqual(accountNumber.ToString(), Sum);
        }

        [Test]
        public void TestInvalidAccountNumber()
        {
            var accountNumber = 664371495;
            var checksum = new CheckSum();
            var Sum = checksum.CheckValidAccountNumber(accountNumber.ToString());
            Assert.AreEqual(accountNumber + " ERR", Sum);
        }
        [Test]
        public void TestAccountNumberWithQuestionMark()
        {
            var bankOCR = new BankOCR();
            var checksum = new CheckSum();
            var accountNumber = "12345?789";  
            //var actual = checksum.CheckValidAccountNumber(accountNumber);
            var expected = accountNumber + " ILL";
            Assert.AreEqual(expected, checksum.CheckValidAccountNumber(accountNumber));  
        }
    }
}


