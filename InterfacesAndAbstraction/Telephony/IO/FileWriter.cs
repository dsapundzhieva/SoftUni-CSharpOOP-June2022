namespace Telephony.IO
{
    using System;

    using System.IO;

    using IO.Interfaces;

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
            string ouput = this.fileContent + text;
            File.WriteAllText(this.FilePath, ouput);
            this.fileContent = ouput;
        }

        public void WriteLine(string text)
        {
            string ouput = this.fileContent + text + Environment.NewLine;
            File.WriteAllText(this.FilePath, ouput);
            this.fileContent = ouput;
        }
    }
}
