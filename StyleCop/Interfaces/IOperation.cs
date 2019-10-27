namespace StyleCop
{
    public interface IOperation<T>: Streams.Interfaces.ICheckable<T>
    {
        T GetFigureConsistingOfTwo(T first, T second);
        T GetCrossOfTwoFigures(T first, T second);
    }
}
