using System;
using System.Collections.Generic;
using System.Text;
using Streams.Interfaces;
namespace Streams
{
    public class FileSearcher
    {
        public string FileName { get; set; }
        public FileSearcher(string fileName) {
            FileName = fileName;
        }
        //private string Search(string fileName)
        //{

        //}
        //public bool SearchFile()
        //{
        //    Search(FileName);
        //}
    }
}
