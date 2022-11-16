using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using GmailTA.WebDrvier;
using GmailTA.Pages;
using GmailTA.Test;
using NUnit.Framework.Internal;
using System.Threading.Channels;

namespace GmailTA.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        private LoginPage _loginPage = new LoginPage();
        protected  string emailAdress = "gavruk1337@gmail.com";
        protected string subject = "Hi";
        protected string body = "asfsdg";
        [Test]
        public void GmailSmokeTest()
        {


            // Step 1. Login to the mail box.
            var _mainPage = _loginPage.Login();
            // Step 2. Assert that login was successfull
            Assert.IsTrue(_loginPage.IsLoginWasSuccessfull());
            // Step 3. Create a new mail
            // Step 4. Save the mail as draft
            var _composeMessagePage = _mainPage.ClickComposeButton().FillFullMail(emailAdress, subject, body);
            _composeMessagePage.CollapseMail();
            var _draftPage = _mainPage.NavigateToDraftPage();
            // Step 5. Verify, that the mail present in 'Draft' folder
            Assert.IsTrue(_draftPage.VerifyMailExistsInDraftFolder(subject));
            // Step 6. Verify the draft content(addressee, subject and body – should be the same as in 3).
            _draftPage.ExpandMailByClickOnItInDraftFolder(subject);
            Assert.IsTrue(_composeMessagePage.IsMessageHasExpectedValuesInFields(emailAdress, subject, body));
            // Step 7. Send the mail.
            _composeMessagePage.SendMail();
            _mainPage.NavigateToDraftPage();
            // Step 8. Verify, that the mail disappeared from ‘Drafts’ folder.
            Assert.IsFalse(_draftPage.VerifyMailExistsInDraftFolder(subject));
            // Step 9.Verify, that the mail is in ‘Sent’ folder.
            var _sentPage = _mainPage.NavigateToSentPage();
            Assert.IsTrue(_sentPage.IsMailExistsInSentFolder(subject));
            // Step 10.	Log off.
            var _chooseAnAccountPage = _mainPage.NavigateToChooseAnAccoutPage();
            _chooseAnAccountPage.LogoutFromAccount();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull());

        }
        [Test]
        public void ScheduledEmails()
        {

            // Step 1. Login to the mail box.
            var _mainPage = _loginPage.Login();
            // Step 2. Create a new mail(fill addressee, subject and body fields).
            var _composeMessagePage = _mainPage.ClickComposeButton();
            var _scheduledSendTab = _composeMessagePage.FillFullMail(emailAdress, subject, body).ClickScheduledSendOption();
            // Step 3.	Schedule send for the mail using ‘Select Date and time’ option in ‘Schedule send’ dialog.
            _scheduledSendTab.ChooseEmailSendSchedule("Tomorrow morning");
            //  Step 4.	Verify that the mail is present in ‘Scheduled’ folder.
            var _scheduledSendPage = _mainPage.NavigateToScheduledPage();
            Assert.IsTrue(_scheduledSendPage.VerfiyMailExistsInScheduledFolder(subject));
            _scheduledSendPage.ChooseEmailBySubject(subject);
            //  Step 5.	Verify the mail content(addressee, subject and body – should be the same as in step 2).
            Assert.IsTrue(_scheduledSendPage.IsOpenedMailInScheduledFolderSameAsExpected(subject));
            //  Step 6.Verify the scheduled time.
            Assert.IsTrue(_scheduledSendPage.IsScheduledOptionSameAsExpected("Tomorrow"));
            //  Step 7.	Cancel send.
            _scheduledSendPage.CancelSend();
            //  Step 8.	Verify that the mail disappeared from ‘Scheduled’ folder.
            Assert.IsFalse(_scheduledSendPage.VerfiyMailExistsInScheduledFolder(subject));
            //  Step 9. Verify that the mail is returned to draft state and is shown in Compose mail popup with all fields filled(addressee, subject and body – should be the same as in step 2).
            var _draftPage = _mainPage.NavigateToDraftPage();
            _composeMessagePage.IsMessageHasExpectedValuesInFields(emailAdress, subject, body);
            Assert.IsTrue(_draftPage.VerifyMailExistsInDraftFolder(subject));
            //  Step 10. Discard draft.
            _composeMessagePage.DiscardDraft();
            // Step 11.	Log off.
            var _chooseAnAccountPage = _mainPage.NavigateToChooseAnAccoutPage();
            _chooseAnAccountPage.LogoutFromAccount();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull());

        }
        [Test]
        public void StarredEmails()
        {
            // Step 1. Login to the mail box.
            Log.Info("Login into app");
            var _mainPage = _loginPage.Login();
            // Step 2. Create a new mail(fill addressee, subject and body fields). And label it with star
            Log.Debug("FillFullMail", emailAdress + ", Message without star, Star!");
            _mainPage.ClickComposeButton().FillFullMail(emailAdress, "Message without star", "Star!").LabelEmail("Add star").SaveDraftMail();
            // Step 3. Create another draft without any label.
            Log.Debug("FillFullMail", emailAdress + ", Message with star, Where is star?");
            _mainPage.ClickComposeButton().FillFullMail(emailAdress, "Message with star", "Where is star?").SaveDraftMail();
            //  Step 4.	Verify that both mails are present in ‘Drafts’ folder.
            var _draftPage = _mainPage.NavigateToDraftPage();
            Log.Debug("VerifyMailExistsInDraftFolder", "without star");
            Assert.IsTrue(_draftPage.VerifyMailExistsInDraftFolder("without star"));
            Log.Debug("VerifyMailExistsInDraftFolder", "with star");
            Assert.IsTrue(_draftPage.VerifyMailExistsInDraftFolder("with star"));
            //  Step 5.	In Select dropdown in the toolbar select ‘Starred’ option.
            Log.Debug("SortDraftMessages", "Starred");
            _draftPage.SortDraftMessages("Starred");
            //  Step 6. Expand More (three dots) menu in the toolbar and click ‘Remove star’.
            _draftPage.ChooseOptionMoreMenu("Remove star");
            //  Step 7.	Verify the star is removed.
            Assert.IsFalse(_draftPage.IsMessageWithStarExistsInDraftFolder()); 
            //  Step 8.	In Select dropdown select ‘Unstarred’ option
            Log.Debug("SortDraftMessages", "Unstarred");
            _draftPage.SortDraftMessages("Unstarred");
            //  Step 9. Verify both drafts are selected
            Assert.That(_draftPage.GetSelectedMessagesCount().Equals(2));
            //  Step 10. Click Discard drafts in the toolbar
            _draftPage.DiscardDraft();
            // Step 11. Verify the drafts are deleted
            Log.Debug("VerfiyMailAsDraft", "without star");
            Assert.IsFalse(_draftPage.VerifyMailExistsInDraftFolder("without star")); 
            Log.Debug("VerfiyMailAsDraft", "with star");
            Assert.IsFalse(_draftPage.VerifyMailExistsInDraftFolder("with star")); 
            //  Step 12. Log off.
            Log.Info("Logout");
            var _chooseAnAccountPage = _mainPage.NavigateToChooseAnAccoutPage();
            _chooseAnAccountPage.LogoutFromAccount();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull());

        }
    }
}