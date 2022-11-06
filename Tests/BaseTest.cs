using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using GmailTA.WebDrvier;

namespace GmailTA.Test
{
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance;
        
        [SetUp]
        public void Setup()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TearDown]
        public void Quite()
        {
            Browser.QuiteBrowser();
        }
    }
}