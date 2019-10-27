namespace StyleCop
{
    using System;

    public partial class FloatingPointCircle: Circle<double> 
    {
        public FloatingPointCircle((double, double) centerCoordinates, double radius) : base(centerCoordinates, radius) { }
        
        public override void Move(double value, Direction direction)
        {
            double step = Math.Abs(value);
            switch (direction)
            {
                case Direction.BOTTOM:
                    Center = (Center.Item1, Center.Item2 - step);
                    break;
                case Direction.TOP:
                    Center = (Center.Item1, Center.Item2 + step);
                    break;
                case Direction.LEFT:
                    Center = (Center.Item1 - step, Center.Item2);
                    break;
                case Direction.RIGHT:
                    Center = (Center.Item1 + step, Center.Item2);
                    break;
            }
        }

        public override void Resize(double value)
        {
            Radius = Radius + value;
        }
    }
}
