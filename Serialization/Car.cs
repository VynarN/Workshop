using System;

namespace Serialization
{
    [Serializable]
    public class Car
    {
        public int carId;
        public int quantity;
        public decimal price;
        public decimal total;
        public Car() { }
    }
}
