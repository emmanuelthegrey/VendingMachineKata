using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata.Models
{
    public enum CoinDiameter
    {
        [Description("21.21 mm")]
        Nickle = 21,
        [Description("17.91 mm")]
        Dime = 17,
        [Description("24.26 mm")]
        Quarter = 24
    }
}
