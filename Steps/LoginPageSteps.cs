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
    public class LoginPageSteps : LoginPage
    {
        public MainPage Login(User user)
        {
            InputEmail(user.DataUser[0]);
            ClickOnNextButton<LoginPage>();
            InputPassword(user.DataUser[1]);
            ClickOnNextButton<MainPage>();
            return new MainPage();
        }
    }
}
