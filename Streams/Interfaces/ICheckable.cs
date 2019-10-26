namespace Streams.Interfaces
{
    public interface ICheckable<T>
    {
        bool Check(T param);
    }
}
