using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineKata.Models;

namespace VendingMachineKata.ViewModels
{
    public class MoneyMangerViewModel : ObservableObject
    {
        private decimal _customerAmountInserted;

        public decimal CustomerAmountInserted
        {
            get { return _customerAmountInserted; }
            set
            {
                _customerAmountInserted = value;
                OnPropertyChanged("CustomerAmountInserted");
            }
        }

        private decimal _itemdRequestedTotalCost;

        public decimal ItemRequestedTotalCost
        {
            get { return _itemdRequestedTotalCost; }
            set
            {
                _itemdRequestedTotalCost = value;
                OnPropertyChanged("ItemRequestedTotalCost");
            }
        }

        private decimal _customerChangeToReturn;

        public decimal CustomerChangeToReturn
        {
            get { return _customerChangeToReturn; }
            set
            {
                _customerChangeToReturn = value;
                OnPropertyChanged("CustomerChangeToReturn");
            }
        }

        private decimal _machineMoneyTotal;

        public decimal MachineMoneyTotal
        {
            get { return _machineMoneyTotal; }
            set
            {
                _machineMoneyTotal = value;
                OnPropertyChanged("MachineMoneyTotal");

            }
        }

        CoinCount coinsInMachine = new CoinCount();


        public MoneyMangerViewModel()
        {
            
            

            CustomerAmountInserted = 0;
            CustomerChangeToReturn = 0;
            ItemRequestedTotalCost = 0;

            MachineMoneyTotal = 0;
        }


        public int QuaterCount {
            get {return coinsInMachine.QuaterCount; }
        }



        public void Insert(CoinWeight coinWeight, CoinDiameter coinDiameter)
        {

            decimal value = CalculateCoinValue(coinWeight, coinDiameter);

            if (value.Equals(0.10m))
            {
                coinsInMachine.DimeCount++;
            }
            else if (value.Equals(0.05m))
            {
                coinsInMachine.NickleCount++;
            }
            else if (value.Equals(0.25m))
            {
                coinsInMachine.QuaterCount++;
            }

            CustomerAmountInserted += value;
        }

        private decimal CalculateCoinValue(CoinWeight coinWeight, CoinDiameter coinDiameter)
        {
            if (coinDiameter == CoinDiameter.Dime && coinWeight == CoinWeight.Dime)
            {
                
                return 0.10m;
            }
            else if (coinDiameter == CoinDiameter.Nickle && coinWeight == CoinWeight.Nickle)
            {
                return 0.05m;
            }
            else if (coinDiameter == CoinDiameter.Quarter && coinWeight == CoinWeight.Quarter)
            {
                return 0.25m;
            }

            return 0.00m;
        }
        public void SelectedItemsPrice(decimal value)
        {
            ItemRequestedTotalCost = value;
        }

        public void Tranaction()
        {
            CustomerChangeToReturn = CustomerAmountInserted - ItemRequestedTotalCost;
            MachineMoneyTotal += ItemRequestedTotalCost;
            ItemRequestedTotalCost = 0;
            CustomerAmountInserted = 0;
        }

        public bool IsInsertedValueGreaterThanOrEqualToSelectedItemsPrice()
        {
           if(CustomerAmountInserted >= ItemRequestedTotalCost)
            {
                return true;
            }
            return false;
        }
    }
}

