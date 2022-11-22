using GmailTA.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class ScheduledSendDialog : AbstractPage
    {
        private By dateFieldXpath = By.XPath("//input[@aria-label=\"Date\"]");
        private By timeFieldXpath = By.XPath("//input[@aria-label=\"Time\"]");
        private By scheduledSendButtonXpath = By.XPath("//button[text()=\"Schedule send\"]");
        private string schudeledOptionTextXpath = "//div[text()=\"{0}\"]";
        public ScheduledSendDialog()
        {
        }

        public T ChooseEmailSendSchedule<T>(String scheduledOption) where T : AbstractPage
        {
            WebDriverExtension.ClickOnButton(WebUtils.FormatXpath(schudeledOptionTextXpath,scheduledOption));
            return (T)Activator.CreateInstance(typeof(T));
        }
        public ScheduledSendDialog ChooseDate(DateTime dateTime)
        {
            WebDriverExtension.InputTextInFieldByJS(dateFieldXpath, dateTime.ToString("MMM dd, yyyy", System.Globalization.CultureInfo.InvariantCulture));
            return new ScheduledSendDialog();
        }
        public ScheduledSendDialog ChooseTime(DateTime dateTime)
        {
            WebDriverExtension.InputTextInFieldByJS(timeFieldXpath, dateTime.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture));
            return new ScheduledSendDialog();
        }
        public MainPage ClickScheduledSend()
        {
            WebDriverExtension.ClickOnButton(scheduledSendButtonXpath);
            return new MainPage();
        }
    }
}
