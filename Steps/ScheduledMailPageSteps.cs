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
    public class ScheduledMailPageSteps
    {
        readonly ScheduledMailPage _scheduledMail = new ScheduledMailPage();

        public bool IsOpenedMailInScheduledFolderSameAsExpected(Message patternMessage)
        {
            var isAdressSame = _scheduledMail.IsOpenedMailToInScheduledFolderSameAsExpected(patternMessage.To);
            var isSubjectSame = _scheduledMail.IsOpenedMailSubjectInScheduledFolderSameAsExpected(patternMessage.Subject);
            var isBodySame = _scheduledMail.IsOpenedMailBodyInScheduledFolderSameAsExpected(patternMessage.Body);
            return isAdressSame && isSubjectSame && isBodySame;
        }
    }
}
