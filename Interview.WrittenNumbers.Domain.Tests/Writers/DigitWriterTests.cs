using System;
using System.Collections.Generic;
using Interview.WrittenNumbers.Domain.Dictionaries;
using Interview.WrittenNumbers.Domain.Writers;
using NUnit.Framework;

namespace Interview.WrittenNumbers.Domain.Tests.Writers
{
    [TestFixture]
    public class DigitWriterTests
    {
        [SetUp]
        public void SetUp()
        {
            _digitHandler = new DigitWriter(BritishNumbersDictionary.DigitDictionary());
        }

        private DigitWriter _digitHandler;

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Constructor_WordsDictionaryHasDoubleDigitNumber()
        {
            var singleDigitBritishDictionary = new Dictionary<int, string> { {10, "ten"} };

            var singleDigitNumber = new DigitWriter(singleDigitBritishDictionary);
        }

        [Test]
        [TestCase(0, "zero")]
        [TestCase(1, "one")]
        [TestCase(9, "nine")]
        public void Write(int digitToTest, string expectedWrittenNumber)
        {
            string writtenDigit = _digitHandler.Write(digitToTest);

            Assert.AreEqual(expectedWrittenNumber, writtenDigit);
        }

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Write_DoubleDigitNumber()
        {
            const int doubleDigitNumber = 10;
            _digitHandler.Write(doubleDigitNumber);
        }
    }
}