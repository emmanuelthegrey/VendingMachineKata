using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata.Models
{
   public class CoinCount
    {
        public int NickleCount { get; set; }
        public int DimeCount { get; set; }
        public int BadCoinCount { get; set; }
        public int QuaterCount { get; set; }


        public CoinCount()
        {
            NickleCount = 0;
            QuaterCount = 0;
            DimeCount = 0;
            BadCoinCount = 0;
        }
    }
}
