using GmailTA.WebDrvier;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace GmailTA.Pages
{
    public abstract class AbstractPage
    {
        protected const string password = "932Or%FxruWt";
        protected const string accoutEmail = "mikitaaaaaaaaaaaa@gmail.com";
        protected AbstractPage()
        {
        }


        public static void ClickOnButton(By xpath)
        {
            IsElementVisible(xpath);
            IsElementClickable(xpath);
            Browser.GetDriver().FindElement(xpath).Click();
        }
        public static String GetTextFromField(By xpath)
        {
            IsElementVisible(xpath);
            return Browser.GetDriver().FindElement(xpath).Text;
        }
        public static void InputTextInField(By xpath, String input)
        {
            IsElementVisible(xpath);
            Browser.GetDriver().FindElement(xpath).SendKeys(input);
        }
        public static bool IsElementVisible(By xpath)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(xpath));
            return true;
        }
        public static bool IsElementExists(By xpath)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(xpath));
            return true;
        }
        public static bool IsElementClickable(By xpath)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(xpath));
            return true;
        }
        public static void MouseDown(By xpath)
        {
            IsElementClickable(xpath);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(xpath)).Click().Perform();
        }
        public static void InputTextInFieldByActions(By xpath, string keys)
        {
            IsElementVisible(xpath);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(xpath)).SendKeys(keys).Perform();
        }
        public static void InputTextInFieldByJS(By xpath, string keys)
        {
            IsElementVisible(xpath);
            Browser.GetJSExecuter().ExecuteScript($"arguments[0].value='{keys}';", Browser.GetDriver().FindElement(xpath));
        }
        public static void MouseDownByJS(By xpath)
        {
            IsElementClickable(xpath);
            Browser.GetJSExecuter().ExecuteScript("arguments[0].click();", Browser.GetDriver().FindElement(xpath));

        }
    }
 

}
