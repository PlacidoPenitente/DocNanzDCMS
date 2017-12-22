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
        String[] contents;

        public CustomTextBox(String pattern)
        {
            this.pattern = pattern;
        }

        private PropertyChangedEventArgs pce;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private String text = "";
        public String Text
        {
            get { return text; }
            set
            {
                contents =  value.Split(' ');
                foreach(string text in contents)
                {
                    if (Regex.IsMatch(text, pattern))
                    {
                        error = "";
                        continue;
                    }
                    else
                    {
                        error = "Invalid Characters Found!";
                        break;
                    }
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
