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

        public NewPatientViewModel()
        {
            this.patient = new Patient();
        }

        public string FirstName
        {
            get => patient.FirstName; set
            {
                patient.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string MiddleName
        {
            get => patient.MiddleName; set
            {
                patient.MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        public string LastName
        {
            get => patient.LastName; set
            {
                patient.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public DateTime Birthdate
        {
            get => patient.Birthdate; set
            {
                patient.Birthdate = value;
                OnPropertyChanged("Birthdate");
            }
        }

        public string Address
        {
            get => patient.Address; set
            {
                patient.Address = value;
                OnPropertyChanged("Address");
            }
        }

        public string Email
        {
            get => patient.Email; set
            {
                patient.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string ContactNo
        {
            get => patient.ContactNo; set
            {
                patient.ContactNo = value;
                OnPropertyChanged("ContactNo");
            }
        }

        public string Image
        {
            get => patient.Image; set
            {
                patient.Image = value;
                OnPropertyChanged("Image");
            }
        }

        public string Gender
        {
            get => patient.Gender; set
            {
                patient.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string Religion { get => patient.Religion; set
            {
                patient.Religion = value;
                OnPropertyChanged("Religion");
            }
        }

        public string Nationality { get => patient.Nationality; set
            {
                patient.Nationality = value;
                OnPropertyChanged("Nationality");
            }
        }

        public string Occupation { get => patient.Occupation; set
            {
                patient.Occupation = value;
                OnPropertyChanged("Occupation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }
    }
}
