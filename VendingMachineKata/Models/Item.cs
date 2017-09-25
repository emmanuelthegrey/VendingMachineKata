using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata.Models
{
   public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(int id, string name, decimal price)
        {
            ID = id;
            Name = name;
            Price = price;
        }
    }
}
