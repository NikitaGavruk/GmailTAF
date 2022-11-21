using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class BaseFolderPage : MainPage
    {
        private string mailInFolderXpath = "//div[@role='main']//tbody//div[@role='link']//span[contains(text(),'{0}')]";

        public T OpenEmailBySubjectInFolder<T>(string subject) where T : AbstractPage
        {
            ClickOnButton(FormatXpath(mailInFolderXpath, subject));
            return (T)Activator.CreateInstance(typeof(T));
        }
        public bool VerfiyMailVisibleInFolder(string subject)
        {
            return IsElementVisible(FormatXpath(mailInFolderXpath, subject));
        }
    }
}
