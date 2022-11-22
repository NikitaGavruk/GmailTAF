using GmailTA.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class ScheduledMailPage : MainPage
    {
        private By cancelSendButtonXpath = By.XPath("//button[contains(text(),'Cancel send')]");
        private string openedMailSubjectField = "(//h2[contains(text(),'{0}')])[1]";
        private string openedMailMailToField = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//span[contains(@data-hovercard-id,\"{0}\")]";
        private string openedMailBodyField = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//div[contains(text(),\"{0}\")]";
        private string messageScheduledLabelXpath = "//span[contains(text(),\"Send scheduled\")]//ancestor::div[3]//span[contains(@title,'{0}')]";
        public ScheduledMailPage() : base()
        {
        }

        public bool IsOpenedMailSubjectInScheduledFolderSameAsExpected(string subject)
        {
            var isSubjectSame = WebDriverExtension.IsElementVisible(WebUtils.FormatXpath(openedMailSubjectField, subject));
            return isSubjectSame;
        }
        public bool IsOpenedMailToInScheduledFolderSameAsExpected(string mailTo)
        {
            var isAdressSame = WebDriverExtension.IsElementVisible(WebUtils.FormatXpath(openedMailMailToField, mailTo));
            return isAdressSame;
        }
        public bool IsOpenedMailBodyInScheduledFolderSameAsExpected(string body)
        {
            var isBodySame = WebDriverExtension.IsElementVisible(WebUtils.FormatXpath(openedMailBodyField, body));
            return isBodySame;
        }
        public bool IsScheduledOptionSameAsExpected(DateTime scheduledOption)
        {
            return WebDriverExtension.IsElementVisible(WebUtils.FormatXpath(messageScheduledLabelXpath, scheduledOption.ToString("MMM %d, yyyy, h:mm tt", System.Globalization.CultureInfo.InvariantCulture)));
        }
        public ScheduledFolderPage CancelSend()
        {
            WebDriverExtension.ClickOnButton(cancelSendButtonXpath);
            return new ScheduledFolderPage();
        }
    }
}
