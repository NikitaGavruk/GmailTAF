using GmailTA.WebDrvier;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GmailTA.Pages
{
    public abstract class AbstractPage
    {
        protected readonly string subject = "Hi, take a new message!";
        protected readonly string bodyMail = "That is a message body";
        protected readonly string mailAdressTo = "gavruk1337@gmail.com";
        protected const String accoutEmail = "mikitaaaaaaaaaaaa@gmail.com";
        protected AbstractPage()
        {
        }


        public static void ClickOnButton(String xpath)
        {
            IsElementVisible(xpath);
            IsElementClickable(xpath);
            Browser.GetDriver().FindElement(By.XPath(xpath)).Click();
        }
        public static String GetTextFromField(String xpath)
        {
            IsElementVisible(xpath);
            return Browser.GetDriver().FindElement(By.XPath(xpath)).Text;
        }
        public static void InputTextInField(String xpath, String input)
        {
            IsElementVisible(xpath);
            Browser.GetDriver().FindElement(By.XPath(xpath)).SendKeys(input);
        }
        public static bool IsElementVisible(String xpath)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible((By.XPath(xpath))));
            return true;
        }
        public static bool IsPageLoadedByTitle(string title)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains(title));
            return true;
        }
        public static bool IsElementExists(String xpath)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
            return true;
        }
        public static bool IsElementClickable(String xpath)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable((By.XPath(xpath))));
            return true;
        }
        public static void MouseDown(String xpath)
        {
            IsElementClickable(xpath);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(By.XPath(xpath))).Click().Perform();
        }
        public static void InputTextInFieldByActions(String xpath, string keys)
        {
            IsElementVisible(xpath);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(By.XPath(xpath))).SendKeys(keys).Perform();
        }
        public static void InputTextInFieldByJS(string xpath, string keys)
        {
            IsElementVisible(xpath);
            Browser.GetJSExecuter().ExecuteScript($"arguments[0].value='{keys}';", Browser.GetDriver().FindElement(By.XPath(xpath)));
        }
        public static void MouseDownByJS(string xpath)
        {
            IsElementClickable(xpath);
            Browser.GetJSExecuter().ExecuteScript("arguments[0].click();", Browser.GetDriver().FindElement(By.XPath(xpath)));

        }
    }
 

}
