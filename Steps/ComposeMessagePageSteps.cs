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
    public class ComposeMessagePageSteps
    {
        readonly ComposeMessageDialog _dialog = new ComposeMessageDialog();
        readonly ScheduledSendDialog _scheduledSendDialog = new ScheduledSendDialog();
        string  pickDataAndTime = "Pick date & time";
        public ComposeMessageDialog FillFullMail(Message patternMessage)
        {
            _dialog.InputValueInToField(patternMessage.To);
            _dialog.InputValueInSubjectField(patternMessage.Subject);
            _dialog.InputValueInBodyField(patternMessage.Body);
            return new ComposeMessageDialog();
        }
        public ComposeMessageDialog LabelEmail(string option)
        {
            _dialog.ClickOnMoreButton();
            _dialog.ClickOnLabelList();
            _dialog.ChooseLabelOption(option);
            return new ComposeMessageDialog();
        }
        public ScheduledSendDialog ClickScheduledSendOption()
        {
            _dialog.ClickMoreSendOptionButton();
            _dialog.ClickScheduledSendButton();
            return new ScheduledSendDialog();

        }
        public ScheduledSendDialog ChooseDateAndTime(DateTime dateTime)
        {
            _scheduledSendDialog.ChooseDate(dateTime);
            _scheduledSendDialog.ChooseTime(dateTime);
            return new ScheduledSendDialog();
        }
        public bool IsMessageHasExpectedValuesInFields(Message patternMessage)
        {
            var isAdressSame = _dialog.IsMessageHasExpectedTo(patternMessage.To);
            var isSubjectSame = _dialog.IsMessageHasExpectedSubject(patternMessage.Subject);
            var isBodySame = _dialog.IsMessageHasExpectedBody(patternMessage.Body);
            return isAdressSame && isSubjectSame && isBodySame;
        }
        public Message GetMessage()
        {
            return new Message(_dialog.GetToValue(), _dialog.GetSubjectValue(), _dialog.GetBodyValue());
        }
        public MainPage ScheduledSendForSpecificDate(DateTime dataTime)
        {
            var dialog = ClickScheduledSendOption();
            dialog.ChooseEmailSendSchedule<ScheduledSendDialog>(pickDataAndTime);
            dialog.ChooseDate(dataTime);
            dialog.ChooseTime(dataTime);
            return dialog.ClickScheduledSend();
        }
    }
}
