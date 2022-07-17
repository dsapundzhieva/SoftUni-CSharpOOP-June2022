
namespace WildFarm.IO
{
    using System;
    using System.IO;
    using Interfaces;

    public class FileWriter : IWriter
    {
        private string fileContent;

        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
            this.fileContent = File.ReadAllText(filePath);
        }

        public string FilePath { get; set; }

        public void Write(string text)
        {
            string output = this.fileContent + text;
            File.WriteAllText(this.FilePath, output);
            this.fileContent = output;
        }

        public void WriteLine(string text)
        {
            string output = this.fileContent + text + Environment.NewLine;
            File.WriteAllText(this.FilePath, output);
            this.fileContent = output;
        }
    }
}
