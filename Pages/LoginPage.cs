using GmailTA.Utils;
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

        private By loginField = By.Name("identifier");
        private By passwordField  = By.XPath("//input[@type=\"password\"]");
        private By nextButton  = By.XPath("//span[text()=\"Next\"]");
        public LoginPage() : base()
        {
        }
        public LoginPage InputEmail(string accountEmail)
        {
            WebDriverExtension.InputTextInFieldByJS(loginField, accountEmail);
            return new LoginPage();
        }
        public LoginPage InputPassword(string passwrod)
        {
            WebDriverExtension.InputTextInFieldByActions(passwordField, passwrod);
            return new LoginPage();
        }
        public T ClickOnNextButton<T>() where T : class
        {
            WebDriverExtension.MouseDownByJS(nextButton);
            return (T)Activator.CreateInstance(typeof(T));
        }

    }

}
