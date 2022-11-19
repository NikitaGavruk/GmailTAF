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


        private readonly By logout  = By.XPath("//button[@class=\"sign-out\"]");
        private readonly string accountInSignOutState = "//div[@data-identifier=\"{0}\"]//div[contains(text(),\"Signed out\")]";
        public static string chooseAnAccountLink = "http://accounts.google.com/SignOutOptions";

        public ChooseAnAccountPage() : base()
        {
        }
        public ChooseAnAccountPage LogoutFromAccount()
        {
            ClickOnButton(logout);
            return new ChooseAnAccountPage();
        }
        public bool VerfiyLogoutIsSuccessfull()
        {
            return IsElementVisible(FormatXpath(accountInSignOutState, accoutEmail));
        }

    }

}
