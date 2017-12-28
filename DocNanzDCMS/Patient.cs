using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Patient : Person
    {
        private string religion = "Roman Catholic";
        private string nationality = "Filipino";
        private string nickname = "Potenciano";
        private string occupation = "none";
        private string insurance = "none";
        private string officeNo = "12345";
        private string homeNo = "12345";
        private DateTime insuranceDate = DateTime.Now;
        private string faxNo = "12345";
        private string guardianName = "Daisy Estrera";
        private string guardianOccupation = "None";
        private string referree = "None";
        private string consultationReason = "Toothache";
        private string previousDentist = "Dr. Estrera";
        private string dentalInsurance = "Medicard";
        private DateTime effectiveDate = DateTime.Now;
        private DateTime lastDentalVisit = DateTime.Now;
        private MedicalHistory medicalHistory;
        private DentalChart dentalChart;

        public string Religion { get => religion; set => religion = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Occupation { get => occupation; set => occupation = value; }
        public string Insurance { get => insurance; set => insurance = value; }
        public DateTime InsuranceDate { get => insuranceDate; set => insuranceDate = value; }
        public string GuardianName { get => guardianName; set => guardianName = value; }
        public string GuardianOccupation { get => guardianOccupation; set => guardianOccupation = value; }
        public string Referree { get => referree; set => referree = value; }
        public string ConsultationReason { get => consultationReason; set => consultationReason = value; }
        public string PreviousDentist { get => previousDentist; set => previousDentist = value; }
        public DateTime LastDentalVisit { get => lastDentalVisit; set => lastDentalVisit = value; }
        public MedicalHistory MedicalHistory { get => medicalHistory; set => medicalHistory = value; }
        public DentalChart DentalChart { get => dentalChart; set => dentalChart = value; }
        public string HomeNo { get => homeNo; set => homeNo = value; }
        public string OfficeNo { get => officeNo; set => officeNo = value; }
        public string FaxNo { get => faxNo; set => faxNo = value; }
        public string DentalInsurance { get => dentalInsurance; set => dentalInsurance = value; }
        public DateTime EffectiveDate { get => effectiveDate; set => effectiveDate = value; }
    }
}
