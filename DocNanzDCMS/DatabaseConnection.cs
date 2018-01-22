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
        private Thread getPatientsThread;
        private Thread getMatchingPatientsThread;
        private Thread getCategoriesThread;
        private Thread saveItemThread;
        private Thread getItemsThread;
        private Thread getDistinctItemsThread;
        private NewUserAccountViewModel newUserAccountViewModel;
        private UserAccountsViewerViewModel userAccountsViewerViewModel;
        private NewPatientViewModel newPatientViewModel;
        private PatientsViewerViewModel patientsViewerViewModel;
        private NewMedicalHistoryViewModel newMedicalHistoryViewModel;
        private NewItemViewModel newItemViewModel;
        private ItemsViewerViewModel itemsViewerViewModel;
        private NewTreatmentViewModel newTreatmentViewModel;

        public DatabaseConnection(NewItemViewModel newItemViewModel)
        {
            this.newItemViewModel = newItemViewModel;
            createConnection();
        }

        public DatabaseConnection(NewMedicalHistoryViewModel newMedicalHistoryViewModel)
        {
            this.newMedicalHistoryViewModel = newMedicalHistoryViewModel;
            createConnection();
        }

        public DatabaseConnection(ItemsViewerViewModel itemsViewerViewModel)
        {
            this.itemsViewerViewModel = itemsViewerViewModel;
            createConnection();
        }

        public DatabaseConnection(NewTreatmentViewModel newTreatmentViewModel)
        {
            this.newTreatmentViewModel = newTreatmentViewModel;
            createConnection();
        }

        public DatabaseConnection(NewUserAccountViewModel newUserAccountViewModel)
        {
            this.newUserAccountViewModel = newUserAccountViewModel;
            createConnection();
        }

        public DatabaseConnection(PatientsViewerViewModel patientsViewerViewModel)
        {
            this.patientsViewerViewModel = patientsViewerViewModel;
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

        public void getItems()
        {
            if (getItemsThread == null || !getItemsThread.IsAlive)
            {
                getItemsThread = new Thread(startGettingItems);
                getItemsThread.IsBackground = true;
                getItemsThread.Start();
            }
        }

        private void startGettingItems()
        {
            try
            {
                MySqlCommand saveCommand = Connection.CreateCommand();
                saveCommand.CommandText = "SELECT * FROM docnanz_inventory";
                MySqlDataReader itemsReader = saveCommand.ExecuteReader();
                while (itemsReader.Read())
                {
                    Item item = new Item()
                    {
                        ItemNo = itemsReader.GetString("item_no"),
                        ItemCode = itemsReader.GetString("item_code"),
                        ItemName = itemsReader.GetString("item_name"),
                        ItemType = itemsReader.GetString("item_type"),
                        PurchaseDate = DateTime.Parse(itemsReader.GetString("item_purchasedate")),
                        ItemCost = itemsReader.GetString("item_cost"),
                        ExpirationDate = DateTime.Parse(itemsReader.GetString("item_expirationdate")),
                        ItemDescription = itemsReader.GetString("item_description"),
                        DateAdded = DateTime.Parse(itemsReader.GetString("item_dateadded")),
                        DateModified = DateTime.Parse(itemsReader.GetString("item_datemodified")),
                        ModifiedBy = itemsReader.GetString("item_modifiedby")
                    };
                    ItemsViewerViewModel.Items.Add(item);
                }
                itemsReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("SaveItem Thread");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public void getDistinctItems()
        {
            if (getDistinctItemsThread == null || !getDistinctItemsThread.IsAlive)
            {
                getDistinctItemsThread = new Thread(startGettingDistinctItems);
                getDistinctItemsThread.IsBackground = true;
                getDistinctItemsThread.Start();
            }
        }

        private void startGettingDistinctItems()
        {
            try
            {
                MySqlCommand saveCommand = Connection.CreateCommand();
                saveCommand.CommandText = "SELECT item_no, item_name, item_type, item_purchasedate, item_cost, item_expirationdate, item_description, item_dateadded, item_datemodified, item_modifiedby, DISTINCT(item_code) FROM docnanz_inventory";
                MySqlDataReader itemsReader = saveCommand.ExecuteReader();
                while (itemsReader.Read())
                {
                    Item item = new Item()
                    {
                        ItemNo = itemsReader.GetString("item_no"),
                        ItemCode = itemsReader.GetString("item_code"),
                        ItemName = itemsReader.GetString("item_name"),
                        ItemType = itemsReader.GetString("item_type"),
                        PurchaseDate = DateTime.Parse(itemsReader.GetString("item_purchasedate")),
                        ItemCost = itemsReader.GetString("item_cost"),
                        ExpirationDate = DateTime.Parse(itemsReader.GetString("item_expirationdate")),
                        ItemDescription = itemsReader.GetString("item_description"),
                        DateAdded = DateTime.Parse(itemsReader.GetString("item_dateadded")),
                        DateModified = DateTime.Parse(itemsReader.GetString("item_datemodified")),
                        ModifiedBy = itemsReader.GetString("item_modifiedby")
                    };
                    NewTreatmentViewModel.Items.Add(item);
                }
                itemsReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("GetItem Thread");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        private void createConnection()
        {
            try
            {
                connection = new MySqlConnection("server=192.168.254.10; user=docnanz; password=docnanz; database=docnanz_database");
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public void getMatchingPatients()
        {
            if (getMatchingPatientsThread == null || !getMatchingPatientsThread.IsAlive)
            {
                getMatchingPatientsThread = new Thread(startFindingPatients);
                getMatchingPatientsThread.IsBackground = true;
                getMatchingPatientsThread.Start();
            }
        }

        public void saveItem()
        {
            if (saveItemThread == null || !saveItemThread.IsAlive)
            {
                saveItemThread = new Thread(startSavingItem);
                saveItemThread.IsBackground = true;
                saveItemThread.Start();
            }
        }

        private void startSavingItem()
        {
            try
            {
                for (int i = 0; i < Int32.Parse(NewItemViewModel.Quantity); i++)
                {
                    MySqlCommand saveCommand = Connection.CreateCommand();
                    saveCommand.CommandText = "INSERT INTO docnanz_inventory VALUES (NULL, @item_code, @item_name, @item_type, @item_purchasedate, @item_supplier, @item_cost, @item_expirationdate, @item_description, NOW(), NOW(), @active_user);";
                    saveCommand.Parameters.AddWithValue("@item_code", NewItemViewModel.ItemCode);
                    saveCommand.Parameters.AddWithValue("@item_name", NewItemViewModel.ItemName);
                    saveCommand.Parameters.AddWithValue("@item_type", NewItemViewModel.ItemType);
                    saveCommand.Parameters.AddWithValue("@item_purchasedate", NewItemViewModel.PurchaseDate);
                    saveCommand.Parameters.AddWithValue("@item_supplier", NewItemViewModel.Supplier);
                    saveCommand.Parameters.AddWithValue("@item_cost", NewItemViewModel.ItemCost);
                    saveCommand.Parameters.AddWithValue("@item_expirationdate", NewItemViewModel.ExpirationDate);
                    saveCommand.Parameters.AddWithValue("@item_description", NewItemViewModel.ItemDescription);
                    saveCommand.Parameters.AddWithValue("@active_user", NewItemViewModel.ActiveUser.Username);
                    saveCommand.Prepare();
                    saveCommand.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("SaveItem Thread");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public void startFindingPatients()
        {
            try
            {
                MySqlCommand getCommand = connection.CreateCommand();
                getCommand.CommandText = "SELECT * FROM docnanz_patients";
                MySqlDataReader patientsReader = getCommand.ExecuteReader();
                while (patientsReader.Read())
                {
                    int age = DateTime.Now.Year - DateTime.Parse(patientsReader.GetString("patient_birthdate")).Year;

                    if (DateTime.Now.Month < DateTime.Parse(patientsReader.GetString("patient_birthdate")).Month || (DateTime.Now.Month == DateTime.Parse(patientsReader.GetString("patient_birthdate")).Month && DateTime.Now.Day < DateTime.Parse(patientsReader.GetString("patient_birthdate")).Day))
                    {
                        age--;
                    }
                    Patient patient = new Patient()
                    {
                        PatientNo = patientsReader.GetString("patient_no"),
                        FirstName = patientsReader.GetString("patient_firstname"),
                        MiddleName = patientsReader.GetString("patient_middlename"),
                        LastName = patientsReader.GetString("patient_lastname"),
                        Birthdate = DateTime.Parse(patientsReader.GetString("patient_birthdate")),
                        Gender = patientsReader.GetString("patient_gender"),
                        Religion = patientsReader.GetString("patient_religion"),
                        Nationality = patientsReader.GetString("patient_nationality"),
                        Nickname = patientsReader.GetString("patient_nickname"),
                        Address = patientsReader.GetString("patient_address"),
                        HomeNo = patientsReader.GetString("patient_homeno"),
                        Occupation = patientsReader.GetString("patient_occupation"),
                        OfficeNo = patientsReader.GetString("patient_officeno"),
                        DentalInsurance = patientsReader.GetString("patient_dentalinsurance"),
                        EffectiveDate = DateTime.Parse(patientsReader.GetString("patient_effectivedate")),
                        FaxNo = patientsReader.GetString("patient_faxno"),
                        Email = patientsReader.GetString("patient_email"),
                        ContactNo = patientsReader.GetString("patient_contactno"),
                        GuardianName = patientsReader.GetString("patient_guardianname"),
                        GuardianOccupation = patientsReader.GetString("patient_guardianoccupation"),
                        Referee = patientsReader.GetString("patient_referee"),
                        ConsultationReason = patientsReader.GetString("patient_reason"),
                        PreviousDentist = patientsReader.GetString("patient_previousdentist"),
                        LastDentalVisit = DateTime.Parse(patientsReader.GetString("patient_lastdentalvisit")),
                        Image = patientsReader.GetString("patient_image"),
                        Age = age.ToString()
                    };
                    NewMedicalHistoryViewModel.Patients.Add(patient);
                }
                patientsReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("GetMatchingPatients Thread");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public void getCategories()
        {
            if (getCategoriesThread == null || !getCategoriesThread.IsAlive)
            {
                getCategoriesThread = new Thread(startGettingCategories);
                getCategoriesThread.IsBackground = true;
                getCategoriesThread.Start();
            }
        }

        private void startGettingCategories()
        {
            try
            {
                MySqlCommand getCommand = connection.CreateCommand();
                getCommand.CommandText = "SELECT DISTINCT(item_type) FROM docnanz_inventory";
                MySqlDataReader categoriesreader = getCommand.ExecuteReader();
                while (categoriesreader.Read())
                {
                    NewItemViewModel.Categories.Add(categoriesreader.GetString("item_type"));
                }
                categoriesreader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("GetCategories Thread");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public void getPatients()
        {
            if (getPatientsThread == null || !getPatientsThread.IsAlive)
            {
                getPatientsThread = new Thread(startGettingPatients);
                getPatientsThread.IsBackground = true;
                getPatientsThread.Start();
            }
        }

        public void startGettingPatients()
        {
            try
            {
                MySqlCommand getCommand = connection.CreateCommand();
                getCommand.CommandText = "SELECT * FROM docnanz_patients";
                MySqlDataReader patientsReader = getCommand.ExecuteReader();
                while (patientsReader.Read())
                {
                    int age = DateTime.Now.Year - DateTime.Parse(patientsReader.GetString("patient_birthdate")).Year;

                    if (DateTime.Now.Month < DateTime.Parse(patientsReader.GetString("patient_birthdate")).Month || (DateTime.Now.Month == DateTime.Parse(patientsReader.GetString("patient_birthdate")).Month && DateTime.Now.Day < DateTime.Parse(patientsReader.GetString("patient_birthdate")).Day))
                    {
                        age--;
                    }
                    Patient patient = new Patient()
                    {
                        PatientNo = patientsReader.GetString("patient_no"),
                        FirstName = patientsReader.GetString("patient_firstname"),
                        MiddleName = patientsReader.GetString("patient_middlename"),
                        LastName = patientsReader.GetString("patient_lastname"),
                        Birthdate = DateTime.Parse(patientsReader.GetString("patient_birthdate")),
                        Gender = patientsReader.GetString("patient_gender"),
                        Religion = patientsReader.GetString("patient_religion"),
                        Nationality = patientsReader.GetString("patient_nationality"),
                        Nickname = patientsReader.GetString("patient_nickname"),
                        Address = patientsReader.GetString("patient_address"),
                        HomeNo = patientsReader.GetString("patient_homeno"),
                        Occupation = patientsReader.GetString("patient_occupation"),
                        OfficeNo = patientsReader.GetString("patient_officeno"),
                        DentalInsurance = patientsReader.GetString("patient_dentalinsurance"),
                        EffectiveDate = DateTime.Parse(patientsReader.GetString("patient_effectivedate")),
                        FaxNo = patientsReader.GetString("patient_faxno"),
                        Email = patientsReader.GetString("patient_email"),
                        ContactNo = patientsReader.GetString("patient_contactno"),
                        GuardianName = patientsReader.GetString("patient_guardianname"),
                        GuardianOccupation = patientsReader.GetString("patient_guardianoccupation"),
                        Referee = patientsReader.GetString("patient_referee"),
                        ConsultationReason = patientsReader.GetString("patient_reason"),
                        PreviousDentist = patientsReader.GetString("patient_previousdentist"),
                        LastDentalVisit = DateTime.Parse(patientsReader.GetString("patient_lastdentalvisit")),
                        Image = patientsReader.GetString("patient_image"),
                        Age = age.ToString()
                    };
                    PatientsViewerViewModel.Patients.Add(patient);
                }
                patientsReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("GetPatients Thread");
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
        public NewPatientViewModel NewPatientViewModel { get => newPatientViewModel; set => newPatientViewModel = value; }
        public PatientsViewerViewModel PatientsViewerViewModel { get => patientsViewerViewModel; set => patientsViewerViewModel = value; }
        public NewMedicalHistoryViewModel NewMedicalHistoryViewModel { get => newMedicalHistoryViewModel; set => newMedicalHistoryViewModel = value; }
        public NewItemViewModel NewItemViewModel { get => newItemViewModel; set => newItemViewModel = value; }
        public ItemsViewerViewModel ItemsViewerViewModel { get => itemsViewerViewModel; set => itemsViewerViewModel = value; }
        public NewTreatmentViewModel NewTreatmentViewModel { get => newTreatmentViewModel; set => newTreatmentViewModel = value; }

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
            if(NewPatientViewModel.Patient.PatientNo.Equals(""))
            {
                try
                {
                    MySqlCommand savePatientCommand = Connection.CreateCommand();
                    savePatientCommand.CommandText = "INSERT INTO docnanz_patients VALUES (NULL, @firstname, @lastname, @middlename, @birthdate, " +
                        "@gender, @nickname, @religion, @nationality, @address, @occupation, @homeno, @officeno, @dentalinsurance, @effectivedate, @faxno, " +
                        "@contactno, @email, @guardianname, @guardianoccupation, @referee, @reason, @previousdentist, @lastdentalvisit, @image, NOW(), NOW(), @activeuser);";
                    savePatientCommand.Parameters.AddWithValue("@firstname", NewPatientViewModel.Patient.FirstName);
                    savePatientCommand.Parameters.AddWithValue("@lastname", NewPatientViewModel.Patient.LastName);
                    savePatientCommand.Parameters.AddWithValue("@middlename", NewPatientViewModel.Patient.MiddleName);
                    savePatientCommand.Parameters.AddWithValue("@birthdate", NewPatientViewModel.Patient.Birthdate);
                    savePatientCommand.Parameters.AddWithValue("@gender", NewPatientViewModel.Patient.Gender);
                    savePatientCommand.Parameters.AddWithValue("@nickname", NewPatientViewModel.Patient.Nickname);
                    savePatientCommand.Parameters.AddWithValue("@religion", NewPatientViewModel.Patient.Religion);
                    savePatientCommand.Parameters.AddWithValue("@nationality", NewPatientViewModel.Patient.Nationality);
                    savePatientCommand.Parameters.AddWithValue("@address", NewPatientViewModel.Patient.Address);
                    savePatientCommand.Parameters.AddWithValue("@occupation", NewPatientViewModel.Patient.Occupation);
                    savePatientCommand.Parameters.AddWithValue("@homeno", NewPatientViewModel.Patient.HomeNo);
                    savePatientCommand.Parameters.AddWithValue("@officeno", NewPatientViewModel.Patient.OfficeNo);
                    savePatientCommand.Parameters.AddWithValue("@dentalinsurance", NewPatientViewModel.Patient.DentalInsurance);
                    savePatientCommand.Parameters.AddWithValue("@effectivedate", NewPatientViewModel.Patient.EffectiveDate);
                    savePatientCommand.Parameters.AddWithValue("@faxno", NewPatientViewModel.Patient.FaxNo);
                    savePatientCommand.Parameters.AddWithValue("@contactno", NewPatientViewModel.Patient.ContactNo);
                    savePatientCommand.Parameters.AddWithValue("@email", NewPatientViewModel.Patient.Email);
                    savePatientCommand.Parameters.AddWithValue("@guardianname", NewPatientViewModel.Patient.GuardianName);
                    savePatientCommand.Parameters.AddWithValue("@guardianoccupation", NewPatientViewModel.Patient.GuardianOccupation);
                    savePatientCommand.Parameters.AddWithValue("@referee", NewPatientViewModel.Patient.Referee);
                    savePatientCommand.Parameters.AddWithValue("@reason", NewPatientViewModel.Patient.ConsultationReason);
                    savePatientCommand.Parameters.AddWithValue("@previousdentist", NewPatientViewModel.Patient.PreviousDentist);
                    savePatientCommand.Parameters.AddWithValue("@lastdentalvisit", NewPatientViewModel.Patient.LastDentalVisit);
                    savePatientCommand.Parameters.AddWithValue("@image", NewPatientViewModel.Patient.Image);
                    savePatientCommand.Parameters.AddWithValue("@activeuser", NewPatientViewModel.User.Username);
                    savePatientCommand.Prepare();
                    savePatientCommand.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("SavePatient Thread");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("-------------------------------------------------------------");
                }
            }
            else
            {

            }
        }
    }
}
