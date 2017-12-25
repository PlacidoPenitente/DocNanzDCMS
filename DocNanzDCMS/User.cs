using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class User : Person
    {
        private string username;
        private string password;
        private string accountType = "Standard";
        private string question1;
        private string question2;
        private string answer1;
        private string answer2;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string AccountType { get => accountType; set => accountType = value; }
        public string Question1 { get => question1; set => question1 = value; }
        public string Question2 { get => question2; set => question2 = value; }
        public string Answer1 { get => answer1; set => answer1 = value; }
        public string Answer2 { get => answer2; set => answer2 = value; }
    }
}
