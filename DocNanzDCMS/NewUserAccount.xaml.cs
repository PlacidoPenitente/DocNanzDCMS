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
            Firstname.DataContext = new CustomTextBox(@"^\w+([\s-']?\w+)*$");
            MiddleName.DataContext = new CustomTextBox(@"^\w+([\s-']?\w+)*$");
            LastName.DataContext = new CustomTextBox(@"^\w+([\s-']?\w+)*$");

            CustomDatePicker date_picker = new CustomDatePicker(18, 75);
            Birthdate.DataContext = date_picker;
            Age.DataContext = date_picker;
        }
    }
}
