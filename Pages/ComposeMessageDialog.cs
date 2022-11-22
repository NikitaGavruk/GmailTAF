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
        private By sendButtonXpath = By.XPath("//div[@role='dialog']//*[contains(@aria-label,\"Send\")]");
        // Second xpath for "To" field is needed, because field xpath is changing after input value in field
        private By mailToFieldXpath = By.XPath("//div[@role='dialog']//span[@email]");
        private By moreSendOptionButtonXpath = By.XPath("//div[@aria-label=\"More send options\"]");
        private By scheduledSendOption = By.XPath("//div[text()=\"Schedule send\"]");
        private By discardDraftButtonXpath = By.XPath("//div[contains(@aria-label,'Discard draft')]");
        private By moreOptionButtonXpath = By.XPath("//div[@aria-label=\"More options\"]");
        private By labelListButtonXpath = By.XPath("//div[text()=\"Label\"]");
        private By saveAndCloseMailButtonXpath = By.XPath("//img[@aria-label=\"Save & close\"]");
        public ComposeMessageDialog() : base()
        {
        }

        public ComposeMessageDialog FillFullMail(Message patternMessage)
        {
            WebDriverExtension.InputTextInField(toFieldXpath, patternMessage.DataUser[0]);
            WebDriverExtension.InputTextInField(subjectBoxFieldXpath, patternMessage.DataUser[1]);
            WebDriverExtension.InputTextInField(messageBodyFieldXpath, patternMessage.DataUser[2]);
            return new ComposeMessageDialog();
        }
        public ComposeMessageDialog LabelEmail(string option)
        {
            WebDriverExtension.ClickOnButton(moreOptionButtonXpath);
            WebDriverExtension.ClickOnButton(labelListButtonXpath);
            WebDriverExtension.ClickOnButton(WebUtils.FormatXpath(emailLabelOption,option));
            return new ComposeMessageDialog();
        }
        public ScheduledSendDialog ClickScheduledSendOption()
        {
            WebDriverExtension.ClickOnButton(moreSendOptionButtonXpath);
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
        public bool IsMessageHasExpectedValuesInFields(Message patternMessage)
        {
            var isAdressSame = patternMessage.DataUser[0].Equals(WebDriverExtension.GetTextFromField(mailToFieldXpath));
            var isSubjectSame = patternMessage.DataUser[1].Equals(WebDriverExtension.GetAttributeValueFromField(subjectBoxFieldXpath, "value"));
            var isBodySame = patternMessage.DataUser[2].Equals(WebDriverExtension.GetTextFromField(messageBodyFieldXpath));
            return isAdressSame && isSubjectSame && isBodySame;
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
