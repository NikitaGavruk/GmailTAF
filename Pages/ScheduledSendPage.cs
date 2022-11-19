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
        public static readonly string mailWithSubjectInScheduledFolderXpath = "(//div[text()=\"Messages in Scheduled will be sent at their scheduled time.\"]//ancestor::div[2]//span[contains(text(),'{0}')])[2]";
        private string openedMailWithSubjectInScheduledFolder = "(//h2[contains(text(),'{0}')])[1]";
        private string openedMailWithMailToInScheduledFolder = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//span[contains(@data-hovercard-id,\"{0}\")]";
        private string openedMailWithBodyInScheduledFolder = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//div[contains(text(),\"{0}\")]";
        private string scheduleOptionXpath = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//span[contains(@title,'{0}')]";
        public ScheduledSendPage() : base()
        {
        }


        public bool IsOpenedMailInScheduledFolderSameAsExpected(string mailTo, string subject, string body)
        {
            var isAdressSame = IsElementVisible(FormatXpath(openedMailWithMailToInScheduledFolder, mailTo));
            var isSubjectSame = IsElementVisible(FormatXpath(openedMailWithSubjectInScheduledFolder, subject));
            var isBodySame = IsElementVisible(FormatXpath(openedMailWithBodyInScheduledFolder, body));
            return isAdressSame && isSubjectSame && isBodySame;
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
        private By dateXpath = By.XPath("//input[@aria-label=\"Date\"]");
        private By timeXpath = By.XPath("//input[@aria-label=\"Time\"]");
        private By scheduledSendButtonXpath = By.XPath("//button[text()=\"Schedule send\"]");
        public ScheduledSendTab()
        {
        }

        public ScheduledSendTab ChooseEmailSendSchedule(String scheduledOption)
        {
            ClickOnButton(By.XPath($"//div[text()=\"{scheduledOption}\"]"));
            return new ScheduledSendTab();
        }
        public ScheduledSendTab ChooseDate(string month, string day, string year, string time)
        {
            InputTextInFieldByJS(dateXpath, month + " " + day + ", " + year);
            InputTextInFieldByJS(timeXpath, time);
            return new ScheduledSendTab();
        }
        public ScheduledSendTab ClickScheduledSend()
        {
            ClickOnButton(scheduledSendButtonXpath);
            return new ScheduledSendTab();
        }
    }

}
