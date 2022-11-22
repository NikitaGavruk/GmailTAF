using GmailTA.Entities;
using GmailTA.Utils;
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
        private string starredEmailWithSubjectXpath = "//div[@role='main']//tbody//div[@role='link']//span[contains(text(),'{0}')]//ancestor::td//preceding-sibling\t::td//span[@aria-label=\"Starred\"]";
        public DraftsFolderPage() : base()
        {
        }

        public DraftsFolderPage SortDraftMessages(String option)
        {
            WebDriverExtension.ClickOnButton(selectSortOptionButtonXpath);
            WebDriverExtension.ClickOnButton(WebUtils.FormatXpath(sortDraftMessagesOptionXpath,option));
            return new DraftsFolderPage();
        }
        public DraftsFolderPage ChooseOptionMoreMenu(String option)
        {
            WebDriverExtension.ClickOnButton(moreButtonXpath);
            WebDriverExtension.ClickOnButton(WebUtils.FormatXpath(moreOptionXpath, option));
            return new DraftsFolderPage();
        }
        public DraftsFolderPage ClickDiscardDraft()
        {
            WebDriverExtension.ClickOnButton(discardDraftButtonXpath);
            return new DraftsFolderPage();
        }
        public bool IsMessageWithStarExistsInDraftFolder()
        {
            return WebDriverExtension.IsElementExists(starredMailsXpath);
            
        }
        public int GetSelectedMessagesCount()
        {
            WebDriverExtension.WaitUntilElementIsVisible(selectedMessagesXpath);
            return Browser.GetDriver().FindElements(selectedMessagesXpath).Count;

        }
        public bool IsMessageSelectedBySubject(Message patternMessage)
        {
            return WebDriverExtension.IsElementVisible(WebUtils.FormatXpath(starredEmailWithSubjectXpath, patternMessage.DataUser[1]));

        }
    }
}
