using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineKata.Models;

namespace VendingMachineKata.ViewModels
{
   public class VendingMachineViewModel: ObservableObject
    {

        public DelegateCommand PurchaseCommand { get; private set; }
        public DelegateCommand RefillCommand { get; private set; }

       public ObservableCollection<ItemViewModel> Items { get; set; }
        public MoneyMangerViewModel MoneyInMachine { get; set; }

        public VendingMachineViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>()   {
                new ItemViewModel(1, "cola", 1.00),
                new ItemViewModel(2, "chips", 0.50),
                new ItemViewModel(3, "candy", 0.65),
                new ItemViewModel(4, "Portal Gun", Double.MaxValue)

            };

            MoneyInMachine = new MoneyMangerViewModel();

            
            PurchaseCommand = new DelegateCommand(Purchase);

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

        public void Purchase(object itemViewModel)
        {
            var selectedItem = itemViewModel as ItemViewModel;
            MoneyInMachine.SelectedItemsPrice(selectedItem.Item.Price);

            if (MoneyInMachine.IsInsertedValueGreaterThanOrEqualToSelectedItemsPrice())
            {
                if (selectedItem.Dispense())
                {
                    MoneyInMachine.Tranaction();
                    //Update Property for Title TextBlock
                }
            }
        }

        public void InsertChangeIntoMachine(CoinWeight cw, CoinDiameter cd)
        {
            MoneyInMachine.Insert(cw, cd);
        }
    

    }
}
