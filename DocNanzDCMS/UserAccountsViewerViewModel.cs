﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class UserAccountsViewerViewModel : INotifyPropertyChanged
    {
        private DatabaseConnection databaseConnection;
        private List<User> users;

        public DatabaseConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
        public List<User> Users { get => users; set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }

        public UserAccountsViewerViewModel()
        {
            this.databaseConnection = new DatabaseConnection(this);
            this.users = new List<User>();
            this.databaseConnection.getUserAccounts();
        }
    }
}
