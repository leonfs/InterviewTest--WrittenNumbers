namespace Interview.WrittenNumbers.Domain
{
    public interface INumberWriterFactory
    {
        INumberWriter CreateSingleDigitWriter();

        INumberWriter CreateTensDigitWriter();

        INumberWriter CreateHundredsDigitWriter();

        INumberWriter CreateMillionsDigitWriter();
    }
}