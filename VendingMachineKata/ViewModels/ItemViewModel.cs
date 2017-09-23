using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachineKata.Models;

namespace VendingMachineKata.ViewModels
{
   public class ItemViewModel: ObservableObject
    {
        public ItemViewModel(int id, string name, double price)
        {
            _itemModel = new Item(id, name, price);
            Quantity = 0;
        }

        private Item _itemModel;
        private const int MAXQUANITY = 15;
        private int _currentQuantity;

        public Item Item { get {return _itemModel; } }

        private int id;

        public int ID
        {
            get { return _itemModel.ID; }
           
        }
        private int quantity;

        public int Quantity
        {
            get { return _currentQuantity; }
            private set { _currentQuantity = value; }
        }

        public string ItemNameDisplay
        {
            get { return $"{_itemModel.Name} : {_currentQuantity}"; }
           
        }

        public Visibility ItemMessagesToCustomerVisibility
        {
            get
            {
                if(Quantity > 0)
                {
                   return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public int Empty()
        {
            var amount = Quantity;
            Quantity = 0;
            return amount;
        }

        public int Refill()
        {
            var amount = MAXQUANITY - _currentQuantity;
            Quantity += amount;
            return amount;
        }

        
    }
}
