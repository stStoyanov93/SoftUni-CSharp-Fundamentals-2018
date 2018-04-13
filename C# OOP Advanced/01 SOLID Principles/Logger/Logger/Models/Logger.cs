using LoggerApp.Contracts;
using LoggerApp.Enums;
using System.Text;

namespace LoggerApp.Models
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        private void Log (string timeStamp, ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.appenders)
            {
                if (appender.ReportLevel <= reportLevel)
                {
                    appender.Append(timeStamp, reportLevel, message);
                }
             
            }
        }

        public void Error(string timeStamp, string message)
        {
            this.Log(timeStamp, ReportLevel.Error, message);
        }

        public void Info(string timeStamp, string message)
        {
            this.Log(timeStamp, ReportLevel.Info, message);
        }

        public void Fatal(string timeStamp, string message)
        {
            this.Log(timeStamp, ReportLevel.Fatal, message);
        }

        public void Critical(string timeStamp, string message)
        {
            this.Log(timeStamp, ReportLevel.Critical, message);
        }

        public void Warn(string timeStamp, string message)
        {
            this.Log(timeStamp, ReportLevel.Warning, message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");

            foreach (var item in this.appenders)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
