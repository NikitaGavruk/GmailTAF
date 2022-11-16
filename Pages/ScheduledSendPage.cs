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
        private string mailWithSubjectInScheduledFolderXpath = "(//div[text()=\"Messages in Scheduled will be sent at their scheduled time.\"]//ancestor::div[2]//span[contains(text(),'{0}')])[2]";
        private string openedMailWithSubjectInScheduledFolder = "(//h2[contains(text(),'{0}')])[1]";
        private string scheduleOptionXpath = "(//span[contains(text(),'{0}')])[1]";
        public ScheduledSendPage() : base()
        {
        }

        public bool VerfiyMailExistsInScheduledFolder(string subject)
        {
            return IsElementVisible(FormatXpath(mailWithSubjectInScheduledFolderXpath,subject));
        }
        public ScheduledSendPage ChooseEmailBySubject(string subject)
        {
            ClickOnButton(FormatXpath(mailWithSubjectInScheduledFolderXpath, subject));
            return new ScheduledSendPage();
        }
        public bool IsOpenedMailInScheduledFolderSameAsExpected(string subject)
        {
            return IsElementVisible(FormatXpath(openedMailWithSubjectInScheduledFolder, subject));
        }
        public bool IsScheduledOptionSameAsExpected(string scheduledOption)
        {
            return IsElementVisible(FormatXpath(scheduleOptionXpath, scheduledOption));
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
            ClickOnButton(By.XPath($"//div[text()=\"{scheduledOption}\"]"));
            return new ScheduledSendTab();
        }
    }

}
