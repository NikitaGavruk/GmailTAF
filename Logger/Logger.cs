using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
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
        public static ExtentReports ConfigureHTMLReport()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            ExtentReports   _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
            return _extent;
        }
        public static void FlushHTMLReport(ExtentReports _extent)
        {
            _extent.Flush();
        }
    }
}

