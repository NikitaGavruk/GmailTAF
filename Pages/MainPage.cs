﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GmailTA.Pages
{

    public class MainPage : AbstractPage
    {

        public static string writeMailButtonXpath = "//*[text()=\"Compose\"]//ancestor::div[1]";
        public static string draftsTabXpath = "//a[contains(@aria-label,\"Drafts\")]";
        public static string sentPageXpath = "//a[contains(@aria-label,\"Sent\")]";
        public static string scheduledPageXpath = "//a[contains(@aria-label,\"Scheduled\")]";


        public MainPage() : base()
        {
        }

        public void NavigateToPage(string pageName)
        {
             ClickOnButton($"//div[@data-tooltip=\"{pageName}\"]");
        }
        public MainPage NavigateToDraftPage()
        {
            NavigateToPage("Drafts");
            return new MainPage();
        }
        public MainPage NavigateToSentPage()
        {
            NavigateToPage("Sent");
            return new MainPage();
        }
        public MainPage NavigateToScheduledPage()
        {
            NavigateToPage("Scheduled");
            return new MainPage();
        }


    }


}
