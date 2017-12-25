using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class UserPrivate : Person
    {
        private string username;
        private string accountType = "Standard";

        public string Username { get => username; set => username = value; }
        public string AccountType { get => accountType; set => accountType = value; }
    }
}
