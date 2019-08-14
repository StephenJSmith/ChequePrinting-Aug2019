using System;
using System.Text;

namespace ChequePrinting
{
    public class Thousands : IThousands
    {
        private readonly IUnits _units;

        public IUnits Units
        {
            get { return _units; }
        }

        public Thousands(IUnits units)
        {
            _units = units;
        }

        public string GetSpelt(int input)
        {
            if (input < 0 || input >= 1000)
            {
                throw new ArgumentOutOfRangeException();
            }

            var spelt = _units.GetSpelt(input);
            if (!string.IsNullOrWhiteSpace(spelt))
            {
                return spelt;
            }

            var hundreds = input / 100 * 100;
            var remainder = input - hundreds;
            var tens = remainder / 10 * 10;
            remainder -= tens;
            var singles = remainder % 10;
            var result = new StringBuilder();

            AppenHundreds(result, hundreds);
            AppendAnd(result, hundreds, tens, singles);
            AppendTensAndSingles(result, tens, singles);

            return result.ToString();
        }

        private void AppenHundreds(StringBuilder sb, int hundreds)
        {
            if (hundreds == 0) return;

            sb.Append(_units.GetSpelt(hundreds));
        }

        private void AppendAnd(StringBuilder sb, int hundreds, int tens, int singles)
        {
            if (hundreds > 0 && (tens > 0 || singles > 0))
            {
                sb.AppendFormat(" {0} ", _units.And);
            }
        }

        private void AppendTensAndSingles(StringBuilder sb, int tens, int singles)
        {
            var key = tens + singles;
            var value = _units.GetSpelt(key);
            if (!string.IsNullOrWhiteSpace(value))
            {
                sb.Append(value);

                return;
            }

            if (tens > 0)
            {
                sb.Append(_units.GetSpelt(tens));
                sb.Append("-");
            }

            sb.Append(_units.GetSpelt(singles));
        }
    }
}
