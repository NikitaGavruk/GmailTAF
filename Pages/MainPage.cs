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

        private By composeMailButtonXpath  = By.XPath("//*[text()=\"Compose\"][@role='button']");
        private string folderXpath = "//a[text() =\"{0}\"]";
        private static readonly string draftsName = "Drafts";
        private static readonly string sentName = "Sent";
        private static readonly string scheduledName = "Scheduled";


        public MainPage() : base()
        {
        }
        public ComposeMessageDialog ClickComposeButton()
        {
            ClickOnButton(composeMailButtonXpath);
            return new ComposeMessageDialog();
        }
        public T ClickOnFolder<T>(string folderName) where T : AbstractPage
        {
            ClickOnButton(FormatXpath(folderXpath, folderName));
            return (T)Activator.CreateInstance(typeof(T));
        }

    }


}
