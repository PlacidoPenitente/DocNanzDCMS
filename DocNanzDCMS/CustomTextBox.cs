using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DocNanzDCMS
{
    public class CustomTextBox : INotifyPropertyChanged
    {
        private string pattern;

        public CustomTextBox(String pattern)
        {
            this.pattern = pattern;
        }

        private PropertyChangedEventArgs pce;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private String text;
        public String Text
        {
            get { return text; }
            set
            {
                if (Regex.IsMatch(value, pattern))
                {
                    text = value;
                    error = "";
                }
                else
                {
                    error = "Invalid Format!";
                }
                pce = new PropertyChangedEventArgs("Error");
                PropertyChanged(this, pce);
            }
        }

        private String error;

        public String Error
        {
            get { return error; }
            set { error = value; }
        }
    }
}
