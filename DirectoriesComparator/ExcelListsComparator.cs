namespace Comparators
{
    using System;
    using System.Linq;
    using Streams;
    using Streams.Interfaces;
 
    public class ExcelListsComparator : IComparable
    {
        public string File { get; set; }

        public char firstColumn{ get; set; }

        public char secondColumn { get; set; }

        private IInteractable UserInterface;

        private FileXlsxUI Reader;

        public ExcelListsComparator(string File, (char, char) ListsToCompare, IInteractable userInterface)
        {
            if (!string.IsNullOrEmpty(File) && userInterface != null)
            {
                Reader = new FileXlsxUI(File, "ExcelListsComparator", 10, 'B');
                UserInterface = userInterface;
                firstColumn = ListsToCompare.Item1;
                firstColumn = ListsToCompare.Item2;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Compare()
        {
            var values = Reader.Read().Split('\n');
            var filteredValues = values.Where(cell => cell.StartsWith(firstColumn) || cell.StartsWith(secondColumn))
                                       .Select(value => value.Substring(3))
                                       .Distinct()
                                       .ToList();
            foreach (var value in filteredValues)
            {
                UserInterface.WriteLine(value);
            }
        }

    }
}
