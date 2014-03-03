using Interview.WrittenNumbers.Domain.Dictionaries;
using Interview.WrittenNumbers.Domain.Writers;

namespace Interview.WrittenNumbers.Domain.Factories
{
    public class BritishNumbersWriterFactory : INumberWriterFactory
    {
        public INumberWriter CreateSingleDigitWriter()
        {
            return new DigitWriter(BritishNumbersDictionary.DigitDictionary());
        }

        public INumberWriter CreateTensDigitWriter()
        {
            return new TensWriter(BritishNumbersDictionary.TensDictionary(), CreateSingleDigitWriter());
        }

        public INumberWriter CreateHundredsDigitWriter()
        {
            return new HundredsWriter(CreateTensDigitWriter());
        }

        public INumberWriter CreateMillionsDigitWriter()
        {
            return new UnitWriter(BritishNumbersDictionary.UnitsDictionary(), CreateHundredsDigitWriter());
        }
    }
}