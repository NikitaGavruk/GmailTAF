using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Logger
{
    public class LoggerClass
    {
        private readonly ILog log;

        internal LoggerClass(Type type)
        {
            this.log = LogManager.GetLogger(type);
        }

        public void Info(string message)
        {
            this.log.Info(message);
        }
        public void Debug(string methodName, string parameters)
        {
            this.log.Debug(methodName + " " + parameters);
        }

        public void Error(string message, string error)
        {
            this.log.Error(message + " " + error);
        }
    }
}

