using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Treatment
    {
        private string treatmentCode;
        private string treatmentName;
        private string treatmentDescription;
        private List<Item> itemsUsed = new List<Item>();
        private double treatmentCost;

        public string TreatmentCode { get => treatmentCode; set => treatmentCode = value; }
        public string TreatmentName { get => treatmentName; set => treatmentName = value; }
        public string TreatmentDescription { get => treatmentDescription; set => treatmentDescription = value; }
        public List<Item> ItemsUsed { get => itemsUsed; set => itemsUsed = value; }
        public double TreatmentCost { get => treatmentCost; set => treatmentCost = value; }
    }
}
