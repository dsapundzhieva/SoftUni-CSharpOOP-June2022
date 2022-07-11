
namespace Telephony.IO
{
    using System.IO;

    using System.Linq;

    using IO.Interfaces;

    public class FileReader : IReader
    {
        private readonly string[] allLines;
        private int lineNum;

        public FileReader(string filePath)
        {
            this.FilePath = filePath;
            this.allLines = File.ReadAllLines(filePath);
            this.lineNum = 0;
        }

        public string FilePath { get; set; }

        public string ReadLine()
        {
            if (!HasMoreLines())
            {
                return null;
            }
            return this.allLines
                .Skip(lineNum++)
                .Take(1)
                .First();
        }

        private bool HasMoreLines()
        {
            return lineNum < allLines.Length;
        }
    }
}
