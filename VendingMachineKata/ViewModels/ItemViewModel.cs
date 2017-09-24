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
        private const int MAXQUANITYPG = 1;
        private int _currentQuantity;
       // private int _currentPGQuantity;

        public Item Item { get {return _itemModel; } }

        

        public int ID
        {
            get { return _itemModel.ID; }
           
        }
        

        public int Quantity
        {
            get { return _currentQuantity; }
            private set
            {
                _currentQuantity = value;
                OnPropertyChanged("ItemMessagesToCustomerVisibility");
                OnPropertyChanged("ItemNameDisplay");
                OnPropertyChanged("Quantity");
            }
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

        public int EmptyIndividualItemType()
        {
            var amount = Quantity;
            Quantity = 0;
            return amount;
        }

        public int RefillIndividualItemType()
        {
            int amount;
            if (String.Equals(Item.Name, "Portal Gun"))
            {
                amount = MAXQUANITYPG;
                Quantity = MAXQUANITYPG;
                return amount;
            }
            amount = MAXQUANITY - _currentQuantity;
            Quantity += amount;

            
            return amount;
        }

        public bool Dispense()
        {
            if(Quantity > 0)
            {
                Quantity--;
                return true;
            }
            return false;
        }
    }
}
