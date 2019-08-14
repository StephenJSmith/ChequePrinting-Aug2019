using System.Data;

namespace ChequePrinting
{
    public interface IUnits
    {
        string And { get; }
        string Comma { get; }
        string Thousand { get; }
        string Million { get; }
        string Billion { get; }
        string GetSpelt(int input);
    }
}