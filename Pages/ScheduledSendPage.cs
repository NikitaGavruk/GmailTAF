using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class ScheduledSendPage : AbstractPage
    {
        private const string cancelSendButtonXpath = "//button[contains(text(),'Cancel send')]";
        public ScheduledSendPage() : base()
        {
        }

        public bool VerfiyMailAsScheduled(string subject)
        {
            return IsElementVisible($"(//div[text()=\"Messages in Scheduled will be sent at their scheduled time.\"]//ancestor::div[2]//span[contains(text(),'{subject}')])[2]");
        }
        public ScheduledSendPage ChooseEmailBySubject(string subject)
        {
            ClickOnButton($"(//div[text()=\"Messages in Scheduled will be sent at their scheduled time.\"]//ancestor::div[2]//span[contains(text(),'{subject}')])[2]");
            return new ScheduledSendPage();
        }
        public bool VerfiyMessageSameAsExpected(string subject, string bodyMail)
        {
            IsElementVisible($"(//div[contains(text(),'{bodyMail}')])");
            IsElementVisible($"(//h2[contains(text(),'{subject}')])[1]");
            return true;
        }
        public bool VerfiyScheduleTimeOption(String scheduledOption)
        {
            IsElementVisible($"(//span[contains(text(),'{scheduledOption}')])[1]");
            return true;
        }
        public ScheduledSendPage CancelSend()
        {
            ClickOnButton(cancelSendButtonXpath);
            return new ScheduledSendPage();
        }
    }
    public class ScheduledSendTab : AbstractPage
    {
        public ScheduledSendTab()
        {
        }

        public ScheduledSendTab ChooseEmailSendSchedule(String scheduledOption)
        {
            ClickOnButton($"//div[text()=\"{scheduledOption}\"]");
            return new ScheduledSendTab();
        }
    }

}
