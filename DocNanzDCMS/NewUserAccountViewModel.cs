﻿using Microsoft.Win32;
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
        private User user;
        private OpenFileDialog openFileDialog;
        public event PropertyChangedEventHandler PropertyChanged;
        private String ageError;

        public NewUserAccountViewModel()
        {
            this.user = new User();
        }

        public String Age
        {
            get => user.Age; set
            {
                user.Age = value;
                OnPropertyChanged("Age");
            }
        }

        public string FirstName { get => user.FirstName; set
            {
                user.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string MiddleName { get => user.MiddleName; set
            {
                user.MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        public string LastName { get => user.LastName; set
            {
                user.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public DateTime Birthdate { get => user.Birthdate; set
            {
                user.Birthdate = value;
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

        public string Address { get => user.Address; set
            {
                user.Address = value;
                OnPropertyChanged("Address");
            }
        }

        public string Email { get => user.Email; set
            {
                user.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string ContactNo { get => user.ContactNo; set
            {
                user.ContactNo = value;
                OnPropertyChanged("ContactNo");
            }
        }

        public string Image { get => user.Image; set
            {
                user.Image = value;
                OnPropertyChanged("Image");
            }
        }

        public string Gender { get => user.Gender; set
            {
                user.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string Username { get => user.Username; set
            {
                user.Username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password { get => user.Password; set
            {
                user.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public string AccountType { get => user.AccountType; set
            {
                user.AccountType = value;
                OnPropertyChanged("AccountType");
            }
        }

        public string Question1 { get => user.Question1; set
            {
                user.Question1 = value;
                OnPropertyChanged("Question1");
            }
        }

        public string Question2 { get => user.Question2; set
            {
                user.Question2 = value;
                OnPropertyChanged("Question2");
            }
        }

        public string Answer1 { get => user.Answer1; set
            {
                user.Answer1 = value;
                OnPropertyChanged("Answer1");
            }
        }

        public string Answer2 { get => user.Answer2; set
            {
                user.Answer2 = value;
                OnPropertyChanged("Answer2");
            }
        }

        public string AgeError { get => ageError; set
            {
                ageError = value;
                OnPropertyChanged("AgeError");
            }
        }

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
            
        }

        public void cancelUserUpdate()
        {
            
        }
    }
}
