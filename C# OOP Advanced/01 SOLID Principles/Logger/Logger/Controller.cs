using LoggerApp.Contracts;
using LoggerApp.Enums;
using LoggerApp.Models.Appenders;
using LoggerApp.Models.Layouts;
using System;
using System.Linq;

namespace LoggerApp
{
    public class Controller
    {
        public void Start()
        {
            var numberOfAppenders = int.Parse(Console.ReadLine());

            var appenders = new IAppender[numberOfAppenders];
            string[] inputParams = null;           

            for (int i = 0; i < numberOfAppenders; i++)
            {
                inputParams = Console.ReadLine().Split();
                ILayout layoutType = null;
                IAppender appenderType = null;

                if (inputParams[1] == "SimpleLayout")
                {
                    layoutType = new SimpleLayout();
                }
                else if (inputParams[1] == "XmlLayout")
                {
                    layoutType = new XmlLayout();
                }

                if (inputParams[0] == "ConsoleAppender")
                {
                    appenderType = new ConsoleAppender(layoutType);
                }
                else if (inputParams[0] == "FileAppender")
                {
                    appenderType = new FileAppender(layoutType);
                }

                if (inputParams.Length == 3)
                {
                    var reportLevel = Enum.Parse<ReportLevel>(inputParams[2], true);
                    appenderType.ReportLevel = reportLevel;
                }

                appenders[i] = appenderType;
            }

            while (true)
            {
                inputParams = Console.ReadLine().Split('|').ToArray();

                if (inputParams[0] == "END")
                {
                    break;
                }

                var reportLevel = Enum.Parse<ReportLevel>(inputParams[0], true);
                var time = inputParams[1];
                var message = inputParams[2];

                foreach (var appender in appenders)
                {
                    if (appender.ReportLevel <= reportLevel)
                    {
                        appender.Append(time, reportLevel, message);
                    }                  
                }
            }

            foreach (var item in appenders)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
