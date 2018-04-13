using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerApp.Models
{
    public class LogFile
    {
        private const string DEFAULT_FILE_NAME = "log.txt";

        private StringBuilder strBuilder;

        public LogFile()
        {
            this.strBuilder = new StringBuilder();
        }

        public int Size { get; private set; } = 0;

        private int GetLettersSum(string message)
        {
            int sum = message.Where(c => char.IsLetter(c)).Sum(c => c);
            return sum;
        }

        public void Write(string formattedMessage)
        {
            this.Size += GetLettersSum(formattedMessage);

            this.strBuilder.AppendLine(formattedMessage);
            File.AppendAllText(DEFAULT_FILE_NAME, formattedMessage + Environment.NewLine);
        }
    }
}
