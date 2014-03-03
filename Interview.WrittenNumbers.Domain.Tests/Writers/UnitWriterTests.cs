using Interview.WrittenNumbers.Domain.Dictionaries;
using Interview.WrittenNumbers.Domain.Writers;
using NUnit.Framework;

namespace Interview.WrittenNumbers.Domain.Tests.Writers
{
    [TestFixture]
    public class UnitWriterTests
    {
        private UnitWriter _unitWriter;
        private DigitWriter _digitWriter;
        private TensWriter _tensWriter;
        private HundredsWriter _hundredsWriter;

        [SetUp]
        public void SetUp()
        {

            _digitWriter = new DigitWriter(BritishNumbersDictionary.DigitDictionary());
            _tensWriter = new TensWriter(BritishNumbersDictionary.TensDictionary(), _digitWriter);
            _hundredsWriter = new HundredsWriter(_tensWriter);
            _unitWriter = new UnitWriter(BritishNumbersDictionary.UnitsDictionary(), _hundredsWriter);
        }

        [Test]
        [TestCase(1200, "one thousand two hundred")]
        [TestCase(1000000, "one million")]
        [TestCase(999999999, "nine hundred and ninety nine million nine hundred and ninety nine thousand nine hundred and ninety nine")]
        public void Write(int numberToWrite, string expectedWrittenNumber)
        {
            var writtenNumber = _unitWriter.Write(numberToWrite);

            Assert.AreEqual(expectedWrittenNumber, writtenNumber);
        }


       
    }
}