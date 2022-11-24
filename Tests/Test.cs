using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using GmailTA.WebDrvier;
using GmailTA.Pages;
using GmailTA.Test;
using NUnit.Framework.Internal;
using System.Threading.Channels;
using GmailTA.Steps;
using GmailTA.Utils;
using GmailTA.TestData;
using GmailTA.Entities;

namespace GmailTA.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        private readonly LoginPageSteps _loginPage = new LoginPageSteps();

        private User user = new User(TestsData.accoutEmail, TestsData.password);
        private Message patternMessage = new Message(TestsData.to, TestsData.commonSubject, TestsData.commonBody);
        ComposeMessagePageSteps _composeMessagePageSteps = new ComposeMessagePageSteps();
        ScheduledMailPageSteps _scheduledMailPageSteps = new ScheduledMailPageSteps();  
        [Test]
        public void GmailSmokeTest()
        {
            
            // Step 1. Login to the mail box.
            var _mainPage = _loginPage.Login(user);
            // Step 2. Assert that login was successfull
            Assert.IsTrue(_mainPage.IsLoginWasSuccessfull(user));
            // Step 3. Create a new mail
            // Step 4. Save the mail as draft
            var _composeMessagePage = _mainPage.ClickComposeButton();
            _composeMessagePageSteps.FillFullMail(patternMessage);
            _composeMessagePage.ClickCollapseMailButton();
            var _draftPage = _mainPage.ClickOnFolder<DraftsFolderPage>(MainPage.draftsName);
            // Step 5. Verify, that the mail present in 'Draft' folder
            Assert.IsTrue(_draftPage.VerifyMessageWithSubjectVisibleInFolder(patternMessage.Subject));
            // Step 6. Verify the draft content(addressee, subject and body – should be the same as in 3).
            _draftPage.OpenEmailBySubjectInFolder<ComposeMessageDialog>(patternMessage);
            Assert.IsTrue(_composeMessagePageSteps.IsMessageHasExpectedValuesInFields(patternMessage));
            // Step 7. Send the mail.
            _composeMessagePage.SendMail();
            _mainPage.ClickOnFolder<DraftsFolderPage>(MainPage.draftsName);
            // Step 8. Verify, that the mail disappeared from ‘Drafts’ folder.
            Assert.IsFalse(_draftPage.VerifyMessageWithSubjectVisibleInFolder(patternMessage.Subject));
            // Step 9.Verify, that the mail is in ‘Sent’ folder.
            var _sentPage = _mainPage.ClickOnFolder<SentFolderPage>(MainPage.sentName);
            Assert.IsTrue(_sentPage.VerifyMessageWithSubjectVisibleInFolder(patternMessage.Subject));
            // Step 10.	Log off.
            var _chooseAnAccountPage = _sentPage.NavigateToUrl<ChooseAnAccountPage>(ChooseAnAccountPage.chooseAnAccountLink);
            _chooseAnAccountPage.ClickLogoutButton();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull(user));

        }
        [Test]
        public void ScheduledEmails()
        {
            var dateTime = new DateTime(2023, 3, 1, 13, 0, 0, DateTimeKind.Utc);

            // Step 1. Login to the mail box.
            var _mainPage = _loginPage.Login(user);
            // Step 2. Create a new mail(fill addressee, subject and body fields).
            var _composeMessagePage = _mainPage.ClickComposeButton();
            _composeMessagePageSteps.FillFullMail(patternMessage);
            var _scheduledSendDialog = _composeMessagePageSteps.ClickScheduledSendOption();
            // Step 3.	Schedule send for the mail using ‘Select Date and time’ option in ‘Schedule send’ _dialog.
            _scheduledSendDialog.ChooseEmailSendSchedule<ComposeMessageDialog>("Pick date & time");
            _composeMessagePageSteps.ChooseDateAndTime(dateTime).ClickScheduledSend();
            //  Step 4.	Verify that the mail is present in ‘Scheduled’ folder.
            var _scheduledSendPage = _mainPage.ClickOnFolder<ScheduledFolderPage>(MainPage.scheduledName);
            Assert.IsTrue(_scheduledSendPage.VerifyMessageWithSubjectVisibleInFolder(patternMessage.Subject));
            var _scheduledMailPage = _scheduledSendPage.OpenEmailBySubjectInFolder<ScheduledMailPage>(patternMessage);
            //  Step 5.	Verify the mail content(addressee, subject and body – should be the same as in step 2).
            Assert.IsTrue(_scheduledMailPageSteps.IsOpenedMailInScheduledFolderSameAsExpected(patternMessage));
            //  Step 6.Verify the scheduled time.
            Assert.IsTrue(_scheduledMailPage.IsScheduledOptionSameAsExpected(dateTime));
            //  Step 7.	Cancel send.
            _scheduledMailPage.CancelSend();
            //  Step 8.	Verify that the mail disappeared from ‘Scheduled’ folder.
            Assert.IsFalse(_scheduledSendPage.VerifyMessageWithSubjectVisibleInFolder(patternMessage.Subject));
            //  Step 9. Verify that the mail is returned to draft state and is shown in Compose mail popup with all fields filled(addressee, subject and body – should be the same as in step 2).
            var _draftPage = _mainPage.ClickOnFolder<DraftsFolderPage>(MainPage.draftsName);
            Assert.IsTrue(_composeMessagePageSteps.IsMessageHasExpectedValuesInFields(patternMessage));
            Assert.IsTrue(_draftPage.VerifyMessageWithSubjectVisibleInFolder(patternMessage.Subject));
            //  Step 10. Discard draft.
            _composeMessagePage.DiscardDraft();
            // Step 11.	Log off.
            var _chooseAnAccountPage = _draftPage.NavigateToUrl<ChooseAnAccountPage>(ChooseAnAccountPage.chooseAnAccountLink);
            _chooseAnAccountPage.ClickLogoutButton();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull(user));

        }
        [Test]
        public void StarredEmails()
        {
            var starredMessage = new Message(TestsData.to, "Message with star", "Star!");
            var nonStarredMessage = new Message(TestsData.to, "Message without star", "Where is star?");

            // Step 1. Login to the mail box.
            Log.Info("Login into app");
            var _mainPage = _loginPage.Login(user);
            // Step 2. Create a new mail(fill addressee, subject and body fields). And label it with star
            Log.Debug("FillFullMail", TestsData.to + ", Message without star, Star!");
            _mainPage.ClickComposeButton();
            _composeMessagePageSteps.FillFullMail(starredMessage);
            _composeMessagePageSteps.LabelEmail("Add star").ClickSaveAndCloseMail();
            // Step 3. Create another draft without any label.
            Log.Debug("FillFullMail", TestsData.to + ", Message with star, Where is star?");
            _mainPage.ClickComposeButton();
            _composeMessagePageSteps.FillFullMail(nonStarredMessage).ClickSaveAndCloseMail();
            //  Step 4.	Verify that both mails are present in ‘Drafts’ folder.
            var _draftPage = _mainPage.ClickOnFolder<DraftsFolderPage>(MainPage.draftsName);
            Log.Debug("VerifyMailExistsInDraftFolder", "without star");
            Assert.IsTrue(_draftPage.VerifyMessageWithSubjectVisibleInFolder(nonStarredMessage.Subject));
            Log.Debug("VerifyMailExistsInDraftFolder", "with star");
            Assert.IsTrue(_draftPage.VerifyMessageWithSubjectVisibleInFolder(starredMessage.Subject));
            //  Step 5.	In Select dropdown in the toolbar select ‘Starred’ option.
            Log.Debug("SortDraftMessages", "Starred");
            _draftPage.SortDraftMessages("Starred");
            // Step 6. Verify that only the draft with star label is selected
            Assert.That(_draftPage.IsMessageSelectedBySubject(starredMessage.Subject));
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
            Assert.IsFalse(_draftPage.VerifyMessageWithSubjectVisibleInFolder(nonStarredMessage.Subject)); 
            Log.Debug("VerfiyMailAsDraft", "with star");
            Assert.IsFalse(_draftPage.VerifyMessageWithSubjectVisibleInFolder(starredMessage.Subject)); 
            //  Step 13. Log off.
            Log.Info("Logout");
            var _chooseAnAccountPage = _draftPage.NavigateToUrl<ChooseAnAccountPage>(ChooseAnAccountPage.chooseAnAccountLink);
            _chooseAnAccountPage.ClickLogoutButton();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull(user));

        }
    }
}