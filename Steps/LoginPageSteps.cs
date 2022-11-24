using GmailTA.Entities;
using GmailTA.Pages;
using GmailTA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Steps
{
    public class LoginPageSteps 
    {
        readonly LoginPage _loginPage = new LoginPage();
        public MainPage Login(User user)
        {
            _loginPage.InputEmail(user.Email);
            _loginPage.ClickOnNextButton<LoginPage>();
            _loginPage.InputPassword(user.Password);
            _loginPage.ClickOnNextButton<MainPage>();
            return new MainPage();
        }
    }
}
