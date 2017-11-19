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
    /// Interaction logic for NewUserAccount.xaml
    /// </summary>
    public partial class NewUserAccount : UserControl
    {
        public NewUserAccount()
        {
            InitializeComponent();
            String name_regex = @"^[a-zA-Z0-9]+$";
            Firstname.DataContext = new CustomTextBox(name_regex);
            MiddleName.DataContext = new CustomTextBox(name_regex);
            LastName.DataContext = new CustomTextBox(name_regex);

            CustomDatePicker date_picker = new CustomDatePicker(18, 75);
            Birthdate.DataContext = date_picker;
            Age.DataContext = date_picker;
            Address.DataContext = new CustomTextBox(@"^([a-z0-9_-])+$");
        }
    }
}
