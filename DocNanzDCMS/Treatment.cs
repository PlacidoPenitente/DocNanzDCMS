using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Treatment
    {
        private string treatmentName;
        private string treatmentDescription;
        private List<Item> itemsUsed = new List<Item>();
        private string treatmentCost;
        private string treatmentType;
        private string treatmentDuration;
        private DateTime dateAdded;
        private DateTime dateModified;
        private string modifiedBy;
        
        public string TreatmentName { get => treatmentName; set => treatmentName = value; }
        public string TreatmentDescription { get => treatmentDescription; set => treatmentDescription = value; }
        public List<Item> ItemsUsed { get => itemsUsed; set => itemsUsed = value; }
        public string TreatmentCost { get => treatmentCost; set => treatmentCost = value; }
        public string TreatmentType { get => treatmentType; set => treatmentType = value; }
        public string TreatmentDuration { get => treatmentDuration; set => treatmentDuration = value; }
        public DateTime DateAdded { get => dateAdded; set => dateAdded = value; }
        public DateTime DateModified { get => dateModified; set => dateModified = value; }
        public string ModifiedBy { get => modifiedBy; set => modifiedBy = value; }
    }
}
