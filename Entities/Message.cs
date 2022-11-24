using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Entities
{
    public class Message
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Message(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
        public Message(string to)
        {
            To = to;
            Subject = String.Empty;
            Body = String.Empty;
        }
    }
}
