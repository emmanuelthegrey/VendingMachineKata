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
            Assert.AreEqual(0.10m, moneyMangerViewModel.CustomerAmountInserted);
        }

        [Test]
        public void InsertingNickelWeightAndDiameterReturns5Cents()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Nickle, CoinDiameter.Nickle);
            Assert.AreEqual(0.05m, moneyMangerViewModel.CustomerAmountInserted);
        }

        [Test]
        public void InsertingQuaterWeightAndDiameterReturns25Cents()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            Assert.AreEqual(0.25m, moneyMangerViewModel.CustomerAmountInserted);
        }

        [Test]
        public void InsertingQuaterDimeAndNickleReturns40Cents()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Nickle, CoinDiameter.Nickle);
            moneyMangerViewModel.Insert(CoinWeight.Dime, CoinDiameter.Dime);
            Assert.AreEqual(0.40m, moneyMangerViewModel.CustomerAmountInserted);
        }

        [Test]
        public void SelctedValueEqualsPassedParameter()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.SelectedItemsPrice(1.00m);
            Assert.AreEqual(1.00m, moneyMangerViewModel.ItemRequestedTotalCost);
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

            moneyMangerViewModel.SelectedItemsPrice(1.00m);
            moneyMangerViewModel.Tranaction();
            Assert.AreEqual(0.25m, moneyMangerViewModel.CustomerChangeToReturn);
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

            moneyMangerViewModel.SelectedItemsPrice(1.00m);

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

            moneyMangerViewModel.SelectedItemsPrice(1.00m);

            Assert.AreEqual(true, moneyMangerViewModel.IsInsertedValueGreaterThanOrEqualToSelectedItemsPrice());
        }

        [Test]
        public void IfTwoQuatersAreInsertedQuaterCountEqualsTwo()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);
            moneyMangerViewModel.Insert(CoinWeight.Quarter, CoinDiameter.Quarter);

            Assert.AreEqual(2, moneyMangerViewModel.QuaterCount);
        }

        [Test]
        public void IfTwoDimesAreInsertedDimeCountEqualsTwo()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Dime, CoinDiameter.Dime);
            moneyMangerViewModel.Insert(CoinWeight.Dime, CoinDiameter.Dime);

            Assert.AreEqual(2, moneyMangerViewModel.DimeCount);
        }

        [Test]
        public void IfTwoNickelsAreInsertedNickleCountEqualsTwo()
        {
            MoneyMangerViewModel moneyMangerViewModel = new MoneyMangerViewModel();
            moneyMangerViewModel.Insert(CoinWeight.Nickle, CoinDiameter.Nickle);
            moneyMangerViewModel.Insert(CoinWeight.Nickle, CoinDiameter.Nickle);

            Assert.AreEqual(2, moneyMangerViewModel.NickleCount);
        }
    }
}
