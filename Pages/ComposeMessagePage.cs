using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class ComposeMessagePage : AbstractPage
    {
        private By subjectXpath = By.XPath("(//input[contains(@name,\"subjectbox\")])");
        private By bodyXpath = By.XPath("(//div[contains(@aria-label,\"Message Body\")])");
        private string emailLabelOption = "//div[contains(text(),'{0}')]";
        private By toXpath = By.XPath("//div[@aria-label=\"To\"]//input");
        private By collapseXpath = By.XPath("(//*[contains(@alt,\"Minimize\")])");
        private By sendButtonXpath = By.XPath("//div[@role='dialog']//*[contains(@aria-label,\"Send\")]");
        private By mailToXpath = By.XPath("//div[@role='dialog']//span[@email]");
        private By sendOptionXpath = By.XPath("//div[@aria-label=\"More send options\"]");
        private By scheduledSend = By.XPath("//div[@selector=\"scheduledSend\"]");
        private By discardDraftXpath = By.XPath("//div[contains(@aria-label,'Discard draft')]");
        private By moreOptionXpath = By.XPath("//div[@aria-label=\"More options\"]");
        private By labelXpath = By.XPath("//div[text()=\"Label\"]");
        private By saveDraftMailXpath = By.XPath("//img[@aria-label=\"Save & close\"]");
        public ComposeMessagePage() : base()
        {
        }

        public ComposeMessagePage FillFullMail(string mailAdressTo, string subject, string bodyMail)
        {
            InputTextInField(toXpath, mailAdressTo);
            InputTextInField(subjectXpath, subject);
            InputTextInField(bodyXpath, bodyMail);
            return new ComposeMessagePage();
        }
        public ComposeMessagePage LabelEmail(string option)
        {
            ClickOnButton(moreOptionXpath);
            ClickOnButton(labelXpath);
            ClickOnButton(FormatXpath(emailLabelOption,option));
            return new ComposeMessagePage();
        }
        public ScheduledSendTab ClickScheduledSendOption()
        {
            ClickOnButton(sendOptionXpath);
            ClickOnButton(scheduledSend);
            return new ScheduledSendTab();

        }
        public ComposeMessagePage DiscardDraft()
        {
            ClickOnButton(discardDraftXpath);
            return new ComposeMessagePage();
        }
        public ComposeMessagePage SendMail()
        {
            ClickOnButton(sendButtonXpath);

            return new ComposeMessagePage();
        }
        public bool IsMessageHasExpectedValuesInFields(string mailAdressTo, string subject, string bodyMail)
        {
            var isAdressSame = mailAdressTo.Equals(GetTextFromField(mailToXpath));
            var isSubjectSame = subject.Equals(GetAttributeValueFromField(subjectXpath, "value"));
            var isBodySame = bodyMail.Equals(GetTextFromField(bodyXpath));
            return isAdressSame && isSubjectSame && isBodySame;
        }
        public MainPage CollapseMail()
        {
            ClickOnButton(collapseXpath);
            return new MainPage();
        }
        public ComposeMessagePage SaveDraftMail()
        {
            ClickOnButton(saveDraftMailXpath);
            return new ComposeMessagePage();
        }
    }


}
