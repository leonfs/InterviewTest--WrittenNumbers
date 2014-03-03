using Interview.WrittenNumbers.Domain.Dictionaries;
using Interview.WrittenNumbers.Domain.Writers;
using NUnit.Framework;

namespace Interview.WrittenNumbers.Domain.Tests.Writers
{
    [TestFixture]
    public class HundredsWriterTests
    {

        [Test]
        [TestCase(900, "nine hundred")]
        [TestCase(840, "eight hundred and forty")]
        [TestCase(356, "three hundred and fifty six")]
        [TestCase(116, "one hundred and sixteen")]
        [TestCase(408, "four hundred and eight")]
        public void Write_900_NineHundred(int numberToWrite, string expectedWrittenNumber)
        {
            var digitWriter = new DigitWriter(BritishNumbersDictionary.DigitDictionary());
            var tensWriter = new TensWriter(BritishNumbersDictionary.TensDictionary(), digitWriter);
            var hundredsWriter = new HundredsWriter(tensWriter);

            var nineHundred = hundredsWriter.Write(numberToWrite);

            Assert.AreEqual(expectedWrittenNumber, nineHundred);
        }


    }
}
