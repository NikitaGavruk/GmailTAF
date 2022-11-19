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
        public static readonly string mailWithSubjectInSentFolderXpath = "(//span[contains(text(),'{0}')])[2]";
        public SentPage() : base()
        {
        }


    }

}
