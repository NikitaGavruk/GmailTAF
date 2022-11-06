using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Pages
{
    public class SentPage : AbstractPage
    {
        public SentPage() : base()
        {
        }

        public bool VerfiyMailAsSent()
        {
            return IsElementVisible($"(//span[contains(text(),'{subject}')])[2]");
        }
    }

}
