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

        private By toXpath = By.XPath("//div[@aria-label=\"To\"]//input");

        private By collapseXpath = By.XPath("(//*[contains(@alt,\"Minimize\")])");
        private By sendButtonXpath = By.XPath("(//*[contains(@aria-label,\"Send\")])[2]");

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
            ClickOnButton(By.XPath($"//div[contains(text(),'{option}')]"));
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
        public ComposeMessagePage VerfiyDraftMailSameAsExpected(string mailAdressTo, string subject, string bodyMail)
        {
            mailAdressTo.Equals(GetTextFromField(By.XPath($"//span[@email=\"{mailAdressTo}\"]")));
            subject.Equals(GetTextFromField(subjectXpath));
            bodyMail.Equals(GetTextFromField(bodyXpath));
            return new ComposeMessagePage();
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
        public ComposeMessagePage ExpandMail(String subject)
        {
            ClickOnButton(By.XPath($"(//span[contains(text(),'{subject}')])[2]"));
            return new ComposeMessagePage();
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
