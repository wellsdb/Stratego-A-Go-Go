using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Stratego;
using Network;

namespace Testing.Network_Tests
{

    [TestFixture()]
    class ConverterTests
    {
        private ASCIIEncoding encoder = new ASCIIEncoding();
        private String testString1 = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private String testString2 = "1234567890 abcdefghijklmnopqrstuvwxyz";
        private Byte[] testByte1;
        private Byte[] testByte2;

        [SetUp()]
        public void SetUp()
        {
            testByte1 = encoder.GetBytes(testString1);
            testByte2 = encoder.GetBytes(testString2);
        }

        [Test()]
        public void TestStringToByte()
        {
            Converter target = new Converter();

            Byte[] conversion1 = target.StringToByte(testString1);
            Byte[] conversion2 = target.StringToByte(testString2);

            Assert.AreEqual(testByte1, conversion1);
            Assert.AreEqual(testByte2, conversion2);
        }

        [Test()]
        public void TestByteToString()
        {
            Converter target = new Converter();

            String conversion1 = target.ByteToString(testByte1);
            String conversion2 = target.ByteToString(testByte2);

            Assert.AreEqual(testString1, conversion1);
            Assert.AreEqual(testString2, conversion2);
        }
        

        //[Test()]
        //public void TestBoardToByte()
        //{
        //    Assert.Fail();
        //}

        //[Test()]
        //public void TestByteToBoard()
        //{
        //    Assert.Fail();
        //}

    }
}
