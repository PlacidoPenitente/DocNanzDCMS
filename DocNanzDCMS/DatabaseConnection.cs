using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;

namespace DocNanzDCMS
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;
        private Thread saveUserThread;
        private Thread checkThread;
        private Thread getUsersThread;
        private Thread savePatientThread;
        private NewUserAccountViewModel newUserAccountViewModel;
        private UserAccountsViewerViewModel userAccountsViewerViewModel;
        private NewPatientViewModel newPatientViewModel;

        public DatabaseConnection(NewUserAccountViewModel newUserAccountViewModel)
        {
            this.newUserAccountViewModel = newUserAccountViewModel;
            createConnection();
        }

        public DatabaseConnection(UserAccountsViewerViewModel userAccountsViewerViewModel)
        {
            this.userAccountsViewerViewModel = userAccountsViewerViewModel;
            createConnection();
        }

        public DatabaseConnection(NewPatientViewModel newPatientViewModel)
        {
            this.newPatientViewModel = newPatientViewModel;
            createConnection();
        }

        private void createConnection()
        {
            try
            {
                connection = new MySqlConnection("server=localhost; user=docnanz; password=docnanz; database=docnanz_database");
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public void getUserAccounts()
        {
            if (getUsersThread == null || !getUsersThread.IsAlive)
            {
                getUsersThread = new Thread(startGettingUserAccounts);
                getUsersThread.IsBackground = true;
                getUsersThread.Start();
            }
        }

        private void startGettingUserAccounts()
        {
            try
            {
                MySqlCommand getCommand = connection.CreateCommand();
                getCommand.CommandText = "SELECT * FROM docnanz_useraccounts";
                MySqlDataReader usersReader = getCommand.ExecuteReader();
                while (usersReader.Read())
                {
                    int age = DateTime.Now.Year - DateTime.Parse(usersReader.GetString("account_birthdate")).Year;

                    if (DateTime.Now.Month < DateTime.Parse(usersReader.GetString("account_birthdate")).Month || (DateTime.Now.Month == DateTime.Parse(usersReader.GetString("account_birthdate")).Month && DateTime.Now.Day < DateTime.Parse(usersReader.GetString("account_birthdate")).Day))
                    {
                        age--;
                    }
                    User user = new User()
                    {
                        FirstName = usersReader.GetString("account_firstname"),
                        MiddleName = usersReader.GetString("account_middlename"),
                        LastName = usersReader.GetString("account_lastname"),
                        Birthdate = DateTime.Parse(usersReader.GetString("account_birthdate")),
                        Address = usersReader.GetString("account_address"),
                        Email = usersReader.GetString("account_emailaddress"),
                        ContactNo = usersReader.GetString("account_contactno"),
                        Username = usersReader.GetString("account_id"),
                        AccountType = usersReader.GetString("account_type"),
                        Image = usersReader.GetString("account_image"),
                        Age = age.ToString()
                    };
                    UserAccountsViewerViewModel.Users.Add(user);
                }
                usersReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("GetUsers Thread");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public MySqlConnection Connection { get => connection; set => connection = value; }
        public NewUserAccountViewModel NewUserAccountViewModel { get => newUserAccountViewModel; set => newUserAccountViewModel = value; }
        public UserAccountsViewerViewModel UserAccountsViewerViewModel { get => userAccountsViewerViewModel; set => userAccountsViewerViewModel = value; }

        public void saveUserAccount()
        {
            if (saveUserThread==null||!saveUserThread.IsAlive)
            {
                saveUserThread = new Thread(startSavingUserAccount);
                saveUserThread.IsBackground = true;
                saveUserThread.Start();
            }
        }

        public void checkUserAccount()
        {
            if (checkThread == null || !checkThread.IsAlive)
            {
                checkThread = new Thread(startCheckingUserAccount);
                checkThread.IsBackground = true;
                checkThread.Start();
            }
        }

        private void startCheckingUserAccount()
        {
            try
            {
                MySqlCommand checkCommand = connection.CreateCommand();
                checkCommand.CommandText = "SELECT account_id FROM docnanz_useraccounts WHERE account_id=@username";
                checkCommand.Parameters.AddWithValue("@username", NewUserAccountViewModel.Username);
                checkCommand.Prepare();
                MySqlDataReader checkReader = checkCommand.ExecuteReader();
                if (checkReader.Read())
                {
                    NewUserAccountViewModel.UsernameError = "Username already taken!";
                }
                checkReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Checker Thread");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        private void startSavingUserAccount()
        {
            try
            {
                MySqlCommand checkCommand = connection.CreateCommand();
                checkCommand.CommandText = "SELECT account_id FROM docnanz_useraccounts WHERE account_id=@username";
                checkCommand.Parameters.AddWithValue("@username", NewUserAccountViewModel.User.Username);
                checkCommand.Prepare();
                MySqlDataReader checkReader = checkCommand.ExecuteReader();
                MySqlCommand saveCommand = connection.CreateCommand();
                if (checkReader.Read())
                {
                    checkReader.Close();
                    saveCommand.CommandText = "UPDATE docnanz_useraccounts SET " +
                        "account_ID=@ID, account_password=@password, account_type=@type, account_question1=@question1, account_question2=@question2, account_answer1=@answer1, account_answer2=@answer2, " +
                        "account_firstname=@firstname, account_middlename=@middlename, account_lastname=@lastname, " +
                        "account_gender=@gender, account_birthdate=@birthdate, account_address=@address," +
                        "account_emailaddress=@email, account_contactno=@contactno, account_image=@image, " +
                        "account_modifiedby=@activesuser WHERE account_id=@originalusername";
                    saveCommand.Parameters.AddWithValue("@originalusername", NewUserAccountViewModel.UserCopy.Username);
                }
                else
                {
                    checkReader.Close();
                    saveCommand.CommandText = "INSERT INTO docnanz_useraccounts VALUES (NULL, " +
                        "@ID, @password, @type, @question1, @question2, @answer1, @answer2, " +
                        "@firstname, @middlename, @lastname, " +
                        "@gender, @birthdate, @address," +
                        "@email, @contactno, @image, " +
                        "NOW(), NOW(), @activesuser);";
                }
                saveCommand.Parameters.AddWithValue("@ID", NewUserAccountViewModel.User.Username);
                saveCommand.Parameters.AddWithValue("@password", NewUserAccountViewModel.User.Password);
                saveCommand.Parameters.AddWithValue("@type", NewUserAccountViewModel.User.AccountType);
                saveCommand.Parameters.AddWithValue("@question1", NewUserAccountViewModel.User.Question1);
                saveCommand.Parameters.AddWithValue("@question2", NewUserAccountViewModel.User.Question2);
                saveCommand.Parameters.AddWithValue("@answer1", NewUserAccountViewModel.User.Answer1);
                saveCommand.Parameters.AddWithValue("@answer2", NewUserAccountViewModel.User.Answer2);
                saveCommand.Parameters.AddWithValue("@firstname", NewUserAccountViewModel.User.FirstName);
                saveCommand.Parameters.AddWithValue("@middlename", NewUserAccountViewModel.User.MiddleName);
                saveCommand.Parameters.AddWithValue("@lastname", NewUserAccountViewModel.User.LastName);
                saveCommand.Parameters.AddWithValue("@gender", NewUserAccountViewModel.User.Gender);
                saveCommand.Parameters.AddWithValue("@birthdate", NewUserAccountViewModel.User.Birthdate);
                saveCommand.Parameters.AddWithValue("@address", NewUserAccountViewModel.User.Address);
                saveCommand.Parameters.AddWithValue("@email", NewUserAccountViewModel.User.Email);
                saveCommand.Parameters.AddWithValue("@contactno", NewUserAccountViewModel.User.ContactNo);
                saveCommand.Parameters.AddWithValue("@image", NewUserAccountViewModel.User.Image);
                saveCommand.Parameters.AddWithValue("@activesuser", NewUserAccountViewModel.ActiveUser.Username);
                saveCommand.Prepare();
                saveCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Saving Thread");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public void savePatient()
        {
            if (savePatientThread == null || !savePatientThread.IsAlive)
            {
                savePatientThread = new Thread(startSavingPatient);
                savePatientThread.IsBackground = true;
                savePatientThread.Start();
            }
        }

        private void startSavingPatient()
        {
            
        }
    }
}
