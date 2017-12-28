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
        private string itemDescription;
        private double itemCost;

        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string ItemType { get => itemType; set => itemType = value; }
        public string ItemDescription { get => itemDescription; set => itemDescription = value; }
        public double ItemCost { get => itemCost; set => itemCost = value; }
    }
}
