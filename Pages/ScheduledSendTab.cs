using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class ScheduledSendTab : AbstractPage
    {
        private By dateFieldXpath = By.XPath("//input[@aria-label=\"Date\"]");
        private By timeFieldXpath = By.XPath("//input[@aria-label=\"Time\"]");
        private By scheduledSendButtonXpath = By.XPath("//button[text()=\"Schedule send\"]");
        private string schudeledOptionTextXpath = "//div[text()=\"{0}\"]";
        public ScheduledSendTab()
        {
        }

        public ScheduledSendTab ChooseEmailSendSchedule(String scheduledOption)
        {
            ClickOnButton(FormatXpath(schudeledOptionTextXpath,scheduledOption));
            return new ScheduledSendTab();
        }
        public ScheduledSendTab ChooseDate(string month, string day, string year, string time)
        {
            InputTextInFieldByJS(dateFieldXpath, month + " " + day + ", " + year);
            InputTextInFieldByJS(timeFieldXpath, time);
            return new ScheduledSendTab();
        }
        public ScheduledSendTab ClickScheduledSend()
        {
            ClickOnButton(scheduledSendButtonXpath);
            return new ScheduledSendTab();
        }
    }
}
