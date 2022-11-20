using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class ScheduledFolderPage : BaseFolderPage
    {
        private By cancelSendButtonXpath = By.XPath("//button[contains(text(),'Cancel send')]");
        private string openedMailSubjectField = "(//h2[contains(text(),'{0}')])[1]";
        private string openedMailMailToField = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//span[contains(@data-hovercard-id,\"{0}\")]";
        private string openedMailBodyField = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//div[contains(text(),\"{0}\")]";
        private string messageScheduledLabelXpath = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//span[contains(@title,'{0}')]";
        public ScheduledFolderPage() : base()
        {
        }


        public bool IsOpenedMailInScheduledFolderSameAsExpected(string mailTo, string subject, string body)
        {
            var isAdressSame = IsElementVisible(FormatXpath(openedMailMailToField, mailTo));
            var isSubjectSame = IsElementVisible(FormatXpath(openedMailSubjectField, subject));
            var isBodySame = IsElementVisible(FormatXpath(openedMailBodyField, body));
            return isAdressSame && isSubjectSame && isBodySame;
        }
        public bool IsScheduledOptionSameAsExpected(string scheduledOption)
        {
            return IsElementVisible(FormatXpath(messageScheduledLabelXpath, scheduledOption));
        }
        public ScheduledFolderPage CancelSend()
        {
            ClickOnButton(cancelSendButtonXpath);
            return new ScheduledFolderPage();
        }
    }
}
