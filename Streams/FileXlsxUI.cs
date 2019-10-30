namespace Streams
{
    using System;
    using System.IO;
    using System.Text;
    using IronXL;

    public class FileXlsxUI : Interfaces.IInteractable
    {
        public string FileToRead { get; private set; }

        public string FileToSave { get; private set; }

        public uint Row { get; set; }

        public char Column { get; set; }

        private char RangeOfColumns;

        private WorkBook workBook;

        private WorkSheet workSheet;

        public FileXlsxUI(string fileToRead, string fileToSave, uint row, char column)
        {
            if (!string.IsNullOrEmpty(fileToRead) && !fileToRead.Equals(fileToSave))
            {
                FileToRead = $"{fileToRead}.xlsx";
                FileToSave = $"{fileToSave}.xlsx";
                if (File.Exists(FileToRead))
                {
                    workBook = WorkBook.Load(FileToRead);
                    workSheet = workBook.DefaultWorkSheet;
                }
                else
                {
                    workBook = WorkBook.Create(ExcelFileFormat.XLSX);
                    workSheet = workBook.CreateWorkSheet("Main");
                }

                Row = row == 0 ? row + 1 : row;
                Column = column;
                RangeOfColumns = Column;
            }
            else
            {
                throw new ArgumentException("Name of a file can not be null or empty and has the same name as another file!");
            }
        }

        public string Read()
        {
            var text = new StringBuilder("");
            foreach (var cell in workSheet[$"A1:{RangeOfColumns}{Row}"])
            {
                if (!string.IsNullOrEmpty(cell.Text))
                {
                    text.Append($"{(char)('A' + cell.ColumnIndex)}{cell.RowIndex + 1,-5} {cell.Text}\n");
                }
            }
            return text.ToString();
        }

        public void Write(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                workSheet[$"{Column}{Row}"].Value = input;
                Column++;
                RangeOfColumns = RangeOfColumns < Column ? Column : RangeOfColumns;
                workBook.SaveAs(FileToSave);
            }
        }

        public void WriteLine(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                workSheet[$"{Column}{Row}"].Value = input;
                Row++;
                Column = 'A';
                workBook.SaveAs(FileToSave);
            }
        }
    }
}
