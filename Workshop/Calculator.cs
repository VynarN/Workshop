namespace Workshop
{
    using Calculator;

    public partial class WorkshopMain
    {
        static void DoSomeCalculation()
        {
            Calculator calc = new Calculator();
            Parser parser = new Parser();

            double x = parser.ParseInput();
            double y = parser.ParseInput();

            calc.Calculate(x, y, Operation.ADD);

            DelayAndClear();
        }
    }
}
