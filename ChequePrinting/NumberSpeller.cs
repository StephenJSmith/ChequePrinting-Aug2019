using System.Text;

namespace ChequePrinting
{
    public class NumberSpeller : INumberSpeller
    {
        private readonly IThousands _thousands;

        public IUnits Units { get; private set; }

        public NumberSpeller(IThousands thousands)
        {
            _thousands = thousands;
            Units = _thousands.Units;
        }

        public string GetSpelt(int input)
        {
            if (input < 1000)
            {
                return _thousands.GetSpelt(input);
            }

            var remainder = input;

            var billions = remainder / 1000000000;
            remainder -= billions * 1000000000;

            var millions = remainder / 1000000;
            remainder -= (millions * 1000000);

            var thousands = remainder/1000;
            remainder -= (thousands * 1000);

            var subThousands = remainder;

            var sb = new StringBuilder();

            AppendThousandsGroup(sb, billions, _thousands.Units.Billion);
            AppendThousandsGroup(sb, millions, _thousands.Units.Million);
            AppendThousandsGroup(sb, thousands, _thousands.Units.Thousand);
            AppendThousandsGroup(sb, subThousands);

            return sb.ToString();
        }

        private void AppendThousandsGroup(StringBuilder sb, int value, string groupSizeWord = "")
        {
            if (value == 0)
            {
                return;
            }

            var isGroupSizeWord = !string.IsNullOrWhiteSpace(groupSizeWord);
            if (sb.Length > 0)
            {
                sb.Append(GetSeparator(isGroupSizeWord, value));
            }

            sb.Append(_thousands.GetSpelt(value));
            if (isGroupSizeWord)
            {
                sb.AppendFormat(" {0}", groupSizeWord);
            }
        }

        private string GetSeparator(bool isGroupSizeWord, int nextThousands)
        {
            if (nextThousands == 0)
            {
                return string.Empty;
            }

            if (!isGroupSizeWord && nextThousands < 100)
            {
                return $" {_thousands.Units.And} ";
            }

            return $"{_thousands.Units.Comma} ";
        }
    }
}
