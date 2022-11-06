using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.WebDrvier
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        RemoteChrome,
        RemoteFirefox

    }
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(BrowserType browser, int timeOutSec)
        {
            IWebDriver webDriver = null;
            switch (browser)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        webDriver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        webDriver = new FirefoxDriver();
                        break;
                    }
                case BrowserType.RemoteChrome:
                    {
                        ChromeOptions capabilities = new ChromeOptions();
                        capabilities.BrowserVersion = "latest";
                        Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                        browserstackOptions.Add("os", "Windows");
                        browserstackOptions.Add("osVersion", "11");
                        browserstackOptions.Add("local", "false");
                        browserstackOptions.Add("seleniumVersion", "3.14.0");
                        browserstackOptions.Add("browserName", "Chrome");
                        capabilities.AddAdditionalOption("bstack:options", browserstackOptions);
                        webDriver = new RemoteWebDriver(new Uri("http://localhost:5555"), capabilities);
                        break;
                    }
                case BrowserType.RemoteFirefox:
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.AddAdditionalFirefoxOption(CapabilityType.BrowserName, "firefox");
                        options.AddAdditionalFirefoxOption(CapabilityType.PlatformName, new Platform(PlatformType.XP));
                        webDriver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), options);
                        break;
                    }
            }
            return webDriver;
        }
    }
}