using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineKata.ViewModels;

namespace VendingMachineKata.Tests.ViewModelTests
{
    [TestFixture]
   public class VendingMachineViewModelTests
    {
        [Test]
        public void VendingViewModelItemAtZeroIndexEqualColaAndHasZeroQuantity()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            Assert.AreEqual("Cola : 0", vendingMachineViewModel.Items[0].ItemNameDisplay);
        }

        [Test]
        public void RefillAdds15QuantityToEachExceptPortalGunItem()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            vendingMachineViewModel.Refill();
            Assert.AreEqual(15, vendingMachineViewModel.Items[0].Quantity);
            Assert.AreEqual(15, vendingMachineViewModel.Items[1].Quantity);
            Assert.AreEqual(15, vendingMachineViewModel.Items[2].Quantity);
            Assert.AreEqual(1, vendingMachineViewModel.Items[3].Quantity);
        }

        [Test]
        public void EmptySetsQuantityToZero()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            vendingMachineViewModel.Refill();
            vendingMachineViewModel.Empty();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, vendingMachineViewModel.Items[0].Quantity);
                Assert.AreEqual(0, vendingMachineViewModel.Items[1].Quantity);
                Assert.AreEqual(0, vendingMachineViewModel.Items[2].Quantity);
                Assert.AreEqual(0, vendingMachineViewModel.Items[3].Quantity);
            });

        }

        [Test]
        public void InsertDimeIntoVendingMachineReturnsCorrectTenCents()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            vendingMachineViewModel.MoneyInMachine.Insert(Models.CoinWeight.Dime, Models.CoinDiameter.Dime);

            Assert.AreEqual(0.10, vendingMachineViewModel.MoneyInMachine.CustomerAmountInserted);
        }

        [Test]
        public void PortalGunRefillsToOne()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            vendingMachineViewModel.Refill();
            Assert.AreEqual(15, vendingMachineViewModel.Items[0].Quantity);
            Assert.AreEqual(15, vendingMachineViewModel.Items[1].Quantity);
            Assert.AreEqual(15, vendingMachineViewModel.Items[2].Quantity);
            Assert.AreEqual(1, vendingMachineViewModel.Items[3].Quantity);
        }

        [Test]
        public void InsertDimeMethodAdds10CentsToAmountInserted()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            vendingMachineViewModel.InsertDime();

            Assert.AreEqual(0.10, vendingMachineViewModel.MoneyInMachine.CustomerAmountInserted);
        }

        [Test]
        public void Insert3DimeMethodAdds30CentsToAmountInserted()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            vendingMachineViewModel.InsertDime();
            vendingMachineViewModel.InsertDime();
            vendingMachineViewModel.InsertDime();
            Assert.That( 0.30, Is.EqualTo(vendingMachineViewModel.MoneyInMachine.CustomerAmountInserted).Within(0.005));
        }
        [Test]
        public void ReturnChangeMovesMoneyFromInsertedToChangeReturned()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            vendingMachineViewModel.InsertDime();
            vendingMachineViewModel.InsertDime();
            vendingMachineViewModel.InsertDime();
            vendingMachineViewModel.ReturnChange();
            Assert.That(0.30, Is.EqualTo(vendingMachineViewModel.MoneyInMachine.CustomerChangeToReturn).Within(0.005));
        }
    }
}
