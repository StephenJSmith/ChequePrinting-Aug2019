using System.Text;

namespace ChequePrinting
{
    public class CurrencySpeller
    {
        private readonly INumberSpeller _numberSpeller;
        public string CurrencySingular { get; private set; }
        public string CurrencyPlural { get; private set; }
        public string CentSingular { get; private set; }
        public string CentPlural { get; private set; }

        public CurrencySpeller(INumberSpeller numberSpeller)
        {
            _numberSpeller = numberSpeller;

            SetCurrencySpecificValues();
        }

        public string GetSpelt(decimal value)
        {
            var dollars = (int)value / 1;
            var cents = (int)(value % 1 * 100);

            var sb = new StringBuilder();
            AppendAmount(sb, dollars, CurrencySingular, CurrencyPlural);
            sb.AppendFormat(" {0} ", _numberSpeller.Units.And);
            AppendAmount(sb, cents, CentSingular, CentPlural);

            return sb.ToString();
        }

        private void SetCurrencySpecificValues()
        {
            CurrencySingular = "dollar";
            CurrencyPlural = "dollars";
            CentSingular = "cent";
            CentPlural = "cents";
        }

        private void AppendAmount(StringBuilder sb, int value, string singular, string plural)
        {
            var suffix = (value == 1)
                ? singular
                : plural;

            sb.Append(_numberSpeller.GetSpelt(value));
            sb.AppendFormat(" {0}", suffix);

        }
    }
}
