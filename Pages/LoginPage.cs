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

        private By logInField = By.Name("identifier");
        private By passwordField  = By.XPath("//input[@type=\"password\"]");
        private By nextButton  = By.XPath("//span[text()=\"Next\"]");

        public LoginPage() : base()
        {
        }
        public MainPage Login()
        {
            InputTextInFieldByActions(logInField, accoutEmail);
            MouseDown(nextButton);
            InputTextInFieldByJS(passwordField, password);
            MouseDownByJS(nextButton);
            return new MainPage();
        }
        public bool IsLoginWasSuccessfull()
        {
            return IsElementVisible(By.XPath($"//a[contains(@aria-label,\"{accoutEmail}\")]"));
        }

    }

}
