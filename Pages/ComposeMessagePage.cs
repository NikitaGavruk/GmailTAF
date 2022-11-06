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
        private const string subjectXpath = "(//input[contains(@name,\"subjectbox\")])";
        private const string bodyXpath = "(//div[contains(@aria-label,\"Message Body\")])";

        private const string toXpath = "//div[@aria-label=\"To\"]//input";

        private const string collapseXpath = "(//*[contains(@alt,\"Minimize\")])";
        private const string sendButtonXpath = "(//*[contains(@aria-label,\"Send\")])[2]";

        private const string sendOptionXpath = "//div[@aria-label=\"More send options\"]";
        private const string scheduledSend = "//div[@selector=\"scheduledSend\"]";
        public static string writeMailButtonXpath = "//*[text()=\"Compose\"]//ancestor::div[1]";
        private const string discardDraftXpath = "//div[contains(@aria-label,'Discard draft')]";
        private const string moreOptionXpath = "//div[@aria-label=\"More options\"]";
        private const string labelXpath = "//div[text()=\"Label\"]";
        private const string saveDraftMailXpath = "//img[@aria-label=\"Save & close\"]";
        public ComposeMessagePage() : base()
        {
        }

        public ComposeMessagePage FillFullMail(string mailAdressTo, string subject, string bodyMail)
        {
            ClickOnButton(writeMailButtonXpath);
            InputTextInField(toXpath, mailAdressTo);
            InputTextInField(subjectXpath, subject);
            InputTextInField(bodyXpath, bodyMail);
            return new ComposeMessagePage();
        }
        public ComposeMessagePage LabelEmail(string option)
        {
            ClickOnButton(moreOptionXpath);
            ClickOnButton(labelXpath);
            ClickOnButton($"//div[contains(text(),'{option}')]");
            return new ComposeMessagePage();
        }
        public ComposeMessagePage ClickScheduledSendOption()
        {
            ClickOnButton(sendOptionXpath);
            ClickOnButton(scheduledSend);
            return new ComposeMessagePage();

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
            mailAdressTo.Equals(GetTextFromField($"//span[@email=\"{mailAdressTo}\"]"));
            subject.Equals(GetTextFromField(subjectXpath));
            bodyMail.Equals(GetTextFromField(bodyXpath));
            return new ComposeMessagePage();
        }
        public ComposeMessagePage CollapseMail()
        {
            ClickOnButton(collapseXpath);

            return new ComposeMessagePage();
        }
        public ComposeMessagePage SaveDraftMail()
        {
            ClickOnButton(saveDraftMailXpath);
            return new ComposeMessagePage();
        }
        public ComposeMessagePage ExpandMail(String subject)
        {
            ClickOnButton($"(//span[contains(text(),'{subject}')])[2]");
            return new ComposeMessagePage();
        }
    }


}
