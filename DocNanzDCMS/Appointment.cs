using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Appointment
    {
        private User dentist;
        private DateTime appointmentDate;
        private Patient patient;
        private string appointmentReason;

        public User Dentist { get => dentist; set => dentist = value; }
        public DateTime AppointmentDate { get => appointmentDate; set => appointmentDate = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public string AppointmentReason { get => appointmentReason; set => appointmentReason = value; }
    }
}
