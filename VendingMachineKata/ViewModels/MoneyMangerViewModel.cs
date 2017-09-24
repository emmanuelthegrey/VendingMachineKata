using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineKata.Models;

namespace VendingMachineKata.ViewModels
{
    public class MoneyMangerViewModel
    {
        private double _customerAmountInserted;

        public double CustomerAmountInserted
        {
            get { return _customerAmountInserted; }
            set { _customerAmountInserted = value; }
        }

        private double _itemdRequestedTotalCost;

        public double ItemRequestedTotalCost
        {
            get { return _itemdRequestedTotalCost; }
            set { _itemdRequestedTotalCost = value; }
        }

        private double _customerChangeToReturn;

        public double CustomerChangeToReturn
        {
            get { return _customerChangeToReturn; }
            set { _customerChangeToReturn = value; }
        }

        private double _machineMoneyTotal;

        public double MachineMoneyTotal
        {
            get { return _machineMoneyTotal; }
            set { _machineMoneyTotal = value; }
        }

        public MoneyMangerViewModel()
        {
            CustomerAmountInserted = 0;
            CustomerChangeToReturn = 0;
            ItemRequestedTotalCost = 0;

            MachineMoneyTotal = 0;
        }

        public void Insert(CoinWeight coinWeight, CoinDiameter coinDiameter)
        {
            double value = CalculateCoinValue(coinWeight, coinDiameter);
            CustomerAmountInserted += value;
        }

        private double CalculateCoinValue(CoinWeight coinWeight, CoinDiameter coinDiameter)
        {
            if (coinDiameter == CoinDiameter.Dime && coinWeight == CoinWeight.Dime)
            {
                return 0.10;
            }
            else if (coinDiameter == CoinDiameter.Nickle && coinWeight == CoinWeight.Nickle)
            {
                return 0.05;
            }
            else if (coinDiameter == CoinDiameter.Quarter && coinWeight == CoinWeight.Quarter)
            {
                return 0.25;
            }

            return 0.00;
        }
        public void SelectedItemsPrice(double value)
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

