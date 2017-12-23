using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Patient : Person
    {
        private string religion;
        private string nationality;
        private string occupation;
        private Patient father;
        private Patient mother;
        private Patient guardian;
        private List<Patient> children;
        private List<Patient> siblings;
        private MedicalHistory medicalRecord;
        private DentalChart dentalChart;
        private Transaction transaction;
        private Operation operation;

        public string Religion { get => religion; set => religion = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Occupation { get => occupation; set => occupation = value; }
        public Patient Father { get => father; set => father = value; }
        public Patient Mother { get => mother; set => mother = value; }
        public Patient Guardian { get => guardian; set => guardian = value; }
        public List<Patient> Children { get => children; set => children = value; }
        public List<Patient> Siblings { get => siblings; set => siblings = value; }
        public MedicalHistory MedicalRecord { get => medicalRecord; set => medicalRecord = value; }
        public DentalChart DentalChart { get => dentalChart; set => dentalChart = value; }
        public Transaction Transaction { get => transaction; set => transaction = value; }
        public Operation Operation { get => operation; set => operation = value; }
    }
}
