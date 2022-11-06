using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.WebDrvier
{
    public class Browser
    {
        private static Browser _currentInstance;
        private static Actions _actions;
        private static IJavaScriptExecutor _jsExecuter;
        private static IWebDriver webDriver;
        public static BrowserType _currentBrowser;
        private static string _browser;
        private static int ImplWait;
        private static double _timeoutForElement;

        private Browser()
        {
            InitParams();
            webDriver = WebDriverFactory.GetDriver(_currentBrowser, 10);
        }
        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            _timeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
            _browser = Configuration.Browser;
            Enum.TryParse(_browser, out _currentBrowser);


        }
        public static Browser Instance => _currentInstance ?? (_currentInstance = new Browser());
        public static void WindowMaximaze()
        {
            webDriver.Manage().Window.Maximize();
        }
        public static void NavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
        public static IWebDriver GetDriver()
        {
            return webDriver;
        }
        public static Actions GetActions()
        {
            _actions = new Actions(GetDriver());
            return _actions;
        }
        public static IJavaScriptExecutor GetJSExecuter()
        {
            _jsExecuter = (IJavaScriptExecutor) GetDriver();
            return _jsExecuter;
        }
        public static void QuiteBrowser()
        {
            webDriver.Quit();
            _currentInstance = null;
            webDriver = null;
            _browser = null;
        }
    }
}
