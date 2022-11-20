using GmailTA.WebDrvier;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class DraftsFolderPage : BaseFolderPage
    {
        private  By selectSortOptionButtonXpath = By.XPath("(//div[@data-query=\"in:draft\"]//ancestor::div[2]//div[@aria-label=\"Select\"]//div[1])[3]");
        private  By moreButtonXpath = By.XPath("//div[@aria-label=\"More\"]");
        private  By starredMailsXpath = By.XPath("//span[@aria-label=\"Starred\"]");
        private  By discardDraftButtonXpath = By.XPath("//div[contains(text(),\"Discard draft\")]");
        private  By selectedMessagesXpath = By.XPath("//span[text()=\"Draft\"]//ancestor::tbody//div[@role=\"checkbox\" and @aria-checked=\"true\"]");
        private string sortDraftMessagesOptionXpath = "(//div[text()=\"{0}\"]//ancestor::div[@role=\"menuitem\"])[2]";
        private string moreOptionXpath = "//div[text()=\"{0}\"]";

        public DraftsFolderPage() : base()
        {
        }

        public DraftsFolderPage SortDraftMessages(String option)
        {
            ClickOnButton(selectSortOptionButtonXpath);
            ClickOnButton(FormatXpath(sortDraftMessagesOptionXpath,option));
            return new DraftsFolderPage();
        }
        public DraftsFolderPage ChooseOptionMoreMenu(String option)
        {
            ClickOnButton(moreButtonXpath);
            ClickOnButton(FormatXpath(moreOptionXpath, option));
            return new DraftsFolderPage();
        }
        public DraftsFolderPage ClickDiscardDraft()
        {
            ClickOnButton(discardDraftButtonXpath);
            return new DraftsFolderPage();
        }
        public bool IsMessageWithStarExistsInDraftFolder()
        {
            return IsElementExists(starredMailsXpath);
            
        }
        public int GetSelectedMessagesCount()
        {
            WaitUntilElementIsVisible(selectedMessagesXpath);
            return Browser.GetDriver().FindElements(selectedMessagesXpath).Count;

        }

    }
}
