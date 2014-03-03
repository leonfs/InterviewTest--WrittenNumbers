using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.WrittenNumbers.Domain.Writers
{
    public class TensWriter : INumberWriter
    {

        private readonly Dictionary<int, string> _tensDictionary;
        private readonly INumberWriter _digitWriter;

        public TensWriter(Dictionary<int, string> tensDictionary, INumberWriter digitWriter)
        {
            if (tensDictionary.Keys.Any(key => !IsTens(key)))
                throw new ArgumentOutOfRangeException("tensDictionary", "Only double digits dictionary are allowed.");
            if (digitWriter == null) 
                throw new ArgumentNullException("digitWriter");

            _tensDictionary = tensDictionary;
            _digitWriter = digitWriter;
        }

        public string Write(int number)
        {
            if (number == 0)
                return _tensDictionary[number];

            if (number < 10)
                return _digitWriter.Write(number);
            
            if (number >= 10 && number < 20)
                return _tensDictionary[number];

            if (number > 99)
                throw new ArgumentOutOfRangeException("number", "Only double digits are allowed.");

            var doubleDigitBase = number - (number % 10);

            return string.Format("{0} {1}", _tensDictionary[doubleDigitBase], this.Write(number % 10)).Trim();
        }

        private bool IsTens(int number)
        {
            return number >= 0 && number < 100;
        }
    }
}