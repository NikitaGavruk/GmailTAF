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
                        ChromeOptions Options = new ChromeOptions();
                        Options.PlatformName = "windows 10";
                        webDriver = new RemoteWebDriver(
                                                  new Uri("http://localhost:4444"), Options.ToCapabilities(), TimeSpan.FromSeconds(600));
                        break;
                    }
                case BrowserType.RemoteFirefox:
                    {
                        FirefoxOptions Options = new FirefoxOptions();
                        Options.PlatformName = "windows 10";
                        webDriver = new RemoteWebDriver(
                                                  new Uri("http://localhost:4444"), Options.ToCapabilities(), TimeSpan.FromSeconds(600));
                        break;
                    }
            }
            return webDriver;
        }
    }
}