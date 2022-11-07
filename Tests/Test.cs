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
        private ChooseAnAccountPage _chooseAnAccountPage;
        private LoginPage _loginPage;
        private MainPage _mainPage;
        private DraftPage _draftPage;
        private ScheduledSendPage _scheduledSendPage;
        private SentPage _sentPage;
        private ScheduledSendTab _scheduledSendTab;
        private ComposeMessagePage _composeMessagePage;

        [Test]
        public void GmailSmokeTest()
        {
            _loginPage = new LoginPage();
            _sentPage = new SentPage();
            _draftPage = new DraftPage();
            _composeMessagePage = new ComposeMessagePage();
            _mainPage = new MainPage();
            _chooseAnAccountPage = new ChooseAnAccountPage();

            // Step 1. Login to the mail box.
            _loginPage.Login();
            // Step 2. Assert that login was successfull
            Assert.IsTrue(_loginPage.IsLoginWasSuccessfull());
            // Step 3. Create a new mail
            // Step 4. Save the mail as draft
            _composeMessagePage.FillFullMail("gavruk1337@gmail.com", "Subject", "Body")
                .CollapseMail();
            _mainPage.NavigateToDraftPage();
            // Step 5. Verify, that the mail present in 'Draft' folder
            Assert.IsTrue(_draftPage.VerfiyMailAsDraft("Subject"));
            // Step 6. Verify the draft content(addressee, subject and body – should be the same as in 3).
            _composeMessagePage.ExpandMail("Subject").VerfiyDraftMailSameAsExpected("gavruk1337@gmail.com","Subject", "Body");
            // Step 7. Send the mail.
            _composeMessagePage.SendMail();
            _mainPage.NavigateToSentPage();
            // Step 8. Verify, that the mail disappeared from ‘Drafts’ folder.
            try { _draftPage.VerfiyMailAsDraft("Subject"); }
            catch (WebDriverTimeoutException ex) { Assert.That(ex.Message, Is.EqualTo("Timed out after 10 seconds")); }
            // Step 9.Verify, that the mail is in ‘Sent’ folder.
            Assert.IsTrue(_sentPage.VerfiyMailAsSent("Subject"));
            // Step 10.	Log off.
            _chooseAnAccountPage.LogoutFromAccount();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull());

        }
        [Test]
        public void ScheduledEmails()
        {
            _composeMessagePage = new ComposeMessagePage();
            _scheduledSendTab = new ScheduledSendTab();
            _scheduledSendPage = new ScheduledSendPage();
            _chooseAnAccountPage = new ChooseAnAccountPage();
            _loginPage = new LoginPage();
            _draftPage = new DraftPage();
            _mainPage = new MainPage();
            // Step 1. Login to the mail box.
            _loginPage.Login();
            // Step 2. Create a new mail(fill addressee, subject and body fields).
            _composeMessagePage.FillFullMail("gavruk1337@gmail.com", "Subject", "Body").ClickScheduledSendOption();
            // Step 3.	Schedule send for the mail using ‘Select Date and time’ option in ‘Schedule send’ dialog.
            _scheduledSendTab.ChooseEmailSendSchedule("Tomorrow morning");
            //  Step 4.	Verify that the mail is present in ‘Scheduled’ folder.
            _mainPage.NavigateToScheduledPage();
            Assert.IsTrue(_scheduledSendPage.VerfiyMailAsScheduled("Subject"));
            _scheduledSendPage.ChooseEmailBySubject("Subject");
            //  Step 5.	Verify the mail content(addressee, subject and body – should be the same as in step 2).
            Assert.IsTrue(_scheduledSendPage.VerfiyMessageSameAsExpected("Subject", "Body"));
            //  Step 6.Verify the scheduled time.
            Assert.IsTrue(_scheduledSendPage.VerfiyScheduleTimeOption("Tomorrow"));
            //  Step 7.	Cancel send.
            _scheduledSendPage.CancelSend();
            //  Step 8.	Verify that the mail disappeared from ‘Scheduled’ folder.
            try { _scheduledSendPage.VerfiyMailAsScheduled("Subject"); }
            catch (WebDriverTimeoutException ex) { Assert.That(ex.Message, Is.EqualTo("Timed out after 10 seconds")); }
            //  Step 9. Verify that the mail is returned to draft state and is shown in Compose mail popup with all fields filled(addressee, subject and body – should be the same as in step 2).
            _mainPage.NavigateToDraftPage();
            _composeMessagePage.VerfiyDraftMailSameAsExpected("gavruk1337@gmail.com", "Subject", "Body");
            Assert.IsTrue(_draftPage.VerfiyMailAsDraft("Subject"));
            //  Step 10. Discard draft.
            _composeMessagePage.DiscardDraft();
            //  Step 11. Log off.
            _chooseAnAccountPage.LogoutFromAccount();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull());

        }
        [Test]
        public void StarredEmails()
        {
            _composeMessagePage = new ComposeMessagePage();
            _scheduledSendTab = new ScheduledSendTab();
            _scheduledSendPage = new ScheduledSendPage();
            _chooseAnAccountPage = new ChooseAnAccountPage();
            _loginPage = new LoginPage();
            _draftPage = new DraftPage();
            _mainPage = new MainPage();
            // Step 1. Login to the mail box.
            _composeMessagePage.FillFullMail("gavruk1337@gmail.com", "Message without star", "Star!").LabelEmail("Add star").SaveDraftMail();
            Log.Info("Login into app");
            _loginPage.Login();
            // Step 2. Create a new mail(fill addressee, subject and body fields). And label it with star
            Log.Debug("FillFullMail", "gavruk1337@gmail.com, Message without star, Star!");
            _composeMessagePage.FillFullMail("gavruk1337@gmail.com", "Message without star", "Star!").LabelEmail("Add star").SaveDraftMail();
            // Step 3. Create another draft without any label.
            Log.Debug("FillFullMail", "gavruk1337@gmail.com, Message with star, Where is star?");
            _composeMessagePage.FillFullMail("gavruk1337@gmail.com", "Message with star", "Where is star?").SaveDraftMail();
            //  Step 4.	Verify that both mails are present in ‘Drafts’ folder.
            _mainPage.NavigateToDraftPage();
            Log.Debug("VerfiyMailAsDraft", "without star");
            Assert.IsTrue(_draftPage.VerfiyMailAsDraft("without star"));
            Log.Debug("VerfiyMailAsDraft", "with star");
            Assert.IsTrue(_draftPage.VerfiyMailAsDraft("with star"));
            //  Step 5.	In Select dropdown in the toolbar select ‘Starred’ option.
            Log.Debug("SortDraftMessages", "Starred");
            _draftPage.SortDraftMessages("Starred");
            //  Step 6. Expand More (three dots) menu in the toolbar and click ‘Remove star’.
            _draftPage.ChooseOptionMoreMenu("Remove star");
            //  Step 7.	Verify the star is removed.
            try { _draftPage.IsMessageWithStarExists(); }
            catch (WebDriverTimeoutException ex) { Assert.That(ex.Message, Is.EqualTo("Timed out after 10 seconds")); }
            //  Step 8.	In Select dropdown select ‘Unstarred’ option
            Log.Debug("SortDraftMessages", "Unstarred");
            _draftPage.SortDraftMessages("Unstarred");
            //  Step 9. Verify both drafts are selected
            Assert.That(_draftPage.GetSelectedMessagesCount().Equals(2));
            //  Step 10. Click Discard drafts in the toolbar
            _draftPage.DiscardDraft();
            // Step 11. Verify the drafts are deleted
            Log.Debug("VerfiyMailAsDraft", "without star");
            try { _draftPage.VerfiyMailAsDraft("without star"); }
            catch (WebDriverTimeoutException ex) { Assert.That(ex.Message, Is.EqualTo("Timed out after 10 seconds")); }
            Log.Debug("VerfiyMailAsDraft", "with star");
            try { _draftPage.VerfiyMailAsDraft("with star"); }
            catch (WebDriverTimeoutException ex) { Assert.That(ex.Message, Is.EqualTo("Timed out after 10 seconds")); }
            //  Step 12. Log off.
            Log.Info("Logout");
            _chooseAnAccountPage.LogoutFromAccount();
            Assert.IsTrue(_chooseAnAccountPage.VerfiyLogoutIsSuccessfull());

        }
    }
}