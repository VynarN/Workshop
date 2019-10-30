namespace Streams
{
    using System;
    using System.IO;
    using System.Text;

    public class FileUI: Interfaces.IInteractable
    {
        public string FilePath { get; private set; } = Directory.GetCurrentDirectory();

        public FileUI(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FilePath += $"//{filePath}.txt";
            }
            else
            {
                FilePath += $"//DefaultFileForResult.txt";
            }
        }

        public string Read()
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                StringBuilder text = new StringBuilder("");
                while (!reader.EndOfStream)
                {
                    text.Append(reader.ReadLine());
                }
                return text.ToString();
            }
        }

        public void Write(string text)
        {
            if (text != null)
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.Write(text);
                }
            }
        }

        public void WriteLine(string text)
        {
            if (text != null)
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}
