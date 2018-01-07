using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class NewItemViewModel : INotifyPropertyChanged
    {
        private Item item;
        private User activeUser;
        private string itemNameError;
        private string supplierError;
        private string itemCostError;
        private string itemDescriptionError;
        private string quantity;
        private string quantityError;
        private DatabaseConnection databaseConnection;
        private List<string> categories;

        public NewItemViewModel()
        {
            item = new Item();
            activeUser = new User();
            activeUser.Username = "Leonard";
            databaseConnection = new DatabaseConnection(this);
            categories = new List<string>();
            DatabaseConnection.getCategories();
        }

        public Item Item { get => item; set { item = value; OnPropertyChanged("Item"); }}
        public string ItemCode { get => Item.ItemCode; set { Item.ItemCode = value; OnPropertyChanged("ItemCode"); }}
        public string ItemName { get => Item.ItemName; set { Item.ItemName = value; OnPropertyChanged("ItemName"); }}
        public string ItemType { get => Item.ItemType; set { Item.ItemType = value; OnPropertyChanged("ItemType"); }}
        public DateTime PurchaseDate { get => Item.PurchaseDate; set { Item.PurchaseDate = value; OnPropertyChanged("PurchaseDate"); }}
        public string Supplier { get => Item.Supplier; set { Item.Supplier = value; OnPropertyChanged("Supplier"); }}
        public string ItemCost { get => Item.ItemCost; set { Item.ItemCost = value; OnPropertyChanged("ItemCost"); }}
        public DateTime ExpirationDate { get => Item.ExpirationDate; set { Item.ExpirationDate = value; OnPropertyChanged("ExpirationDate"); }}
        public string ItemDescription { get => Item.ItemDescription; set { Item.ItemDescription = value; OnPropertyChanged("ItemDescription"); }}

        public string ItemNameError { get => itemNameError; set { itemNameError = value; OnPropertyChanged("ItemNameError"); }}
        public string SupplierError { get => supplierError; set { supplierError = value; OnPropertyChanged("SupplierError"); }}
        public string ItemCostError { get => itemCostError; set { itemCostError = value; OnPropertyChanged("ItemCostError"); }}
        public string ItemDescriptionError { get => itemDescriptionError; set { itemDescriptionError = value; OnPropertyChanged("ItemDescriptionError"); }}
        public string Quantity { get => quantity; set { quantity = value; OnPropertyChanged("Quantity"); }}
        public string QuantityError { get => quantityError; set { quantityError = value; OnPropertyChanged("QuantityError"); }}

        public DatabaseConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
        public List<string> Categories { get => categories; set { categories = value; OnPropertyChanged("Categories"); }}

        public User ActiveUser { get => activeUser; set => activeUser = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine(propertyName);
        }

        public void saveItem()
        {
            DatabaseConnection.saveItem();
        }
    }
}
