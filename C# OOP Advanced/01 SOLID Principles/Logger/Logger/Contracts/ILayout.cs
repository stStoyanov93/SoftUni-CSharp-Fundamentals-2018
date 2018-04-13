using LoggerApp.Enums;

namespace LoggerApp.Contracts
{
    public interface ILayout
    {
        string FormatMessage(string timeStamp, ReportLevel reportLevel, string message);
    }
}
