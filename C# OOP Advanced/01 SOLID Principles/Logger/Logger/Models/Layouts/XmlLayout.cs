using LoggerApp.Contracts;
using LoggerApp.Enums;
using System.Text;

namespace LoggerApp.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string timeStamp, ReportLevel reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();

            return sb.AppendLine("<log>")
                .AppendLine($"    <date>{timeStamp}</date>")
                .AppendLine($"    <date>{reportLevel}</date>")
                .AppendLine($"    <date>{message}</date>")
                .Append("</log>")
                .ToString();
        }
    }
}
