using GmailTA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Interfaces
{
    public interface MessageBuilderInterface
    {
        public MessageBuilderInterface AddSubject(string subject);
        public MessageBuilderInterface AddBody(string body);
        public MessageBuilderInterface AddTo(string to);

        public Message build();

    }
}
