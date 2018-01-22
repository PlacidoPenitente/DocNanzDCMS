using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DocNanzDCMS
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private String title;
        private UserControl selectedPage;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public UserControl SelectedPage { get => selectedPage; set
            {
                selectedPage = value;
                OnPropertyChanged("SelectedPage");
            }
        }

        public MainWindowViewModel()
        {
            title = "Doc Nanz | Dental Clinic";
        }
    }
}
