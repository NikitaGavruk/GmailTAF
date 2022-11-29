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

        public Message()
        {
        }

        public override bool Equals(object? obj)
        {
            var actualMessage = obj as Message;
            var isAdressSame = To.Equals(actualMessage.To);
            var isSubjectSame = Subject.Equals(actualMessage.Subject);
            var isBodySame = Body.Equals(actualMessage.Body);

            return isAdressSame && isSubjectSame && isBodySame;
        }


        public override string? ToString()
        {
            return  "To: " + To + ", Subject: " + Subject + ", Body: " + Body;
        }
    }
}
