namespace Calculator
{
    using System;
    using Streams;
    using Streams.Interfaces;

    public class Calculator
    {
        private IInteractable userInterface;

        public Calculator()
        {
            userInterface = new ConsoleUI();
        }

        public void Calculate(double x, double y, Operation operation)
        {
            switch (operation)
            {
                case Operation.ADD:
                    userInterface.WriteLine($"{x} + {y} = {x + y}");
                    break;
                case Operation.SUB:
                    userInterface.WriteLine($"{x} - {y} = {x - y}");
                    break;
                case Operation.MUL:
                    userInterface.WriteLine($"{x} * {y} = {x * y}");
                    break;
                case Operation.DIV:
                    if (y != 0)
                    {
                        userInterface.WriteLine($"{x} / {y} = {x / y}");
                    }
                    else
                    {
                        throw new DivideByZeroException();
                    }
                    break;
            }
        }
    }
}
