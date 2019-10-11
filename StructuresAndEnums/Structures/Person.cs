using System;
using System.Collections.Generic;
using System.Text;

namespace StructuresAndEnums.Structures
{
    public struct Person
    {
        public string Name;
        public string Surname;
        public int Age;
        public string IsOlderOrYounger(int age)
        {
            return age > Age ? $"{Name} {Surname} is younger than {age}" :
                               $"{Name} {Surname} is older than {age}";
        }
    }
}
