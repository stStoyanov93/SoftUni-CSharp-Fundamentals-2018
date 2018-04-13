using LoggerApp.Contracts;
using System;
using LoggerApp.Enums;

namespace LoggerApp.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.CountOfMessagesAppended = 0;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int CountOfMessagesAppended { get; private set; }

        public void Append(string timeStamp, ReportLevel reportLevel, string message)
        {
            string formattedMessage = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            Console.WriteLine(formattedMessage);
            CountOfMessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {CountOfMessagesAppended}";
        }
    }
}
