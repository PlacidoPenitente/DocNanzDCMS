using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class CustomDatePicker : INotifyPropertyChanged
    {
        private int age_minimum;
        private int age_maximum;

        public CustomDatePicker(int age_limit, int age_maximum)
        {
            this.age_minimum = age_limit;
            this.age_maximum = age_maximum;
        }

        private PropertyChangedEventArgs pce;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private DateTime date_time = DateTime.Now;
        public DateTime Date
        {
            get { return date_time; }
            set
            {
                date_time = value;
                Age = DateTime.Now.Year - value.Year;
                if(DateTime.Now.Month < value.Month || (DateTime.Now.Month == value.Month && DateTime.Now.Day < value.Day))
                {
                    Age--;
                }
                pce = new PropertyChangedEventArgs("Age");
                PropertyChanged(this, pce);
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                AgeError = "";
                if(age<age_minimum||age>age_maximum)
                {
                    AgeError = "Invalid Age!";
                }
                pce = new PropertyChangedEventArgs("AgeError");
                PropertyChanged(this, pce);
            }
        }

        private String age_error;
        public String AgeError
        {
            get { return age_error; }
            set
            {
                age_error = value;
            }
        }
    }
}
