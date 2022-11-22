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
        private readonly LoginPage _loginPage = new LoginPage();
        protected  string emailAdress = "gavruk1337@gmail.com";
        protected string subject = "Hi";
        protected string body = "asfsdg";
        protected string scheduledMonth = "Dec";
        protected string scheduledDay = "25";
        protected string scheduledYear = "2022";
        protected string scheduledTime = "11:26 AM";

        [Test]
        public void GmailSmokeTest()
        {

            // Step 1. Login to the mail box.
            var _mainPage = _loginPage.Login();
            // Step 2. Assert that login was successfull
            Assert.IsTrue(_mainPage.IsLoginWasSuccessfull());
            // Step 3. Create a new mail
            // Step 4. Save the mail as draft
            var _composeMessagePage = _mainPage.ClickComposeButton().FillFullMail(emailAdress, subject, body);
            _composeMessagePage.ClickCollapseMailButton();
            var _draftPage = _mainPage.ClickOnFolder<DraftsFolderPage>(MainPage.draftsName);
            // Step 5. Verify, that the mail present in 'Draft' folder
            Assert.IsTrue(_draftPage.VerfiyMailVisibleInFolder(subject));
            // Step 6. Verify the draft content(addressee, subject and body – should be the same as in 3).
            _draftPage.OpenEmailBySubjectInFolder<ComposeMessageDialog>(subject);
            Assert.IsTrue(_composeMessagePage.IsMessageHasExpectedValuesInFields(emailAdress, subject, body));
            // Step 7. Send the mail.
            _composeMessagePage.SendMail();
            _mainPage.ClickOnFolder<DraftsFolderPage>(MainPage.draftsName);
            // Step 8. Verify, that the mail disappeared from ‘Drafts’ folder.
            Assert.IsFalse(_draftPage.VerfiyMailVisibleInFolder(subject));
            // Step 9.Verify, that the mail is in ‘Sent’ folder.
            var _sentPage = _mainPage.ClickOnFolder<SentFolderPage>(MainPage.sentName);
            Assert.IsTrue(_sentPage.VerfiyMailVisibleInFolder(subject));
            // Step 10.	Log off.
            var _chooseAnAccountPage = _mainPage.NavigateToUrl<ChooseAnAccountPage>(ChooseAnAccountPage.chooseAnAccountLink);
            _chooseAnAccountPage.ClickLogoutButton();
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
            _scheduledSendTab.ChooseEmailSendSchedule<ScheduledSendDialog>("Pick date & time").ChooseDate(scheduledMonth, scheduledDay,scheduledYear,scheduledTime).ClickScheduledSend();
            //  Step 4.	Verify that the mail is present in ‘Scheduled’ folder.
            var _scheduledSendPage = _mainPage.ClickOnFolder<ScheduledFolderPage>(MainPage.scheduledName);
            Assert.IsTrue(_scheduledSendPage.VerfiyMailVisibleInFolder(subject));
            var _scheduledMailPage = _scheduledSendPage.OpenEmailBySubjectInFolder<ScheduledMailPage>(subject);
            //  Step 5.	Verify the mail content(addressee, subject and body – should be the same as in step 2).
            Assert.IsTrue(_scheduledMailPage.IsOpenedMailInScheduledFolderSameAsExpected(emailAdress, subject, body));
            //  Step 6.Verify the scheduled time.
            Assert.IsTrue(_scheduledMailPage.IsScheduledOptionSameAsExpected(scheduledMonth + " " + scheduledDay + ", " + scheduledYear + ", " + scheduledTime));
            //  Step 7.	Cancel send.
            _scheduledMailPage.CancelSend();
            //  Step 8.	Verify that the mail disappeared from ‘Scheduled’ folder.
            Assert.IsFalse(_scheduledSendPage.VerfiyMailVisibleInFolder(subject));
            //  Step 9. Verify that the mail is returned to draft state and is shown in Compose mail popup with all fields filled(addressee, subject and body – should be the same as in step 2).
            var _draftPage = _mainPage.ClickOnFolder<DraftsFolderPage>(MainPage.draftsName);
            Assert.IsTrue(_composeMessagePage.IsMessageHasExpectedValuesInFields(emailAdress, subject, body));
            Assert.IsTrue(_draftPage.VerfiyMailVisibleInFolder(subject));
            //  Step 10. Discard draft.
            _composeMessagePage.DiscardDraft();
            // Step 11.	Log off.
            var _chooseAnAccountPage = _mainPage.NavigateToUrl<ChooseAnAccountPage>(ChooseAnAccountPage.chooseAnAccountLink);
            _chooseAnAccountPage.ClickLogoutButton();
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
            _mainPage.ClickComposeButton().FillFullMail(emailAdress, "Message with star", "Star!").LabelEmail("Add star").ClickSaveAndCloseMail();
            // Step 3. Create another draft without any label.
            Log.Debug("FillFullMail", emailAdress + ", Message with star, Where is star?");
            _mainPage.ClickComposeButton().FillFullMail(emailAdress, "Message without star", "Where is star?").ClickSaveAndCloseMail();
            //  Step 4.	Verify that both mails are present in ‘Drafts’ folder.
            var _draftPage = _mainPage.ClickOnFolder<DraftsFolderPage>(MainPage.draftsName);
            Log.Debug("VerifyMailExistsInDraftFolder", "without star");
            Assert.IsTrue(_draftPage.VerfiyMailVisibleInFolder("without star"));
            Log.Debug("VerifyMailExistsInDraftFolder", "with star");
            Assert.IsTrue(_draftPage.VerfiyMailVisibleInFolder("with star"));
            //  Step 5.	In Select dropdown in the toolbar select ‘Starred’ option.
            Log.Debug("SortDraftMessages", "Starred");
            _draftPage.SortDraftMessages("Starred");
            // Step 6. Verify that only the draft with star label is selected
            Assert.That(_draftPage.IsMessageSelectedBySubject("Message with star"));
            //  Step 7. Expand More (three dots) menu in the toolbar and click ‘Remove star’.
            _draftPage.ChooseOptionMoreMenu("Remove star");
            //  Step 8.	Verify the star is removed.
            Assert.IsFalse(_draftPage.IsMessageWithStarExistsInDraftFolder()); 
            //  Step 9.	In Select dropdown select ‘Unstarred’ option
            Log.Debug("SortDraftMessages", "Unstarred");
            _draftPage.SortDraftMessages("Unstarred");
            //  Step 10. Verify both drafts are selected
            Assert.That(_draftPage.GetSelectedMessagesCount().Equals(2));
            //  Step 11. Click Discard drafts in the toolbar
            _draftPage.ClickDiscardDraft();
            // Step 12. Verify the drafts are deleted
            Log.Debug("VerfiyMailAsDraft", "without star");
            Assert.IsFalse(_draftPage.VerfiyMailVisibleInFolder("without star")); 
            Log.Debug("VerfiyMailAsDraft", "with star");
            Assert.IsFalse(_draftPage.VerfiyMailVisibleInFolder("with star")); 
            //  Step 13. Log off.
            Log.Info("Logout");
            var _chooseAnAccountPage = _mainPage.NavigateToUrl<ChooseAnAccountPage>(ChooseAnAccountPage.chooseAnAccountLink);
            _chooseAnAccountPage.ClickLogoutButton();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull());

        }
    }
}