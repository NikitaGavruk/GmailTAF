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

    public class ChooseAnAccountPage : AbstractPage
    {


        private readonly By signOutButton  = By.XPath("//button[@class=\"sign-out\"]");
        private readonly string signedOutLabelXpath = "//div[@data-identifier=\"{0}\"]//div[contains(text(),\"Signed out\")]";
        public static string chooseAnAccountLink = "http://accounts.google.com/SignOutOptions";

        public ChooseAnAccountPage() : base()
        {
        }
        public ChooseAnAccountPage ClickLogoutButton()
        {
            WebDriverExtension.ClickOnButton(signOutButton);
            return new ChooseAnAccountPage();
        }
        public bool VerfiyLogoutIsSuccessfull(User user)
        {
            return WebDriverExtension.IsElementVisible(WebUtils.FormatXpath(signedOutLabelXpath, user.DataUser[0]));
        }

    }

}
