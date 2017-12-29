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

        public string PhysicianName { get => MedicalHistory.PhysicianName; set
            {
                MedicalHistory.PhysicianName = value;
                OnPropertyChanged("PhysicianName");
            }
        }
        public string PhysicianSpecialty { get => MedicalHistory.PhysicianSpecialty; set
            {
                MedicalHistory.PhysicianSpecialty = value;
                OnPropertyChanged("PhysicianSpecialty");
            }
        }
        public string PhysicianAddress { get => MedicalHistory.PhysicianAddress; set
            {
                MedicalHistory.PhysicianAddress = value;
                OnPropertyChanged("PhysicianAddress");
            }
        }
        public string PhysicianNo { get => MedicalHistory.PhysicianNo; set
            {
                MedicalHistory.PhysicianNo = value;
                OnPropertyChanged("PhysicianNo");
            }
        }
        public bool IsInGoodHealth { get => MedicalHistory.IsInGoodHealth; set
            {
                MedicalHistory.IsInGoodHealth = value;
                OnPropertyChanged("IsInGoodHealth");
            }
        }
        public string MedicalTreatment { get => MedicalHistory.MedicalTreatment; set
            {
                MedicalHistory.MedicalTreatment = value;
                OnPropertyChanged("MedicalTreatment");
            }
        }
        public string SeriousIllnessOrOperation { get => MedicalHistory.SeriousIllnessOrOperation; set
            {
                MedicalHistory.SeriousIllnessOrOperation = value;
                OnPropertyChanged("SeriousIllnessOrOperation");
            }
        }
        public string HospitalizationReason { get => MedicalHistory.HospitalizationReason; set
            {
                MedicalHistory.HospitalizationReason = value;
                OnPropertyChanged("HospitalizationReason");
            }
        }
        public string MedicationTaken { get => MedicalHistory.MedicationTaken; set
            {
                MedicalHistory.MedicationTaken = value;
                OnPropertyChanged("MedicationTaken");
            }
        }
        public bool IsTobaccoUser { get => MedicalHistory.IsTobaccoUser; set
            {
                MedicalHistory.IsTobaccoUser = value;
                OnPropertyChanged("IsTobaccoUser");
            }
        }
        public bool IsDangerousDrugsUser { get => MedicalHistory.IsDangerousDrugsUser; set
            {
                MedicalHistory.IsDangerousDrugsUser = value;
                OnPropertyChanged("IsDangerousDrugUser");
            }
        }
        public List<string> MedicinesAllergicTo { get => MedicalHistory.MedicinesAllergicTo; set
            {
                MedicalHistory.MedicinesAllergicTo = value;
                OnPropertyChanged("MedicinesAllergicTo");
            }
        }
        public string BleedingTime { get => MedicalHistory.BleedingTime; set
            {
                MedicalHistory.BleedingTime = value;
                OnPropertyChanged("BleedingTime");
            }
        }
        public bool IsPregnant { get => MedicalHistory.IsPregnant; set
            {
                MedicalHistory.IsPregnant = value;
                OnPropertyChanged("IsPregnant");
            }
        }
        public string BloodType { get => MedicalHistory.BloodType; set
            {
                MedicalHistory.BloodType = value;
                OnPropertyChanged("BloodType");
            }
        }
        public string BloodPressure { get => MedicalHistory.BloodPressure; set
            {
                MedicalHistory.BloodPressure = value;
                OnPropertyChanged("BloodPressure");
            }
        }
        public List<string> Diseases { get => MedicalHistory.Diseases; set
            {
                MedicalHistory.Diseases = value;
                OnPropertyChanged("Diseases");
            }
        }
        public bool IsNursing { get => MedicalHistory.IsNursing; set
            {
                MedicalHistory.IsNursing = value;
                OnPropertyChanged("IsNursing");
            }
        }
        public bool IsTakingBirthControlPills { get => MedicalHistory.IsTakingBirthControlPills; set
            {
                MedicalHistory.IsTakingBirthControlPills = value;
                OnPropertyChanged("IsTakingBirthControlPills");
            }
        }
        public Patient Patient { get => MedicalHistory.Patient; set
            {
                MedicalHistory.Patient = value;
            }
        }

        public MedicalHistory MedicalHistory { get => medicalHistory; set => medicalHistory = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }
    }
}
