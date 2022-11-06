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

    public class ChooseAnAccountPage : AbstractPage
    {


        private const string logout  = "//button[@class=\"sign-out\"]";
        private const string chooseAnAccountLink  = "https://accounts.google.com/SignOutOptions";
        public ChooseAnAccountPage() : base()
        {
        }
        public ChooseAnAccountPage LogoutFromAccount()
        {
            Browser.GetDriver().Navigate().GoToUrl(chooseAnAccountLink);
            ClickOnButton(logout);
            return new ChooseAnAccountPage();
        }
        public bool VerfiyLogoutIsSuccessfull()
        {
            return IsElementVisible($"(//div[@data-email=\"{accoutEmail}\"]//ancestor::div[1]//following-sibling::div)[2]");
        }

    }

}
