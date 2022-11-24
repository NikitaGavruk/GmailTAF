using GmailTA.Entities;
using GmailTA.Utils;
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
        public static readonly string draftsName = "Drafts";
        public static readonly string sentName = "Sent";
        public static readonly string scheduledName = "Scheduled";
        private string emailIconElementXpath = "//a[contains(@aria-label,\"{0}\")]";


        public MainPage() : base()
        {
        }
        public bool IsLoginWasSuccessfull(User user)
        {
            return WebDriverExtension.IsElementExists(WebUtils.FormatXpath(emailIconElementXpath, user.Email));
        }
        public ComposeMessageDialog ClickComposeButton()
        {
            WebDriverExtension.ClickOnButton(composeMailButtonXpath);
            return new ComposeMessageDialog();
        }
        public T ClickOnFolder<T>(string folderName) where T : BaseFolderPage
        {
            WebDriverExtension.ClickOnButton(WebUtils.FormatXpath(folderXpath, folderName));
            return (T)Activator.CreateInstance(typeof(T));
        }

    }


}
