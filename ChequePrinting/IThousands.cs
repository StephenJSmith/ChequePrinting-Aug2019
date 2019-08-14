namespace ChequePrinting
{
    public interface IThousands
    {
        IUnits Units { get; }
        string GetSpelt(int input);
    }
}