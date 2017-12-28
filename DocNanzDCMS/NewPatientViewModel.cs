﻿using System;
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
        private string ageError;
        private string contactNoError;
        private string firstNameError;
        private string middleNameError;
        private string lastNameError;
        private string addressError;
        private string emailAddressError;
        private string religionError;
        private string nationalityError;
        private string nicknameError;
        private string homeNoError;
        private string officeNoError;
        private string faxNoError;
        private string dentalInsuranceError;
        private string effectiveDateError;
        private string occupationError;
        private string guradianNameError;
        private string guardianOccupationError;
        private string refereeError;
        private string consulationReasonError;
        private string previousDentistError;
        private string lastDentalVisitError;

        public NewPatientViewModel()
        {
            patient = new Patient();
        }

        public string Age
        {
            get => Patient.Age; set
            {
                Patient.Age = value;
                OnPropertyChanged("Age");
            }
        }

        public DateTime LastDentalVisit
        {
            get => Patient.LastDentalVisit; set
            {
                Patient.LastDentalVisit = value;
                LastDentalVisitError = "";
                OnPropertyChanged("LastDentalVisit");
            }
        }

        public string PreviousDentist
        {
            get => Patient.PreviousDentist; set
            {
                Patient.PreviousDentist = value;
                PreviousDentistError = "";
                if (value.Trim().Length < 1)
                {
                    Referee = "Previous Dentist's Name is required!";
                }
                OnPropertyChanged("PreviousDentist");
            }
        }

        public string Referee
        {
            get => Patient.Referee; set
            {
                Patient.Referee = value;
                RefereeError = "";
                if (value.Trim().Length < 1)
                {
                    Referee = "Referee's Name is required!";
                }
                OnPropertyChanged("Referee");
            }
        }

        public string ConsulationReason
        {
            get => Patient.ConsultationReason; set
            {
                Patient.ConsultationReason = value;
                ConsulationReasonError = "";
                if (value.Trim().Length < 1)
                {
                    OccupationError = "Consultation is required!";
                }
                OnPropertyChanged("ConsulationReason");
            }
        }

        public string Occupation
        {
            get => Patient.Occupation; set
            {
                Patient.Occupation = value;
                OccupationError = "";
                if (value.Trim().Length < 1)
                {
                    OccupationError = "Occupation is required!";
                }
                OnPropertyChanged("Occupation");
            }
        }

        public string GuardianOccupation
        {
            get => Patient.GuardianOccupation; set
            {
                Patient.GuardianOccupation = value;
                GuardianOccupationError = "";
                if (value.Trim().Length < 1)
                {
                    GuardianOccupationError = "Parent/Guardian's Occupation is required!";
                }
                OnPropertyChanged("GuardianOccupation");
            }
        }

        public string GuardianName
        {
            get => Patient.GuardianName; set
            {
                Patient.GuardianName = value;
                GuradianNameError = "";
                if (value.Trim().Length < 1)
                {
                    GuradianNameError = "Guardian Name is required!";
                }
                OnPropertyChanged("GuardianName");
            }
        }

        public string Religion
        {
            get => Patient.Religion; set
            {
                Patient.Religion = value;
                ReligionError = "";
                if (value.Trim().Length < 1)
                {
                    ReligionError = "Religion is required!";
                }
                OnPropertyChanged("Religion");
            }
        }

        public string DentalInsurance
        {
            get => Patient.DentalInsurance; set
            {
                Patient.DentalInsurance = value;
                DentalInsuranceError = "";
                if (value.Trim().Length < 1)
                {
                    DentalInsuranceError = "Dental Insurance is required!";
                }
                OnPropertyChanged("DentalInsurance");
            }
        }

        public DateTime EffectiveDate
        {
            get => Patient.EffectiveDate; set
            {
                Patient.EffectiveDate = value;
                EffectiveDateError = "";
                OnPropertyChanged("EffectiveDate");
            }
        }

        public string Nationality
        {
            get => Patient.Nationality; set
            {
                Patient.Nationality = value;
                NationalityError = "";
                if (value.Trim().Length < 1)
                {
                    NationalityError = "Nationality is required!";
                }
                OnPropertyChanged("Nationality");
            }
        }

        public string Nickname
        {
            get => Patient.Nickname; set
            {
                Patient.Nickname = value;
                NicknameError = "";
                if (value.Trim().Length < 1)
                {
                    NicknameError = "Nickname is required!";
                }
                OnPropertyChanged("Nickname");
            }
        }

        public string OfficeNo
        {
            get => Patient.OfficeNo; set
            {
                Patient.OfficeNo = value;
                OfficeNoError = "";
                if (value.Trim().Length < 1)
                {
                    OfficeNoError = "Office No. is required!";
                }
                OnPropertyChanged("OfficeNo");
            }
        }

        public string FaxNo
        {
            get => Patient.FaxNo; set
            {
                Patient.FaxNo = value;
                FaxNoError = "";
                if (value.Trim().Length < 1)
                {
                    FaxNoError = "Fax No. is required!";
                }
                OnPropertyChanged("FaxNo");
            }
        }

        public string HomeNo
        {
            get => Patient.HomeNo; set
            {
                Patient.HomeNo = value;
                HomeNoError = "";
                if (value.Trim().Length < 1)
                {
                    HomeNoError = "Home No. is required!";
                }
                OnPropertyChanged("HomeNo");
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
        public string ReligionError { get => religionError; set => religionError = value; }
        public string NationalityError { get => nationalityError; set => nationalityError = value; }
        public string NicknameError { get => nicknameError; set => nicknameError = value; }
        public string HomeNoError { get => homeNoError; set => homeNoError = value; }
        public string OfficeNoError { get => officeNoError; set => officeNoError = value; }
        public string FaxNoError { get => faxNoError; set => faxNoError = value; }
        public string DentalInsuranceError { get => dentalInsuranceError; set => dentalInsuranceError = value; }
        public string EffectiveDateError { get => effectiveDateError; set => effectiveDateError = value; }
        public string OccupationError { get => occupationError; set => occupationError = value; }
        public string GuradianNameError { get => guradianNameError; set => guradianNameError = value; }
        public string GuardianOccupationError { get => guardianOccupationError; set => guardianOccupationError = value; }
        public string ConsulationReasonError { get => consulationReasonError; set => consulationReasonError = value; }
        public string PreviousDentistError { get => previousDentistError; set => previousDentistError = value; }
        public string LastDentalVisitError { get => lastDentalVisitError; set => lastDentalVisitError = value; }
        public string RefereeError { get => refereeError; set => refereeError = value; }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }
    }
}
