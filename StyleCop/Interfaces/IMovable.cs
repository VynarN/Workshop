namespace StyleCop
{
    public interface IMovable<T>
    {
        void Move(T step, Direction direction);
    }
}
