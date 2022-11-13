using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class ScheduledSendPage : AbstractPage
    {
        private By cancelSendButtonXpath = By.XPath("//button[contains(text(),'Cancel send')]");
        public ScheduledSendPage() : base()
        {
        }

        public bool VerfiyMailAsScheduled(string subject)
        {
            return IsElementVisible(By.XPath($"(//div[text()=\"Messages in Scheduled will be sent at their scheduled time.\"]//ancestor::div[2]//span[contains(text(),'{subject}')])[2]"));
        }
        public ScheduledSendPage ChooseEmailBySubject(string subject)
        {
            ClickOnButton(By.XPath($"(//div[text()=\"Messages in Scheduled will be sent at their scheduled time.\"]//ancestor::div[2]//span[contains(text(),'{subject}')])[2]"));
            return new ScheduledSendPage();
        }
        public bool VerfiyMessageSameAsExpected(string subject, string bodyMail)
        {
            IsElementVisible(By.XPath($"(//div[contains(text(),'{bodyMail}')])"));
            IsElementVisible(By.XPath($"(//h2[contains(text(),'{subject}')])[1]"));
            return true;
        }
        public bool VerfiyScheduleTimeOption(String scheduledOption)
        {
            IsElementVisible(By.XPath($"(//span[contains(text(),'{scheduledOption}')])[1]"));
            return true;
        }
        public ScheduledSendPage CancelSend()
        {
            ClickOnButton(cancelSendButtonXpath);
            return new ScheduledSendPage();
        }
    }


}
