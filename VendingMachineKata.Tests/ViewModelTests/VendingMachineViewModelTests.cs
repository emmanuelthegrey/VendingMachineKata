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
            Assert.AreEqual("cola : 0", vendingMachineViewModel.Items[0].ItemNameDisplay);
        }

        [Test]
        public void RefillAdds15QuantityToEachItem()
        {
            VendingMachineViewModel vendingMachineViewModel = new VendingMachineViewModel();
            vendingMachineViewModel.Refill();
            Assert.AreEqual(15, vendingMachineViewModel.Items[0].Quantity);
        }
    }
}
