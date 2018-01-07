using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class ItemsViewerViewModel
    {
        private List<Item> items;
        private DatabaseConnection databaseConnection;

        public ItemsViewerViewModel()
        {
            items = new List<Item>();
            databaseConnection = new DatabaseConnection(this);
            DatabaseConnection.getItems();
        }

        public List<Item> Items { get => items; set => items = value; }
        public DatabaseConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
    }
}
