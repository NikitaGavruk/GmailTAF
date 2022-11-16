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
        private string mailWithSubjectInSentFolderXpath = "//span[contains(text(),'{0}')]";
        public SentPage() : base()
        {
        }

        public bool IsMailExistsInSentFolder(string subject)
        {
            return IsElementExists(FormatXpath(mailWithSubjectInSentFolderXpath,subject));
        }
    }

}
