using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class NewTreatmentViewModel : INotifyPropertyChanged
    {
        private Treatment treatment;
        private DatabaseConnection databaseConnection;
        private List<string> treatmentTypes;
        private List<string> treatmentNames;
        private List<Item> items;
        private string treatmentNameError;
        private string treatmentDescriptionError;
        private string treatmentCostError;
        private string treatmentDurationError;
        private string treatmentTypeError;

        public NewTreatmentViewModel()
        {
            treatment = new Treatment();
            databaseConnection = new DatabaseConnection(this);
            treatmentTypes = new List<string>();
            treatmentNames = new List<string>();
            items = new List<Item>();
            DatabaseConnection.getDistinctItems();
        }

        public string TreatmentName { get => Treatment.TreatmentName; set { Treatment.TreatmentName = value; OnPropertyChanged("TreatmentName"); }}
        public string TreatmentDescription { get => Treatment.TreatmentDescription; set { Treatment.TreatmentDescription = value; OnPropertyChanged("TreatmentDescription"); }}
        public List<Item> ItemsUsed { get => Treatment.ItemsUsed; set { Treatment.ItemsUsed = value; OnPropertyChanged("ItemsUsed"); }}
        public string TreatmentCost { get => Treatment.TreatmentCost; set { Treatment.TreatmentCost = value; OnPropertyChanged("TreatmentCost"); }}
        public string TreatmentType { get => Treatment.TreatmentType; set { Treatment.TreatmentType = value; OnPropertyChanged("TreatmentType"); }}
        public string TreatmentDuration { get => Treatment.TreatmentDuration; set { Treatment.TreatmentDuration = value; OnPropertyChanged("TreatmentDuration"); }}
        public Treatment Treatment { get => treatment; set { treatment = value; OnPropertyChanged("Treatment"); }}

        public DatabaseConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
        public List<string> TreatmentTypes { get => treatmentTypes; set { treatmentTypes = value; OnPropertyChanged("TreatmentTypes"); }}
        public List<string> TreatmentNames { get => treatmentNames; set { treatmentNames = value; OnPropertyChanged("TreatmentNames"); }}

        public string TreatmentNameError { get => treatmentNameError; set { treatmentNameError = value; OnPropertyChanged("TreatmentNameError"); }}
        public string TreatmentDescriptionError { get => treatmentDescriptionError; set { treatmentDescriptionError = value; OnPropertyChanged("TreatmentDescriptionError"); }}
        public string TreatmentCostError { get => treatmentCostError; set { treatmentCostError = value; OnPropertyChanged("TreatmentCostError"); }}
        public string TreatmentDurationError { get => treatmentDurationError; set { treatmentDurationError = value; OnPropertyChanged("TreatmentDurationError"); }}
        public string TreatmentTypeError { get => treatmentTypeError; set { treatmentTypeError = value; OnPropertyChanged("TreatmentTypeError"); }}

        public List<Item> Items { get => items; set { items = value; OnPropertyChanged("Items"); }}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }
    }
}
