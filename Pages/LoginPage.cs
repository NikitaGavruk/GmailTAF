using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GmailTA.Pages
{

    public class LoginPage : AbstractPage
    {

        private const string logInField = "//input[@type=\"email\"]";
        private const string passwordField  = "//input[@type=\"password\"]";
        private const string nextButton  = "//span[text()=\"Next\"]";

        private const String password = "932Or%FxruWt";
        public LoginPage() : base()
        {
        }
        public LoginPage Login()
        {
            InputTextInFieldByActions(logInField, accoutEmail);
            MouseDown(nextButton);
            InputTextInFieldByJS(passwordField, password);
            MouseDownByJS(nextButton);
            return new LoginPage();
        }
        public bool IsLoginWasSuccessfull()
        {
            return IsElementVisible("(//span[contains(text(),'Gmail')])[1]");
        }

    }

}
