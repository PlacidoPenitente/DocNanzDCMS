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
        }

        private void PasswordCopy_PasswordChanged(object sender, RoutedEventArgs e)
        {
            NewUserAccountViewModel newUserAccountViewModel = (NewUserAccountViewModel)DataContext;
            newUserAccountViewModel.PasswordCopy = ((PasswordBox)sender).Password;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            NewUserAccountViewModel newUserAccountViewModel = (NewUserAccountViewModel)DataContext;
            newUserAccountViewModel.Password = ((PasswordBox)sender).Password;
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NewUserAccountViewModel newUserAccountViewModel = (NewUserAccountViewModel)DataContext;
            ((TextBox)sender).Text = newUserAccountViewModel.browsePhoto();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewUserAccountViewModel newUserAccountViewModel = (NewUserAccountViewModel)DataContext;
            if (((Button)sender).Content.Equals("Proceed"))
            {
                newUserAccountViewModel.saveUserAccount();
            }
            else if(((Button)sender).Content.Equals("Cancel"))
            {
                newUserAccountViewModel.cancelUserUpdate();
            }
        }
    }
}
