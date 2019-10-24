using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class Pet : IMovable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public Pet(string name, int age, string breed)
        {
            Name = name;
            Age = age;
            Breed = breed;
        }
        public void Move()
        {
            Console.WriteLine("Pet is moving");
        }
    }
}
