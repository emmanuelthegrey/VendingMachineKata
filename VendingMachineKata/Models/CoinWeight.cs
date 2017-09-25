using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata.Models
{
    public enum CoinWeight
    {
        [Description("5 Grams")]
        Nickle = 5,
        [Description("2.268 Grams")]
        Dime = 2,
        [Description("5.670 Grams")]
        Quarter = 6,
        [Description("Bad Coin")]
        BadCoin = 71

    }
}
