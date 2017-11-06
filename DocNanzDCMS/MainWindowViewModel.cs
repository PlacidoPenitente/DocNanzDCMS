using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class MainWindowViewModel
    {
        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public MainWindowViewModel()
        {
            title = "Doc Nanz | Dental Clinic";
        }
    }
}
