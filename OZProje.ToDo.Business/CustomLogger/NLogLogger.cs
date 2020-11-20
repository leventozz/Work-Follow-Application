using NLog;
using OZProje.ToDo.Business.Interfaces;

namespace OZProje.ToDo.Business.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void AddErrorLog(string message)
        {
            var logger = LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
