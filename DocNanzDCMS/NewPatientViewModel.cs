using Microsoft.Win32;
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
        private Patient patientCopy;
        private OpenFileDialog openFileDialog;
        private DatabaseConnection databaseConnection;
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
        private string guardianNameError;
        private string guardianOccupationError;
        private string refereeError;
        private string consultationReasonError;
        private string previousDentistError;
        private string lastDentalVisitError;

        public NewPatientViewModel()
        {
            patient = new Patient();
            patientCopy = (Patient)patient.Clone();
            databaseConnection = new DatabaseConnection(this);
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

        public MedicalHistory MedicalHistory
        {
            get => Patient.MedicalHistory; set
            {
                Patient.MedicalHistory = value;
                OnPropertyChanged("MedicalHistory");
            }
        }

        public DentalChart DentalChart
        {
            get => Patient.DentalChart; set
            {
                Patient.DentalChart = value;
                OnPropertyChanged("DentalChart");
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
                    PreviousDentistError = "Previous Dentist's Name is required!";
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
                    RefereeError = "Referee's Name is required!";
                }
                OnPropertyChanged("Referee");
            }
        }

        public string ConsultationReason
        {
            get => Patient.ConsultationReason; set
            {
                Patient.ConsultationReason = value;
                ConsultationReasonError = "";
                if (value.Trim().Length < 1)
                {
                    ConsultationReasonError = "Consultation is required!";
                }
                OnPropertyChanged("ConsultationReason");
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
                GuardianNameError = "";
                if (value.Trim().Length < 1)
                {
                    GuardianNameError = "Guardian's Name is required!";
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
        public string ReligionError {
            get => religionError; set
            {
                religionError = value;
                OnPropertyChanged("ReligionError");
            }
        }
        public string NationalityError {
            get => nationalityError; set
            {
                nationalityError = value;
                OnPropertyChanged("NationalityError");
            }
        }
        public string NicknameError {
            get => nicknameError; set
            {
                nicknameError = value;
                OnPropertyChanged("NicknameError");
            }
        }
        public string HomeNoError {
            get => homeNoError; set
            {
                homeNoError = value;
                OnPropertyChanged("HomeNoError");
            }
        }
        public string OfficeNoError {
            get => officeNoError; set
            {
                officeNoError = value;
                OnPropertyChanged("OfficeNoError");
            }
        }
        public string FaxNoError {
            get => faxNoError; set
            {
                faxNoError = value;
                OnPropertyChanged("FaxNoError");
            }
        }
        public string DentalInsuranceError {
            get => dentalInsuranceError; set
            {
                dentalInsuranceError = value;
                OnPropertyChanged("DentalInsuranceError");
            }
        }
        public string EffectiveDateError {
            get => effectiveDateError; set
            {
                effectiveDateError = value;
                OnPropertyChanged("EffectiveDateError");
            }
        }
        public string OccupationError {
            get => occupationError; set
            {
                occupationError = value;
                OnPropertyChanged("OccupationError");
            }
        }
        public string GuardianNameError {
            get => guardianNameError; set
            {
                guardianNameError = value;
                OnPropertyChanged("GuardianNameError");
            }
        }
        public string GuardianOccupationError {
            get => guardianOccupationError; set
            {
                guardianOccupationError = value;
                OnPropertyChanged("GuardianOccupationError");
            }
        }
        public string ConsultationReasonError {
            get => consultationReasonError; set
            {
                consultationReasonError = value;
                OnPropertyChanged("ConsultationReasonError");
            }
        }
        public string PreviousDentistError {
            get => previousDentistError; set
            {
                previousDentistError = value;
                OnPropertyChanged("PreviousDentistError");
            }
        }
        public string LastDentalVisitError {
            get => lastDentalVisitError; set
            {
                lastDentalVisitError = value;
                OnPropertyChanged("LastDentalVisitError");
            }
        }
        public string RefereeError {
            get => refereeError; set
            {
                refereeError = value;
                OnPropertyChanged("RefereeError");
            }
        }

        public Patient PatientCopy { get => patientCopy; set => patientCopy = value; }
        public DatabaseConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }

        public string browsePhoto()
        {
            if (openFileDialog == null)
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg)|*.jpg";
            }
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        public void saveUserAccount()
        {
            DatabaseConnection.savePatient();
        }

        public void cancelUserUpdate()
        {
            FirstName = patientCopy.FirstName;
            LastName = patientCopy.LastName;
            MiddleName = patientCopy.MiddleName;
            Birthdate = patientCopy.Birthdate;
            Age = patientCopy.Age;
            Gender = patientCopy.Gender;
            Religion = patientCopy.Religion;
            Nationality = patientCopy.Nationality;
            Address = patientCopy.Address;
            HomeNo = patientCopy.HomeNo;
            Occupation = patientCopy.Occupation;
            OfficeNo = patientCopy.OfficeNo;
            DentalInsurance = patientCopy.DentalInsurance;
            FaxNo = patientCopy.FaxNo;
            EffectiveDate = patientCopy.EffectiveDate;
            ContactNo = patientCopy.ContactNo;
            GuardianName = patientCopy.GuardianName;
            Email = patientCopy.Email;
            GuardianOccupation = patientCopy.GuardianOccupation;
            Referee = patientCopy.Referee;
            ConsultationReason = patientCopy.ConsultationReason;
            PreviousDentist = patientCopy.PreviousDentist;
            LastDentalVisit = patientCopy.LastDentalVisit;
            DentalChart = patientCopy.DentalChart;
            MedicalHistory = patientCopy.MedicalHistory;
            Image = patientCopy.Image;
        }
    }
}
