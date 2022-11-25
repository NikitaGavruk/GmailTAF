using GmailTA.Entities;
using GmailTA.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class ComposeMessageDialog : AbstractPage
    {
        private By subjectBoxFieldXpath = By.XPath("(//input[contains(@name,\"subjectbox\")])");
        private By messageBodyFieldXpath = By.XPath("(//div[contains(@aria-label,\"Message Body\")])");
        private string emailLabelOption = "//div[contains(text(),'{0}')]";
        private By toFieldXpath = By.XPath("//div[@aria-label=\"To\"]//input");
        private By minimizeButtonXpath = By.XPath("(//*[contains(@alt,\"Minimize\")])");
        private By sendButtonXpath = By.XPath("//div[@role='dialog']//*[contains(@aria-label, \"Send\")]");
        // Second xpath for "To" field is needed, because field xpath is changing after input value in field
        private By mailToFieldXpath = By.XPath("//span[@email]");
        private By moreSendOptionButtonXpath = By.XPath("//div[@aria-label=\"More send options\"]");
        private By scheduledSendOption = By.XPath("//div[text()=\"Schedule send\"]");
        private By discardDraftButtonXpath = By.XPath("//div[contains(@aria-label,'Discard draft')]");
        private By moreOptionButtonXpath = By.XPath("//div[@aria-label=\"More options\"]");
        private By labelListButtonXpath = By.XPath("//div[text()=\"Label\"]");
        private By saveAndCloseMailButtonXpath = By.XPath("//img[@aria-label=\"Save & close\"]");
        public ComposeMessageDialog() : base()
        {
        }

        public ComposeMessageDialog InputValueInToField(string to)
        {
            WebDriverExtension.InputTextInField(toFieldXpath, to);
            return new ComposeMessageDialog();
        
        }
        public ComposeMessageDialog InputValueInSubjectField(string subject)
        {
            WebDriverExtension.InputTextInField(subjectBoxFieldXpath, subject);
            return new ComposeMessageDialog();

        }
        public ComposeMessageDialog InputValueInBodyField(string body)
        {
            WebDriverExtension.InputTextInField(messageBodyFieldXpath, body);
            return new ComposeMessageDialog();

        }
        public ComposeMessageDialog ClickOnMoreButton()
        {
            WebDriverExtension.ClickOnButton(moreOptionButtonXpath);
            return new ComposeMessageDialog();
        }
        public ComposeMessageDialog ClickOnLabelList()
        {
            WebDriverExtension.ClickOnButton(labelListButtonXpath);
            return new ComposeMessageDialog();
        }
        public ComposeMessageDialog ChooseLabelOption(string option)
        {
            WebDriverExtension.ClickOnButton(WebUtils.FormatXpath(emailLabelOption,option));
            return new ComposeMessageDialog();
        }
        public ScheduledSendDialog ClickMoreSendOptionButton()
        {
            WebDriverExtension.ClickOnButton(moreSendOptionButtonXpath);
            return new ScheduledSendDialog();

        }
        public ScheduledSendDialog ClickScheduledSendButton()
        {
            WebDriverExtension.ClickOnButton(scheduledSendOption);
            return new ScheduledSendDialog();

        }
        public MainPage DiscardDraft()
        {
            WebDriverExtension.ClickOnButton(discardDraftButtonXpath);
            return new MainPage();
        }
        public MainPage SendMail()
        {
            WebDriverExtension.ClickOnButton(sendButtonXpath);

            return new MainPage();
        }
        public bool IsMessageHasExpectedTo(string to)
        {
            var isAdressSame = to.Equals(WebDriverExtension.GetTextFromField(mailToFieldXpath));
            return isAdressSame;
        }
        public bool IsMessageHasExpectedSubject(string subject)
        {
            var isSubjectSame = subject.Equals(WebDriverExtension.GetAttributeValueFromField(subjectBoxFieldXpath, "value"));
            return isSubjectSame;
        }
        public bool IsMessageHasExpectedBody(string body)
        {
            var isBodySame = body.Equals(WebDriverExtension.GetTextFromField(messageBodyFieldXpath));
            return isBodySame;
        }
        public MainPage ClickCollapseMailButton()
        {
            WebDriverExtension.ClickOnButton(minimizeButtonXpath);
            return new MainPage();
        }
        public MainPage ClickSaveAndCloseMail()
        {
            WebDriverExtension.ClickOnButton(saveAndCloseMailButtonXpath);
            return new MainPage();
        }
    }


}
