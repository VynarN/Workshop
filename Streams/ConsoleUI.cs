using System;
using System.Collections.Generic;
using System.Text;

namespace Streams
{
    public class ConsoleUI : Streams.Interfaces.IInteractable
    {
        public string Read()
        {
            return Console.ReadLine();
        }
        public void Write(string message)
        {
            Console.Write(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
