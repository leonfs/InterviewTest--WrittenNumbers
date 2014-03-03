namespace Interview.WrittenNumbers.Domain.Writers
{
    public class HundredsWriter : INumberWriter
    {
        private readonly INumberWriter _tensWriter;

        public HundredsWriter(INumberWriter tensWriter)
        {
            _tensWriter = tensWriter;
        }

        public string Write(int number)
        {
            if (number == 0)
                return "";

            int hundredIndex = number/100;

            if (hundredIndex == 0)
                return _tensWriter.Write(number);

            string hundredsNumber = string.Format("{0} hundred", _tensWriter.Write(hundredIndex));
            string tensNumber = _tensWriter.Write(number%100);

            return string.IsNullOrEmpty(tensNumber)
                ? hundredsNumber
                : string.Format("{0} and {1}", hundredsNumber, tensNumber).Trim();
        }
    }
}