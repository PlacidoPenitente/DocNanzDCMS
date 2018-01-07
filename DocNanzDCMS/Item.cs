using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class Item
    {
        private string itemCode;
        private string itemName;
        private string itemType;
        private DateTime purchaseDate = DateTime.Now;
        private string supplier;
        private string itemCost;
        private DateTime expirationDate = DateTime.Now.AddMonths(1);
        private string itemDescription;
        private DateTime dateAdded;
        private DateTime dateModified;
        private User modifiedBy;

        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string ItemType { get => itemType; set => itemType = value; }
        public DateTime PurchaseDate { get => purchaseDate; set => purchaseDate = value; }
        public string Supplier { get => supplier; set => supplier = value; }
        public string ItemCost { get => itemCost; set => itemCost = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public string ItemDescription { get => itemDescription; set => itemDescription = value; }
        public DateTime DateAdded { get => dateAdded; set => dateAdded = value; }
        public DateTime DateModified { get => dateModified; set => dateModified = value; }
        public User ModifiedBy { get => modifiedBy; set => modifiedBy = value; }
    }
}
