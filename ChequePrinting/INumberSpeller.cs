namespace ChequePrinting
{
    public interface INumberSpeller
    {
        IUnits Units { get; }
        string GetSpelt(int input);
    }
}