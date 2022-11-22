using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Entities
{
    public class Message
    {
        private readonly string _to;
        private readonly string _subject;
        private readonly string _body;

        public string[] DataUser { get; private set; }

        public Message(string to, string subject, string body)
        {
            _to = to;
            _subject = subject;
            _body = body;
            DataUser = new[] { _to, _subject, _body };
        }
        public Message(string to)
        {
            _to = to;
            _subject = String.Empty;
            _body = String.Empty;
            DataUser = new[] { _to, _subject, _body };
        }
    }
}
