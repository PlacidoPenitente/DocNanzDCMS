using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DocNanzDCMS
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;

        public DatabaseConnection()
        {
            try
            {
                connection = new MySqlConnection("server=localhost:81; user=docnanz; password; docnanz; database=docnanz_database");
                connection.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public MySqlConnection Connection { get => connection; set => connection = value; }

        public void saveUserAccount(User user)
        {
            Console.WriteLine("Hello");
        }
    }
}
