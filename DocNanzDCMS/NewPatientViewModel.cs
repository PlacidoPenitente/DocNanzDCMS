using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class NewPatientViewModel : INotifyPropertyChanged
    {
        private Patient patient;
        public event PropertyChangedEventHandler PropertyChanged;
        private String ageError;
        private String contactNoError;
        private String firstNameError;
        private String middleNameError;
        private String lastNameError;
        private String addressError;
        private String emailAddressError;

        public NewPatientViewModel()
        {
            patient = new Patient();
        }

        public String Age
        {
            get => Patient.Age; set
            {
                Patient.Age = value;
                OnPropertyChanged("Age");
            }
        }

        public string FirstName
        {
            get => Patient.FirstName; set
            {
                Patient.FirstName = value;
                FirstNameError = "";
                if (value.Trim().Length < 1)
                {
                    FirstNameError = "First Name is required!";
                }
                OnPropertyChanged("FirstName");
            }
        }

        public string MiddleName
        {
            get => Patient.MiddleName; set
            {
                Patient.MiddleName = value;
                MiddleNameError = "";
                if (value.Trim().Length < 1)
                {
                    MiddleNameError = "Middle Name is required!";
                }
                OnPropertyChanged("MiddleName");
            }
        }

        public string LastName
        {
            get => Patient.LastName; set
            {
                Patient.LastName = value;
                LastNameError = "";
                if (value.Trim().Length < 1)
                {
                    LastNameError = "Last Name is required!";
                }
                OnPropertyChanged("LastName");
            }
        }

        public DateTime Birthdate
        {
            get => Patient.Birthdate; set
            {
                Patient.Birthdate = value;
                AgeError = "";
                int age = DateTime.Now.Year - value.Year;

                if (DateTime.Now.Month < value.Month || (DateTime.Now.Month == value.Month && DateTime.Now.Day < value.Day))
                {
                    age--;
                }

                if (age < 18 || age > 75)
                {
                    AgeError = "Invalid Age!";
                }

                Age = age.ToString();
                OnPropertyChanged("Birthdate");
            }
        }

        public string Address
        {
            get => Patient.Address; set
            {
                Patient.Address = value;
                AddressError = "";
                if (value.Trim().Length < 1)
                {
                    AddressError = "Address is required!";
                }
                OnPropertyChanged("Address");
            }
        }

        public string Email
        {
            get => Patient.Email; set
            {
                Patient.Email = value;
                EmailAddressError = "";
                if (value.Trim().Length < 1)
                {
                    EmailAddressError = "Email Address is required!";
                }
                OnPropertyChanged("Email");
            }
        }

        public string ContactNo
        {
            get => Patient.ContactNo; set
            {
                Patient.ContactNo = value;
                ContactNoError = "";

                if (ContactNo.Trim().Length < 1)
                {
                    ContactNoError = "Contact No. is required!";
                }

                foreach (char c in value.ToCharArray())
                {
                    if (!Char.IsDigit(c))
                    {
                        ContactNoError = "Invalid Contact No!";
                    }
                }
                OnPropertyChanged("ContactNo");
            }
        }

        public string Image
        {
            get => Patient.Image; set
            {
                Patient.Image = value;
                OnPropertyChanged("Image");
            }
        }

        public string Gender
        {
            get => Patient.Gender; set
            {
                Patient.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string AgeError
        {
            get => ageError; set
            {
                ageError = value;
                OnPropertyChanged("AgeError");
            }
        }

        public string ContactNoError
        {
            get => contactNoError; set
            {
                contactNoError = value;
                OnPropertyChanged("ContactNoError");
            }
        }

        public string FirstNameError
        {
            get => firstNameError; set
            {
                firstNameError = value;
                OnPropertyChanged("FirstNameError");
            }
        }

        public string MiddleNameError
        {
            get => middleNameError; set
            {
                middleNameError = value;
                OnPropertyChanged("MiddleNameError");
            }
        }

        public string LastNameError
        {
            get => lastNameError; set
            {
                lastNameError = value;
                OnPropertyChanged("LastNameError");
            }
        }

        public string AddressError
        {
            get => addressError; set
            {
                addressError = value;
                OnPropertyChanged("AddressError");
            }
        }
        public string EmailAddressError
        {
            get => emailAddressError; set
            {
                emailAddressError = value;
                OnPropertyChanged("EmailAddressError");
            }
        }

        public Patient Patient { get => patient; set => patient = value; }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }
    }
}
