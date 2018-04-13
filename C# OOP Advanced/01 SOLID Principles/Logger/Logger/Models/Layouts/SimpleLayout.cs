using LoggerApp.Contracts;
using LoggerApp.Enums;

namespace LoggerApp.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string timeStamp, ReportLevel reportLevel, string message)
        {
            return $"{timeStamp} - {reportLevel} - {message}";
        }
    }
}
