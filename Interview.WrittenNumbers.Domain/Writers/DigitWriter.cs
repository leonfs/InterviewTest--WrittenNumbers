using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.WrittenNumbers.Domain.Writers
{
    public class DigitWriter : INumberWriter
    {
        private readonly Dictionary<int, string> _digitsDictionary;

        public DigitWriter(Dictionary<int, string> digitsDictionary)
        {
            if (digitsDictionary.Keys.Any(key => !IsSingleDigit(key)))
                throw new ArgumentOutOfRangeException();

            _digitsDictionary = digitsDictionary;
        }

        public string Write(int number)
        {
            if (!IsSingleDigit(number))
                throw new ArgumentOutOfRangeException("number", "Number must be a single digit [0..9].");

            return _digitsDictionary[number];
        }

        private bool IsSingleDigit(int number)
        {
            return number <= 9 && number >= 0;
        }
    }
}