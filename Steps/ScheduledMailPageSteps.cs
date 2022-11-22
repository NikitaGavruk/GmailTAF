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
    public class ScheduledMailPageSteps : ScheduledMailPage
    {
        public bool IsOpenedMailInScheduledFolderSameAsExpected(Message patternMessage)
        {
            var isAdressSame = IsOpenedMailToInScheduledFolderSameAsExpected(patternMessage.DataUser[0]);
            var isSubjectSame = IsOpenedMailSubjectInScheduledFolderSameAsExpected(patternMessage.DataUser[1]);
            var isBodySame = IsOpenedMailBodyInScheduledFolderSameAsExpected(patternMessage.DataUser[2]);
            return isAdressSame && isSubjectSame && isBodySame;
        }
    }
}
