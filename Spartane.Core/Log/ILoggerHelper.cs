using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Log
{
    public partial interface ILoggerHelper
    {
        void LogInfo(string message, Exception ex = null);
        void LogError(string message, Exception ex = null);
        void LogFatal(string message, Exception ex = null);
    }
}
