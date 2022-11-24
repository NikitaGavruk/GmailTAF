using GmailTA.Utils;
using GmailTA.WebDrvier;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace GmailTA.Pages
{
    public abstract class AbstractPage
    {
        protected AbstractPage()
        {
        }
        public T NavigateToUrl<T>(string url) where T : AbstractPage

        {
            Browser.GetDriver().Navigate().GoToUrl(url);
            return (T)Activator.CreateInstance(typeof(T));

        }

    }
 

}
