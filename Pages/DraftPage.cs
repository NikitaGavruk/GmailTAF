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
        private string messageWithSubjectInDraftFolder = "//span[text()=\"Draft\"]//ancestor::tbody//span[contains(text(),'{0}')]";
        private string draftOptionXpath = "(//div[text()=\"{0}\"]//ancestor::div[@role=\"menuitem\"])[2]";
        private string moreOptionXpath = "//div[text()=\"{0}\"]";

        public DraftPage() : base()
        {
        }

        public bool VerifyMailExistsInDraftFolder(String subject)
        {
            return IsElementExists(FormatXpath(messageWithSubjectInDraftFolder,subject));
        }
        public DraftPage SortDraftMessages(String option)
        {
            ClickOnButton(selectXpath);
            ClickOnButton(FormatXpath(draftOptionXpath,option));
            return new DraftPage();
        }
        public DraftPage ChooseOptionMoreMenu(String option)
        {
            ClickOnButton(moreXpath);
            ClickOnButton(FormatXpath(moreOptionXpath, option));
            return new DraftPage();
        }
        public DraftPage DiscardDraft()
        {
            ClickOnButton(discardDraftButtonXpath);
            return new DraftPage();
        }
        public bool IsMessageWithStarExistsInDraftFolder()
        {
            return IsElementExists(starElementXpath);
            
        }
        public int GetSelectedMessagesCount()
        {
            WaitUntilElementIsVisible(selectedMessagesXpath);
            return Browser.GetDriver().FindElements(selectedMessagesXpath).Count;

        }
    }
}
