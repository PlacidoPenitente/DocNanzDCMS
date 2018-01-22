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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private PatientsViewer patientsViewer = new PatientsViewer();
        private NewPatient newPatient = new NewPatient();
        private NewItem newItem = new NewItem();
        private ItemsViewer itemsViewer = new ItemsViewer();
        private NewMedicalHistory newMedicalHistory = new NewMedicalHistory();
        private MedicalRecordsViewer medicalRecordsViewer = new MedicalRecordsViewer();
        private NewUserAccount newUserAccount = new NewUserAccount();
        private UserAccountsViewer userAccountsViewer = new UserAccountsViewer();
        private NewAppointment newAppointment = new NewAppointment();
        private NewTreatment newTreatment = new NewTreatment();
        private AppointmentsViewer appointmentsViewer = new AppointmentsViewer();
        private FilesViewer filesViewer = new FilesViewer();

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = patientsViewer;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = newPatient;
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = newPatient;
        }

        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = itemsViewer;
        }

        private void RadioButton_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = newItem;
        }

        private void RadioButton_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = userAccountsViewer;
        }

        private void RadioButton_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = newUserAccount;
        }

        private void RadioButton_Click_7(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = appointmentsViewer;
        }

        private void RadioButton_Click_8(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = newMedicalHistory;
        }

        private void RadioButton_Click_9(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = newAppointment;
        }

        private void RadioButton_Click_10(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel.SelectedPage = filesViewer;
        }
    }
}
