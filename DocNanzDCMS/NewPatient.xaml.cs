using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DocNanzDCMS
{
    /// <summary>
    /// Interaction logic for NewPatient.xaml
    /// </summary>
    public partial class NewPatient : UserControl
    {
        public NewPatient()
        {
            InitializeComponent();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NewPatientViewModel newPatientViewModel = (NewPatientViewModel)DataContext;
            ((TextBox)sender).Text = newPatientViewModel.browsePhoto();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewPatientViewModel newPatientViewModel = (NewPatientViewModel)DataContext;
            if (((Button)sender).Content.Equals("Proceed"))
            {
                newPatientViewModel.saveUserAccount();
            }
            else if (((Button)sender).Content.Equals("Cancel"))
            {
                newPatientViewModel.cancelUserUpdate();
            }
        }
    }
}
