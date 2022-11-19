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

        private By writeMailButtonXpath  = By.XPath("//*[text()=\"Compose\"][@role='button']");
        public static readonly By draftsTabXpath  = By.XPath("//a[contains(@aria-label,\"Drafts\")]");
        public static readonly By sentPageXpath = By.XPath("//a[contains(@aria-label,\"Sent\")]");
        public static readonly By scheduledPageXpath = By.XPath("//a[contains(@aria-label,\"Scheduled\")]");
        


        public MainPage() : base()
        {
        }
        public ComposeMessagePage ClickComposeButton()
        {
            ClickOnButton(writeMailButtonXpath);
            return new ComposeMessagePage();
        }


    }


}
