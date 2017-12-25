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
        private Thread saveThread;
        private User user;
        private User activeUser;

        public DatabaseConnection()
        {
            try
            {
                connection = new MySqlConnection("server=localhost; user=docnanz; password=docnanz; database=docnanz_database");
                connection.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        public MySqlConnection Connection { get => connection; set => connection = value; }
        public User User { get => user; set => user = value; }
        public User ActiveUser { get => activeUser; set => activeUser = value; }

        public void saveUserAccount(User user, User activeUser)
        {
            this.user = user;
            this.activeUser = activeUser;
            if (saveThread==null||!saveThread.IsAlive)
            {
                saveThread = new Thread(startSavingUserAccount);
                saveThread.IsBackground = true;
                saveThread.Start();
            }
        }

        private void startSavingUserAccount()
        {
            try
            {
                MySqlCommand checkCommand = connection.CreateCommand();
                checkCommand.CommandText = "SELECT account_id FROM docnanz_useraccounts where account_id=@username";
                checkCommand.Parameters.AddWithValue("@username", user.Username);
                checkCommand.Prepare();
                MySqlDataReader checkReader = checkCommand.ExecuteReader();
                if(checkReader.Read())
                {
                    checkReader.Close();
                }
                else
                {
                    checkReader.Close();
                    MySqlCommand saveCommand = connection.CreateCommand();
                    saveCommand.CommandText = "INSERT INTO docnanz_useraccounts VALUES (NULL, " +
                        "@ID, @password, @type, @question1, @question2, @answer1, @answer2, " +
                        "@firstname, @middlename, @lastname, " +
                        "@gender, @birthdate, @address," +
                        "@email, @contactno, @image, " +
                        "NOW(), NOW(), @activesuser);";
                    saveCommand.Parameters.AddWithValue("@ID", user.Username);
                    saveCommand.Parameters.AddWithValue("@password", user.Password);
                    saveCommand.Parameters.AddWithValue("@type", user.AccountType);
                    saveCommand.Parameters.AddWithValue("@question1", user.Question1);
                    saveCommand.Parameters.AddWithValue("@question2", user.Question2);
                    saveCommand.Parameters.AddWithValue("@answer1", user.Answer1);
                    saveCommand.Parameters.AddWithValue("@answer2", user.Answer2);
                    saveCommand.Parameters.AddWithValue("@firstname", user.FirstName);
                    saveCommand.Parameters.AddWithValue("@middlename", user.MiddleName);
                    saveCommand.Parameters.AddWithValue("@lastname", user.LastName);
                    saveCommand.Parameters.AddWithValue("@gender", user.Gender);
                    saveCommand.Parameters.AddWithValue("@birthdate", user.Birthdate);
                    saveCommand.Parameters.AddWithValue("@address", user.Address);
                    saveCommand.Parameters.AddWithValue("@email", user.Email);
                    saveCommand.Parameters.AddWithValue("@contactno", user.ContactNo);
                    saveCommand.Parameters.AddWithValue("@image", user.Image);
                    saveCommand.Parameters.AddWithValue("@activesuser", activeUser.Username);
                    saveCommand.Prepare();
                    saveCommand.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------------------------");
            }
        }
    }
}
