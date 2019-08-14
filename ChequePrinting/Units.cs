using System.Collections.Generic;

namespace ChequePrinting
{
    public class Units : IUnits
    {
        private Dictionary<int, string> _units;
        public string And { get; private set; }
        public string Comma { get; private set; }
        public string Thousand { get; private set; }
        public string Million { get; private set; }
        public  string Billion { get; private set; }

        public Units()
        {
            SetLanguageSpecificValues();
        }

        public string GetSpelt(int number)
        {
            if (!_units.TryGetValue(number, out string words))
            {
                return string.Empty;
            }

            return words;
        }

        private void SetLanguageSpecificValues()
        {
            And = "and";
            Comma = ",";
            Thousand = "thousand";
            Million = "million";
            Billion = "billion";

            InitialiseUnitsDictionary();
        }

        private void InitialiseUnitsDictionary()
        {
            _units = new Dictionary<int, string>
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "eleven" },
                { 12, "twelve" },
                { 13, "thirteen" },
                { 14, "fourteen" },
                { 15, "fifteen" },
                { 16, "sixteen" },
                { 17, "seventeen" },
                { 18, "eighteen" },
                { 19, "nineteen" },
                { 20, "twenty" },
                { 30, "thirty" },
                { 40, "forty" },
                { 50, "fifty" },
                { 60, "sixty" },
                { 70, "seventy" },
                { 80, "eighty" },
                { 90, "ninety" },
                { 100, "one hundred" },
                { 200, "two hundred" },
                { 300, "three hundred" },
                { 400, "four hundred" },
                { 500, "five hundred" },
                { 600, "six hundred" },
                { 700, "seven hundred" },
                { 800, "eight hundred" },
                { 900, "nine hundred" },
            };

        }
    }
}
