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


        protected static void ClickOnButton(By xpath)
        {
            WaitUntilElementIsVisible(xpath);
            WaitUntilElementIsClickable(xpath);
            Browser.GetDriver().FindElement(xpath).Click();
        }
        protected static string GetTextFromField(By xpath)
        {
            WaitUntilElementIsVisible(xpath);
            return Browser.GetDriver().FindElement(xpath).Text;
        }
        protected static string GetAttributeValueFromField(By xpath, string attribute)
        {
            WaitUntilElementIsVisible(xpath);
            return Browser.GetDriver().FindElement(xpath).GetAttribute(attribute);
        }
        protected static void InputTextInField(By xpath, String input)
        {
            WaitUntilElementIsVisible(xpath);
            Browser.GetDriver().FindElement(xpath).SendKeys(input);
        }
        protected static bool IsElementVisible(By xpath)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(6)).Until(ExpectedConditions.ElementIsVisible(xpath));
            }
            catch (WebDriverTimeoutException ex)
            {
                status = false;
            }
            return status;
        }
        protected static bool IsElementExists(By xpath)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementExists(xpath));
            }
            catch (WebDriverTimeoutException ex)
            {
                status = false;
            }
            return status;
        }
        protected static bool IsElementClickable(By xpath)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementToBeClickable(xpath));
            }
            catch (WebDriverTimeoutException ex)
            {
                status = false;
            }
            return status;
        }
        protected static void WaitUntilElementIsVisible(By xpath)
        {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(xpath));
        }
        protected static void WaitUntilElementIsExists(By xpath)
        {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementExists(xpath));
        }
        protected static void WaitUntilElementIsClickable(By xpath)
        {

                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementToBeClickable(xpath));
        }
        protected static void MouseDown(By xpath)
        {
            WaitUntilElementIsClickable(xpath);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(xpath)).Click().Perform();
        }
        protected static void InputTextInFieldByActions(By xpath, string keys)
        {
            WaitUntilElementIsVisible(xpath);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(xpath)).SendKeys(keys).Perform();
        }
        protected static void InputTextInFieldByJS(By xpath, string keys)
        {
            WaitUntilElementIsVisible(xpath);
            Browser.GetJSExecuter().ExecuteScript($"arguments[0].value='{keys}';", Browser.GetDriver().FindElement(xpath));
        }
        protected static void MouseDownByJS(By xpath)
        {
            WaitUntilElementIsClickable(xpath);
            Browser.GetJSExecuter().ExecuteScript("arguments[0].click();", Browser.GetDriver().FindElement(xpath));

        }
        protected static By FormatXpath(string xpath, string argument)
        {
            return By.XPath(string.Format(xpath, argument));
        }
        public T NavigateToUrl<T>(string url) where T : AbstractPage

        {
            Browser.GetDriver().Navigate().GoToUrl(url);
            return (T)Activator.CreateInstance(typeof(T));

        }

    }
 

}
