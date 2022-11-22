using GmailTA.Pages;
using GmailTA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Steps
{
    public class ScheduledSendDialogSteps : ScheduledSendDialog
    {
        public ScheduledSendDialog ChooseDateAndTime(DateTime dateTime)
        {
            ChooseDate(dateTime);
            ChooseTime(dateTime);
            return new ScheduledSendDialog();
        }
    }
}
