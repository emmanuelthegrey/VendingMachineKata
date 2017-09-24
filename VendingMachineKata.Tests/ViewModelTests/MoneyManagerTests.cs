using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineKata.Models;
using VendingMachineKata.ViewModels;

namespace VendingMachineKata.Tests.ViewModelTests
{
    [TestFixture]
    public class MoneyManagerTests
    {
        [Test]
        public void InsertingDimeWeightAndDiameterReturns10Cents()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Dime, CoinDiameter.Dime);
            Assert.AreEqual(0.10, moneyMangerViewModel.CustomerAmountInserted);
        }

        [Test]
        public void InsertingNickelWeightAndDiameterReturns5Cents()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Nickle, CoinDiameter.Nickle);
            Assert.AreEqual(0.05, moneyMangerViewModel.CustomerAmountInserted);
        }

        [Test]
        public void InsertingQuaterWeightAndDiameterReturns25Cents()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            Assert.AreEqual(0.25, moneyMangerViewModel.CustomerAmountInserted);
        }

        [Test]
        public void InsertingQuaterDimeAndNickleReturns40Cents()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Nickle, CoinDiameter.Nickle);
            moneyMangerViewModel.Insert(CoinWeight.Dime, CoinDiameter.Dime);
            Assert.AreEqual(0.40, moneyMangerViewModel.CustomerAmountInserted);
        }

        [Test]
        public void SelctedValueEqualsPassedParameter()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.SelectedItemsPrice(1.00);
            Assert.AreEqual(1.00, moneyMangerViewModel.ItemRequestedTotalCost);
        }

        [Test]
        public void TranactionReturnsChange()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);

            moneyMangerViewModel.SelectedItemsPrice(1.00);
            moneyMangerViewModel.Tranaction();
            Assert.AreEqual(0.25, moneyMangerViewModel.CustomerChangeToReturn);
        }

        //[Test]
        //public void TranactionWithNotEnoughMoney()
        //{
        //    MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
        //    moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
          

        //    moneyMangerViewModel.SelectedItemsPrice(1.00);
        //    moneyMangerViewModel.Tranaction();
        //    Assert.AreEqual(-0.75, moneyMangerViewModel.CustomerChangeToReturn);
        //}
        [Test]
        public void IsInsertedValueEqualToOrGreaterSelectedItemPriceShouldReturnFalse()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);

            moneyMangerViewModel.SelectedItemsPrice(1.00);

            Assert.AreNotEqual(true, moneyMangerViewModel.IsInsertedValueGreaterThanOrEqualToSelectedItemsPrice());
        }

        [Test]
        public void IsInsertedValueEqualToOrGreaterSelectedItemPriceShouldReturnTrue()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);

            moneyMangerViewModel.SelectedItemsPrice(1.00);

            Assert.AreEqual(true, moneyMangerViewModel.IsInsertedValueGreaterThanOrEqualToSelectedItemsPrice());
        }
    }
}
