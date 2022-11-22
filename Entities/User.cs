using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTA.Entities
{
    public class User
    {
        private readonly string _email;
        private readonly string _password;

        public string[] DataUser { get; private set; }

        public User(string email, string password)
        {
            _email = email;
            _password = password;
            DataUser = new[] { _email, _password };
        }
    }
}
