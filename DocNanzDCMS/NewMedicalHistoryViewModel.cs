using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class NewMedicalHistoryViewModel : INotifyPropertyChanged
    {
        private MedicalHistory medicalHistory;

        public MedicalHistory MedicalHistory { get => medicalHistory; set => medicalHistory = value; }

        public string PhysicianName { get => MedicalHistory.PhysicianName; set => MedicalHistory.PhysicianName = value; }
        public string PhysicianSpecialty { get => MedicalHistory.PhysicianSpecialty; set => MedicalHistory.PhysicianSpecialty = value; }
        public string PhysicianAddress { get => MedicalHistory.PhysicianAddress; set => MedicalHistory.PhysicianAddress = value; }
        public string PhysicianNo { get => MedicalHistory.PhysicianNo; set => MedicalHistory.PhysicianNo = value; }
        public bool IsInGoodHealth { get => MedicalHistory.IsInGoodHealth; set => MedicalHistory.IsInGoodHealth = value; }
        public string MedicalTreatment { get => MedicalHistory.MedicalTreatment; set => MedicalHistory.MedicalTreatment = value; }
        public string SeriousIllnessOrOperation { get => MedicalHistory.SeriousIllnessOrOperation; set => MedicalHistory.SeriousIllnessOrOperation = value; }
        public string HospitalizationReason { get => MedicalHistory.HospitalizationReason; set => MedicalHistory.HospitalizationReason = value; }
        public string MedicationTaken { get => MedicalHistory.MedicationTaken; set => MedicalHistory.MedicationTaken = value; }
        public bool IsTobaccoUser { get => MedicalHistory.IsTobaccoUser; set => MedicalHistory.IsTobaccoUser = value; }
        public bool IsDangerousDrugsUser { get => MedicalHistory.IsDangerousDrugsUser; set => MedicalHistory.IsDangerousDrugsUser = value; }
        public List<string> MedicinesAllergicTo { get => MedicalHistory.MedicinesAllergicTo; set => MedicalHistory.MedicinesAllergicTo = value; }
        public string BleedingTime { get => MedicalHistory.BleedingTime; set => MedicalHistory.BleedingTime = value; }
        public bool IsPregnant { get => MedicalHistory.IsPregnant; set => MedicalHistory.IsPregnant = value; }
        public string BloodType { get => MedicalHistory.BloodType; set => MedicalHistory.BloodType = value; }
        public string BloodPressure { get => MedicalHistory.BloodPressure; set => MedicalHistory.BloodPressure = value; }
        public List<string> Diseases { get => MedicalHistory.Diseases; set => MedicalHistory.Diseases = value; }
        public bool IsNursing { get => MedicalHistory.IsNursing; set => MedicalHistory.IsNursing = value; }
        public bool IsTakingBirthControllPills { get => MedicalHistory.IsTakingBirthControllPills; set => MedicalHistory.IsTakingBirthControllPills = value; }
        public Patient Patient { get => MedicalHistory.Patient; set => MedicalHistory.Patient = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }
    }
}
