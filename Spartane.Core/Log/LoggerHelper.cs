using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
using log4net;
using System.IO;
using System.Web;

namespace Spartane.Core.Log
{
    public static class LoggerHelper
    {
         #region Fields

        private static readonly ILog log = LogManager.GetLogger(typeof(LoggerHelper));

        #endregion Fields

        #region Constructor

        static LoggerHelper()
        {
            Debug.WriteLine("Server Logger initializing...");

            log4net.Config.XmlConfigurator.Configure();

            if (log != null)
            {
                Debug.WriteLine("Server Logger initialized");
                Debug.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "Debug: {0}, Error: {1}, Info: {2}, Warning {3}",
                    log.IsDebugEnabled, log.IsErrorEnabled, log.IsInfoEnabled, log.IsWarnEnabled));
            }
            else
            {
                Debug.WriteLine("Failed initializing Server Logger");
            }
        }

        #endregion Constructor
        public static void LogInfo(string message, Exception ex)
        {
            if (ex != null)
                log.Info(message, ex);
            else
                log.Info(message);
        }

        public static void LogError(string message, Exception ex)
        {
            if (ex != null)
                log.Error(message, ex);
            else
                log.Error(message);
        }

        public static void LogFatal(string message, Exception ex)
        {
            if (ex != null)
                log.Fatal(message, ex);
            else
                log.Fatal(message);
        }
    }
}
