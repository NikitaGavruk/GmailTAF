using GmailTA.Entities;
using GmailTA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Builders
{
    public class MessageBuilder : MessageBuilderInterface
    {
        private String to;
        private String body;
        private String subject;

        public MessageBuilderInterface AddBody(string body)
        {
            this.body = body;
            return this;
        }

        public MessageBuilderInterface AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public MessageBuilderInterface AddTo(string to)
        {
            this.to = to;
            return this;
        }

        public Message build()
        {
            Message message = new Message(to,subject,body);
            return message;
        }
    }
}
