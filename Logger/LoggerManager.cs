using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Logger
{
    public static class LoggerManager
    {

        static LoggerManager()
        {
            XmlConfigurator.Configure(new FileInfo("Log.config"));
        }

        public static LoggerClass GetLogger(Type type)
        {
            return new LoggerClass(type);
        }
    }
}
