namespace Calculator
{
    using System;
    using Streams;
    using Streams.Interfaces;

    public class Parser
    {
        private IInteractable userInterface;

        public Parser()
        {
            userInterface = new ConsoleUI();
        }

        public double ParseInput()
        {
            if(double.TryParse(userInterface.Read(), out double input))
            {
                return input;
            }
            else
            {
                userInterface.WriteLine("Input can not be parsed! 0.0 will be returned!");
                return 0.0;
            }
        }
    }
}
