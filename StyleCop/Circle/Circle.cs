namespace StyleCop
{
    using Logger;

    // This class defines a functionality of a circle on the Cartesian coordinate system.
    public abstract class Circle<V> : IMovable<V> where V: struct
    {
        public V Radius { get; protected set; }

        public (V, V) Center { get; protected set; }

        public Circle((V, V) centerCoordinates, V radius)
        { 
            Center = centerCoordinates;
            Radius = radius;
        }

        public abstract void Move(V value, Direction direction);

        public abstract void Resize(V value);

        
    }
}
