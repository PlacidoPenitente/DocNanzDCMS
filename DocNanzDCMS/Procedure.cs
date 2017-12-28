using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Procedure
    {
        private string procedureCode;
        private DateTime procedureDate = DateTime.Now;
        private Treatment treatment;
        private User dentist;
        private double amountCharged;
        private double amountpaid;
        private double balance;

        public string ProcedureCode { get => procedureCode; set => procedureCode = value; }
        public DateTime ProcedureDate { get => procedureDate; set => procedureDate = value; }
        public Treatment Treatment { get => treatment; set => treatment = value; }
        public User Dentist { get => dentist; set => dentist = value; }
        public double AmountCharged { get => amountCharged; set => amountCharged = value; }
        public double Amountpaid { get => amountpaid; set => amountpaid = value; }
        public double Balance { get => balance; set => balance = value; }
    }
}
