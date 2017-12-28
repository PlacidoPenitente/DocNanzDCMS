using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class PatientsViewerViewModel : INotifyPropertyChanged
    {
        private DatabaseConnection databaseConnection;
        private List<Patient> patients;

        public DatabaseConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
        public List<Patient> Patients
        {
            get => patients; set
            {
                patients = value;
                OnPropertyChanged("Patients");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }

        public PatientsViewerViewModel()
        {
            this.databaseConnection = new DatabaseConnection(this);
            this.patients = new List<Patient>();
            this.databaseConnection.getUserAccounts();
        }
    }
}
