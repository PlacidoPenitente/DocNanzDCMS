using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace DocNanzDCMS
{
    public class NewUserAccountViewModel : INotifyPropertyChanged
    {
        private DatabaseConnection databaseConnection;
        private User user;
        private User userCopy;
        private User activeUser;
        private OpenFileDialog openFileDialog;
        public event PropertyChangedEventHandler PropertyChanged;
        private String passwordCopy;
        private String passwordCopyError;
        private String ageError;
        private String contactNoError;
        private String firstNameError;
        private String middleNameError;
        private String lastNameError;
        private String addressError;
        private String emailAddressError;
        private String usernameError;
        private String passwordError;
        private String question1Error;
        private String answer1Error;
        private String question2Error;
        private String answer2Error;

        public NewUserAccountViewModel()
        {
            this.user = new User()
            {
                FirstName = "Jay Mark",
                MiddleName = "Paredes",
                LastName = "Estrera",
                Gender = "Male",
                Birthdate = DateTime.Parse("06/15/1995"),
                Age = "22",
                Address = "Pasig City",
                Email = "estrerajaymark@ymail.com",
                ContactNo = "09568032571",
                Question1 = "Question no. 1",
                Question2 = "Question no. 2",
                Answer1 = "Answer no. 1",
                Answer2 = "Answer no. 2",
                Username = "admin",
                Password = "admin",
                AccountType = "Administrator",
                Image = "sample.jpg"
            };
            this.userCopy = (User)this.User.Clone();
            this.activeUser = new User();
            this.activeUser.Username = "leonard";
            this.databaseConnection = new DatabaseConnection(this);
        }

        public String Age
        {
            get => User.Age; set
            {
                User.Age = value;
                OnPropertyChanged("Age");
            }
        }

        public string FirstName { get => User.FirstName; set
            {
                User.FirstName = value;
                FirstNameError = "";
                if(value.Trim().Length<1)
                {
                    FirstNameError = "First Name is required!";
                }
                OnPropertyChanged("FirstName");
            }
        }

        public string MiddleName { get => User.MiddleName; set
            {
                User.MiddleName = value;
                MiddleNameError = "";
                if (value.Trim().Length < 1)
                {
                    MiddleNameError = "Middle Name is required!";
                }
                OnPropertyChanged("MiddleName");
            }
        }

        public string LastName { get => User.LastName; set
            {
                User.LastName = value;
                LastNameError = "";
                if (value.Trim().Length < 1)
                {
                    LastNameError = "Last Name is required!";
                }
                OnPropertyChanged("LastName");
            }
        }

        public DateTime Birthdate { get => User.Birthdate; set
            {
                User.Birthdate = value;
                AgeError = "";
                int age = DateTime.Now.Year - value.Year;

                if (DateTime.Now.Month < value.Month || (DateTime.Now.Month == value.Month && DateTime.Now.Day < value.Day))
                {
                    age--;
                }

                if (age < 18||age>75)
                {
                    AgeError = "Invalid Age!";
                }

                Age = age.ToString();
                OnPropertyChanged("Birthdate");
            }
        }

        public string Address { get => User.Address; set
            {
                User.Address = value;
                AddressError = "";
                if (value.Trim().Length < 1)
                {
                    AddressError = "Address is required!";
                }
                OnPropertyChanged("Address");
            }
        }

        public string Email { get => User.Email; set
            {
                User.Email = value;
                EmailAddressError = "";
                if (value.Trim().Length < 1)
                {
                    EmailAddressError = "Email Address is required!";
                }
                OnPropertyChanged("Email");
            }
        }

        public string ContactNo { get => User.ContactNo; set
            {
                User.ContactNo = value;
                ContactNoError = "";

                if (ContactNo.Trim().Length<1)
                {
                    ContactNoError = "Contact No. is required!";
                }

                foreach(char c in value.ToCharArray())
                {
                    if(!Char.IsDigit(c))
                    {
                        ContactNoError = "Invalid Contact No!";
                    }
                }
                OnPropertyChanged("ContactNo");
            }
        }

        public string Image { get => User.Image; set
            {
                User.Image = value;
                OnPropertyChanged("Image");
            }
        }

        public string Gender { get => User.Gender; set
            {
                User.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string Username { get => User.Username; set
            {
                User.Username = value;
                UsernameError = "";
                if (value.Trim().Length < 1)
                {
                    UsernameError = "Username is required!";
                }
                else if(Username!=UserCopy.Username)
                {
                    DatabaseConnection.checkUserAccount();
                }
                OnPropertyChanged("Username");
            }
        }

        public string Password { get => User.Password; set
            {
                User.Password = value;
                PasswordError = "";
                if (value.Trim().Length < 1)
                {
                    PasswordError = "Password is required!";
                }
                PasswordCopy = PasswordCopy;
                OnPropertyChanged("Password");
            }
        }

        public string AccountType { get => User.AccountType; set
            {
                User.AccountType = value;
                OnPropertyChanged("AccountType");
            }
        }

        public string Question1 { get => User.Question1; set
            {
                User.Question1 = value;
                Question1Error = "";
                if (value.Trim().Length < 1)
                {
                    Question1Error = "Recovery Question is required!";
                }
                OnPropertyChanged("Question1");
            }
        }

        public string Question2 { get => User.Question2; set
            {
                User.Question2 = value;
                Question2Error = "";
                if (value.Trim().Length < 1)
                {
                    Question2Error = "Recovery Question is required!";
                }
                OnPropertyChanged("Question2");
            }
        }

        public string Answer1 { get => User.Answer1; set
            {
                User.Answer1 = value;
                Answer1Error = "";
                if (value.Trim().Length < 1)
                {
                    Answer1Error = "Answer is required!";
                }
                OnPropertyChanged("Answer1");
            }
        }

        public string Answer2 { get => User.Answer2; set
            {
                User.Answer2 = value;
                Answer2Error = "";
                if (value.Trim().Length < 1)
                {
                    Answer2Error = "Answer is required!";
                }
                OnPropertyChanged("Answer2");
            }
        }

        public string AgeError { get => ageError; set
            {
                ageError = value;
                OnPropertyChanged("AgeError");
            }
        }

        public string ContactNoError { get => contactNoError; set
            {
                contactNoError = value;
                OnPropertyChanged("ContactNoError");
            }
        }

        public string FirstNameError { get => firstNameError; set
            {
                firstNameError = value;
                OnPropertyChanged("FirstNameError");
            }
        }

        public string MiddleNameError { get => middleNameError; set
            {
                middleNameError = value;
                OnPropertyChanged("MiddleNameError");
            }
        }

        public string LastNameError { get => lastNameError; set
            {
                lastNameError = value;
                OnPropertyChanged("LastNameError");
            }
        }

        public string AddressError { get => addressError; set
            {
                addressError = value;
                OnPropertyChanged("AddressError");
            }
        }
        public string EmailAddressError { get => emailAddressError; set
            {
                emailAddressError = value;
                OnPropertyChanged("EmailAddressError");
            }
        }
        public string PasswordError { get => passwordError; set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }
        public string Question1Error { get => question1Error; set
            {
                question1Error = value;
                OnPropertyChanged("Question1Error");
            }
        }
        public string Answer1Error { get => answer1Error; set
            {
                answer1Error = value;
                OnPropertyChanged("Answer1Error");
            }
        }
        public string Question2Error { get => question2Error; set
            {
                question2Error = value;
                OnPropertyChanged("Question2Error");
            }
        }
        public string Answer2Error { get => answer2Error; set
            {
                answer2Error = value;
                OnPropertyChanged("Answer2Error");
            }
        }

        public string UsernameError { get => usernameError; set
            {
                usernameError = value;
                OnPropertyChanged("UsernameError");
            }
        }

        public string PasswordCopy { get => passwordCopy; set
            {
                passwordCopy = value;
                PasswordCopyError = "";
                if (Password != value)
                {
                    PasswordCopyError = "Passwords do not match!";
                }
                OnPropertyChanged("PasswordCopy");
            }
        }

        public string PasswordCopyError { get => passwordCopyError; set
            {
                passwordCopyError = value;
                OnPropertyChanged("PasswordCopyError");
            }
        }

        public User ActiveUser { get => activeUser; set => activeUser = value; }
        public DatabaseConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
        public User UserCopy { get => userCopy; set => userCopy = value; }
        public User User { get => user; set => user = value; }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }
        
        public string browsePhoto()
        {
            if(openFileDialog == null )
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg)|*.jpg";
            }
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        public void saveUserAccount()
        {
            DatabaseConnection.saveUserAccount();
        }

        public void cancelUserUpdate()
        {
            FirstName = UserCopy.FirstName;
            MiddleName = UserCopy.MiddleName;
            LastName = UserCopy.LastName;
            Birthdate = UserCopy.Birthdate;
            Address = UserCopy.Address;
            Email = UserCopy.Email;
            ContactNo = UserCopy.ContactNo;
            Image = UserCopy.Image;
            Gender = UserCopy.Gender;
            Age = UserCopy.Age;
            Username = UserCopy.Username;
            Password = UserCopy.Password;
            AccountType = UserCopy.AccountType;
            Question1 = UserCopy.Question1;
            Question2 = UserCopy.Question2;
            Answer1 = UserCopy.Answer1;
            Answer2 = UserCopy.Answer2;
        }
    }
}
