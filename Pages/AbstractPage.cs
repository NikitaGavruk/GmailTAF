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
            WaitUntilElementIsVisible(xpath);
            WaitUntilElementIsClickable(xpath);
            Browser.GetDriver().FindElement(xpath).Click();
        }
        public static string GetTextFromField(By xpath)
        {
            WaitUntilElementIsVisible(xpath);
            return Browser.GetDriver().FindElement(xpath).Text;
        }
        public static string GetAttributeValueFromField(By xpath, string attribute)
        {
            WaitUntilElementIsVisible(xpath);
            return Browser.GetDriver().FindElement(xpath).GetAttribute(attribute);
        }
        public static void InputTextInField(By xpath, String input)
        {
            WaitUntilElementIsVisible(xpath);
            Browser.GetDriver().FindElement(xpath).SendKeys(input);
        }
        public static bool IsElementVisible(By xpath)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(xpath));
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Timed out after 10 seconds"));
                status = false;
            }
            return status;
        }
        public static bool IsElementExists(By xpath)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(xpath));
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Timed out after 10 seconds"));
                status = false;
            }
            return status;
        }
        public static bool IsElementClickable(By xpath)
        {
            bool status = true;
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(xpath));
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Timed out after 10 seconds"));
                status = false;
            }
            return status;
        }
        public static void WaitUntilElementIsVisible(By xpath)
        {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(xpath));
        }
        public static void WaitUntilElementIsExists(By xpath)
        {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(xpath));
        }
        public static void WaitUntilElementIsClickable(By xpath)
        {

                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(xpath));
        }
        public static void MouseDown(By xpath)
        {
            WaitUntilElementIsClickable(xpath);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(xpath)).Click().Perform();
        }
        public static void InputTextInFieldByActions(By xpath, string keys)
        {
            WaitUntilElementIsVisible(xpath);
            Browser.GetActions().MoveToElement(Browser.GetDriver().FindElement(xpath)).SendKeys(keys).Perform();
        }
        public static void InputTextInFieldByJS(By xpath, string keys)
        {
            WaitUntilElementIsVisible(xpath);
            Browser.GetJSExecuter().ExecuteScript($"arguments[0].value='{keys}';", Browser.GetDriver().FindElement(xpath));
        }
        public static void MouseDownByJS(By xpath)
        {
            WaitUntilElementIsClickable(xpath);
            Browser.GetJSExecuter().ExecuteScript("arguments[0].click();", Browser.GetDriver().FindElement(xpath));

        }
        public static By FormatXpath(string xpath, string argument)
        {
            return By.XPath(string.Format(xpath, argument));
        }
    }
 

}
