using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using GmailTA.WebDrvier;
using log4net;
using GmailTA.Logger;
using NUnit.Framework.Interfaces;

namespace GmailTA.Test
{
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance;
        protected LoggerClass Log;
        [SetUp]
        public void Setup()
        {
            this.Log = LoggerManager.GetLogger(this.GetType());
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TearDown]
        public void Quite()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                this.Log.Error("Test found error. Screenshots has been taken", TestContext.CurrentContext.Result.Outcome.ToString());
                ScreenshotTaker.TakeScreenshot(Path.Combine(Environment.CurrentDirectory, "Screenshots"), TestContext.CurrentContext.Test.Name);
            }
            Browser.QuiteBrowser();
        }
    }
}