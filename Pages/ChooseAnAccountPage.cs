using GmailTA.WebDrvier;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GmailTA.Pages
{

    public class ChooseAnAccountPage : AbstractPage
    {


        private readonly By logout  = By.XPath("//button[@class=\"sign-out\"]");
        public ChooseAnAccountPage() : base()
        {
        }
        public ChooseAnAccountPage LogoutFromAccount()
        {
            ClickOnButton(logout);
            return new ChooseAnAccountPage();
        }
        public bool VerfiyLogoutIsSuccessfull()
        {
            return IsElementVisible(By.Id($"account-{accoutEmail}"));
        }

    }

}
