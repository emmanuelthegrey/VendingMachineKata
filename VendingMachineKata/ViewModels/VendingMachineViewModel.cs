using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachineKata.Models;

namespace VendingMachineKata.ViewModels
{
   public class VendingMachineViewModel: ObservableObject
    {

        public DelegateCommand PurchaseCommand { get; private set; }
        public DelegateCommand RefillCommand { get; private set; }

        public ItemViewModel SelectedItem { get; set; }

        public ObservableCollection<ItemViewModel> Items { get; set; }
        public MoneyMangerViewModel MoneyInMachine { get; set; }

        public VendingMachineViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>()   {
                new ItemViewModel(1, "Cola", 1.00M),
                new ItemViewModel(2, "Chips", 0.50M),
                new ItemViewModel(3, "Candy", 0.65M),
                new ItemViewModel(4, "Portal Gun", Decimal.MaxValue)

            };

            MoneyInMachine = new MoneyMangerViewModel();

            
            PurchaseCommand = new DelegateCommand(Purchase);

        }

        public void InsertDime()
        {
            InsertChangeIntoMachine(CoinWeight.Dime, CoinDiameter.Dime);
        }

        public void InsertNickel()
        {
            InsertChangeIntoMachine(CoinWeight.Nickle, CoinDiameter.Nickle);
        }

        public void InsertQuater()
        {
            InsertChangeIntoMachine(CoinWeight.Quarter, CoinDiameter.Quarter);
        }

        public void Refill()
        {
            foreach (var item in Items)
            {
                item.RefillIndividualItemType();
            }
        }
        public void Empty()
        {
            foreach (var item in Items)
            {
                item.EmptyIndividualItemType();
            }
        }

        internal void InsertBadCoin()
        {
            InsertChangeIntoMachine(CoinWeight.BadCoin, CoinDiameter.BadCoin);
        }

        public void Purchase(object itemViewModel)
        {
            var selectedItem = itemViewModel as ItemViewModel;
            if(selectedItem.Item.Name.Equals("Portal Gun") && MoneyInMachine.BadCoinCount == 1)
            {
                selectedItem.Dispense();
                MessageBox.Show("Run For You Life! Rick Citadel will arrive in 5 mins");
            }
            MoneyInMachine.SelectedItemsPrice(selectedItem.Item.Price);

            if (MoneyInMachine.IsInsertedValueGreaterThanOrEqualToSelectedItemsPrice())
            {
                if (selectedItem.Dispense())
                {
                    MoneyInMachine.Tranaction();
                    //Update Property for Title TextBlock
                    if(MoneyInMachine.DimeCount > 1)
                    ExactChangeMessage = "Insert Coin";
                }
            }
        }

        public void InsertChangeIntoMachine(CoinWeight cw, CoinDiameter cd)
        {
            MoneyInMachine.Insert(cw, cd);
        }

        public void ReturnChange()
        {
            if(MoneyInMachine.CustomerAmountInserted > 0.00m)
            {
                MoneyInMachine.CustomerChangeToReturn = MoneyInMachine.CustomerAmountInserted;

                MoneyInMachine.CustomerAmountInserted = 0;
            }
        }
        private string _exactChangeMessage;

        public string ExactChangeMessage
        {
            get { return _exactChangeMessage; }
            set { _exactChangeMessage = value; OnPropertyChanged("ExactChangeMessage"); }
        }


    }
}
