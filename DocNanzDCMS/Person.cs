using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Person
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string age;
        private string gender;
        private DateTime birthdate;
        private string address;
        private string email;
        private string contactNo;
        private string image;

        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string ContactNo { get => contactNo; set => contactNo = value; }
        public string Image { get => image; set => image = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Age { get => age; set => age = value; }
    }
}
