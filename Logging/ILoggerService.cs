using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Logging
{
    public interface ILoggerService<T> where T : class
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Trace(string message);
    }
}
