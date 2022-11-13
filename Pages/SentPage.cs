using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class SentPage : AbstractPage
    {
        public SentPage() : base()
        {
        }

        public bool VerfiyMailAsSent(string subject)
        {
            return IsElementVisible(By.XPath($"(//span[contains(text(),'{subject}')])[2]"));
        }
    }

}
