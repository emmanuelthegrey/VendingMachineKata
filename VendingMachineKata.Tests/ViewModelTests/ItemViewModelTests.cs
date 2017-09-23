﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachineKata.ViewModels;

namespace VendingMachineKata.Tests.ViewModelTests
{
    [TestFixture]
    class ItemViewModelTests
    {
        [Test]
        public void VisibilityShouldReturnHiddenWhenViewModelIsCreated()
        {
            ItemViewModel chips = new ItemViewModel(1, "Chips", 1.00);

            Assert.AreEqual(Visibility.Visible, chips.ItemMessagesToCustomerVisibility);
        }

        [Test]
        public void WhenRefillIsCalledQuantityShouldBe15()
        {
            ItemViewModel chips = new ItemViewModel(1, "Chips", 1.00);
            chips.Refill();

            Assert.AreEqual(15, chips.Quantity);
        }
        [Test]
        public void WhenRefillIsCalledMoreThanOnceQuantityShouldBe15()
        {
            ItemViewModel chips = new ItemViewModel(1, "Chips", 1.00);
            chips.Refill();
            chips.Refill();
            Assert.AreEqual(15, chips.Quantity);
        }
    }
}
