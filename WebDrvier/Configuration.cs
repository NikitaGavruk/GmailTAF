using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.WebDrvier
{
    public class Configuration
    {
        public static string GetEnviromentVar(string var, string defaultValue)
        {
            string configFile = $"{Assembly.GetExecutingAssembly().Location}.config";
            string outputConfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            File.Copy(configFile, outputConfigFile, true);
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }
        public static string ElementTimeout => GetEnviromentVar("ElementTimeout", "30");
        public static string Browser => GetEnviromentVar("Browser", "Chrome");
        public static string StartUrl => GetEnviromentVar("StartUrl", "https://www.google.com/gmail");


    }
}
