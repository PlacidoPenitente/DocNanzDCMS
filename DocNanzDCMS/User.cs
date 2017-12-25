using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class User : Person, ICloneable
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

        public object Clone()
        {
            User user = new User();
            user.FirstName = FirstName;
            user.MiddleName = MiddleName;
            user.LastName = LastName;
            user.Birthdate = Birthdate;
            user.Address = Address;
            user.Email = Email;
            user.ContactNo = ContactNo;
            user.Image = Image;
            user.Gender = Gender;
            user.Age = Age;
            user.Username = Username;
            user.Password = Password;
            user.AccountType = AccountType;
            user.Question1 = Question1;
            user.Question2 = Question2;
            user.Answer1 = Answer1;
            user.Answer2 = Answer2;
            return user;
        }
    }
}
