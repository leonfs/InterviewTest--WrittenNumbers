using System;
using System.Collections.Generic;
using Interview.WrittenNumbers.Domain.Dictionaries;
using Interview.WrittenNumbers.Domain.Writers;
using NUnit.Framework;

namespace Interview.WrittenNumbers.Domain.Tests.Writers
{
    [TestFixture]
    public class TensWriterTests
    {

        private DigitWriter _digitWriter;

        [SetUp]
        public void SetUp()
        {
            _digitWriter = new DigitWriter(BritishNumbersDictionary.DigitDictionary());
        }


        [Test]
        [TestCase(44, "forty four")]
        [TestCase(17, "seventeen")]
        [TestCase(6, "six")]
        [TestCase(50, "fifty")]
        public void Write(int numberToWrite, string expectedWrittenNumber)
        {

            var tensWriter = new TensWriter(BritishNumbersDictionary.TensDictionary(), _digitWriter);

            string writtenNumber = tensWriter.Write(numberToWrite);
            Assert.AreEqual(expectedWrittenNumber, writtenNumber);
        }


        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Write_HundredNumber()
        {
            var tensWriter = new TensWriter(BritishNumbersDictionary.TensDictionary(), _digitWriter);

            tensWriter.Write(100);
        }

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Constructor_DictionaryContainsHundreds()
        {
            var dictionaryWithHundreds = new Dictionary<int, string>() {{100, "Hundred"}};
            var tensWriter = new TensWriter(dictionaryWithHundreds, _digitWriter);
        }
    }
}