﻿using NUnit.Framework;
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
    }
}
