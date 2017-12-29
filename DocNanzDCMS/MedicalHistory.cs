using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class MedicalHistory
    {
        private Patient patient;
        private string physicianName = "Yedda Marie Lingad";
        private string physicianSpecialty = "None";
        private string physicianAddress = "Mandaluyong City";
        private string physicianNo = "12345";
        private bool isInGoodHealth = true;
        private string medicalTreatment = "None";
        private string seriousIllnessOrOperation = "None";
        private string hospitalizationReason = "None";
        private string medicationTaken = "None";
        private bool isTobaccoUser = false;
        private bool isDangerousDrugsUser = false;
        private List<string> medicinesAllergicTo = new List<string>() {"Antibiotic", "Penicillin"};
        private string bleedingTime = "1";
        private bool isPregnant = false;
        private bool isNursing = false;
        private bool isTakingBirthControllPills = false;
        private string bloodType = "A";
        private string bloodPressure = "100/70";
        private string diseases = "Diabetes";
        
        public string PhysicianName { get => physicianName; set => physicianName = value; }
        public string PhysicianSpecialty { get => physicianSpecialty; set => physicianSpecialty = value; }
        public string PhysicianAddress { get => physicianAddress; set => physicianAddress = value; }
        public string PhysicianNo { get => physicianNo; set => physicianNo = value; }
        public bool IsInGoodHealth { get => isInGoodHealth; set => isInGoodHealth = value; }
        public string MedicalTreatment { get => medicalTreatment; set => medicalTreatment = value; }
        public string SeriousIllnessOrOperation { get => seriousIllnessOrOperation; set => seriousIllnessOrOperation = value; }
        public string HospitalizationReason { get => hospitalizationReason; set => hospitalizationReason = value; }
        public string MedicationTaken { get => medicationTaken; set => medicationTaken = value; }
        public bool IsTobaccoUser { get => isTobaccoUser; set => isTobaccoUser = value; }
        public bool IsDangerousDrugsUser { get => isDangerousDrugsUser; set => isDangerousDrugsUser = value; }
        public List<string> MedicinesAllergicTo { get => medicinesAllergicTo; set => medicinesAllergicTo = value; }
        public string BleedingTime { get => bleedingTime; set => bleedingTime = value; }
        public bool IsPregnant { get => isPregnant; set => isPregnant = value; }
        public string BloodType { get => bloodType; set => bloodType = value; }
        public string BloodPressure { get => bloodPressure; set => bloodPressure = value; }
        public bool IsNursing { get => isNursing; set => isNursing = value; }
        public bool IsTakingBirthControlPills { get => isTakingBirthControllPills; set => isTakingBirthControllPills = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public string Diseases { get => diseases; set => diseases = value; }
    }
}
