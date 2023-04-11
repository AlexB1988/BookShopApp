using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Logging
{
    public class LoggerService<T> : ILoggerService<T> where T : class
    {
        private Logger _logger = LogManager.GetLogger(typeof(T).FullName);

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(Exception ex)
        {
            _logger.Error($"{ex.GetType()}=>{ex.Message}");
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }
    }
}
