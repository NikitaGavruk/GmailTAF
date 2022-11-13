using GmailTA.WebDrvier;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class DraftPage : AbstractPage
    {
        private  By selectXpath = By.XPath("(//div[@data-query=\"in:draft\"]//ancestor::div[2]//div[@aria-label=\"Select\"]//div[1])[3]");
        private  By moreXpath = By.XPath("//div[@aria-label=\"More\"]");
        private  By starElementXpath = By.XPath("//span[@aria-label=\"Starred\"]");
        private  By discardDraftButtonXpath = By.XPath("//div[contains(text(),\"Discard draft\")]");
        private  By selectedMessagesXpath = By.XPath("//span[text()=\"Draft\"]//ancestor::tbody//div[@role=\"checkbox\" and @aria-checked=\"true\"]");
        public DraftPage() : base()
        {
        }

        public bool VerfiyMailAsDraft(String subject)
        {
            return IsElementExists(By.XPath($"//span[text()=\"Draft\"]//ancestor::tbody//span[contains(text(),'{subject}')]"));
        }
        public DraftPage SortDraftMessages(String option)
        {
            ClickOnButton(selectXpath);
            ClickOnButton(By.XPath($"(//div[text()=\"{option}\"]//ancestor::div[@role=\"menuitem\"])[2]"));
            return new DraftPage();
        }
        public DraftPage ChooseOptionMoreMenu(String option)
        {
            ClickOnButton(moreXpath);
            ClickOnButton(By.XPath($"//div[text()=\"{option}\"]"));
            return new DraftPage();
        }
        public DraftPage DiscardDraft()
        {
            ClickOnButton(discardDraftButtonXpath);
            return new DraftPage();
        }
        public bool IsMessageWithStarExists()
        {
            return IsElementExists(starElementXpath);
            
        }
        public int GetSelectedMessagesCount()
        {
            IsElementVisible(selectedMessagesXpath);
            return Browser.GetDriver().FindElements(selectedMessagesXpath).Count();

        }
    }
}
