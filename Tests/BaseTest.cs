using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using GmailTA.WebDrvier;
using log4net;
using GmailTA.Logger;
using NUnit.Framework.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using AventStack.ExtentReports;

namespace GmailTA.Test
{
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance;
        protected LoggerClass Log;
        protected ExtentReports _extent;
        protected ExtentTest _test;
        [SetUp]
        public void Setup()
        {
            Log = LoggerManager.GetLogger(this.GetType());
            _extent = LoggerClass.ConfigureHTMLReport();
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo(Configuration.StartUrl);

        }

        [TearDown]
        public void Quite()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Log.Error("Test found error. Screenshots has been taken", TestContext.CurrentContext.Result.Outcome.ToString());
                string screenshotpath = ScreenshotTaker.TakeScreenshot(Path.Combine(Environment.CurrentDirectory, "Screenshots"), TestContext.CurrentContext.Test.Name);
                _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenshotpath));

            }
            Log.Info("Test ended with " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
            _test.Log((Status)TestContext.CurrentContext.Result.Outcome.Status, "Test ended with status " + TestContext.CurrentContext.Result.Outcome.Status.ToString() + " Message:" + TestContext.CurrentContext.Result.Message);
            _extent.Flush();
            Browser.QuiteBrowser();
        }
    }
}