using LoggerApp.Enums;

namespace LoggerApp.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string timeStamp, ReportLevel reportLevel, string message);
    }
}
