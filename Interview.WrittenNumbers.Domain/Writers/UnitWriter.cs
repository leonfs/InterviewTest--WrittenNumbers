using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.WrittenNumbers.Domain.Writers
{
    public class UnitWriter : INumberWriter
    {

        private readonly INumberWriter _hundredsWriter;

        private readonly Dictionary<int, string> _unitsDictionary;

        public UnitWriter(Dictionary<int, string> units, INumberWriter hundredsWriter)
        {
            _unitsDictionary = units;
            _hundredsWriter = hundredsWriter;
        }


        public string Write(int number)
        {
            if (number == 0)
                return string.Empty;

            var writtenNumber = new StringBuilder();
            foreach (var unit in _unitsDictionary.Keys.OrderByDescending(u => u))
            {
                var unitNumber = number/unit;
                if (unitNumber != 0)
                    writtenNumber.Append(_hundredsWriter.Write(unitNumber) + string.Format(" {0} ", _unitsDictionary[unit]));
                number = number % unit;
            }

            return writtenNumber.ToString().Trim();

        }
    }
}