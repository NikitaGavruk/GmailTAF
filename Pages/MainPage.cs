using GmailTA.WebDrvier;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GmailTA.Pages
{

    public class MainPage : AbstractPage
    {

        public By writeMailButtonXpath  = By.XPath("//*[text()=\"Compose\"]//ancestor::div[1]");
        public By draftsTabXpath  = By.XPath("//a[contains(@aria-label,\"Drafts\")]");
        public By sentPageXpath = By.XPath("//a[contains(@aria-label,\"Sent\")]");
        public By scheduledPageXpath = By.XPath("//a[contains(@aria-label,\"Scheduled\")]");
        
        private const string chooseAnAccountLink = "https://accounts.google.com/SignOutOptions";


        public MainPage() : base()
        {
        }
        public ComposeMessagePage ClickComposeButton()
        {
            ClickOnButton(writeMailButtonXpath);
            return new ComposeMessagePage();
        }

        public DraftPage NavigateToDraftPage()
        {
            ClickOnButton(draftsTabXpath);
            return new DraftPage();
        }
        public SentPage NavigateToSentPage()
        {
            ClickOnButton(sentPageXpath);
            return new SentPage();
        }
        public ScheduledSendPage NavigateToScheduledPage()
        {
            ClickOnButton(scheduledPageXpath);
            return new ScheduledSendPage();
        }
        public ChooseAnAccountPage NavigateToChooseAnAccoutPage()
        {
            Browser.GetDriver().Navigate().GoToUrl(chooseAnAccountLink);
            return new ChooseAnAccountPage();
        }


    }


}
