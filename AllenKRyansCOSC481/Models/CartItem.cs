using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllenKRyansCOSC481.Models
{
    public class CartItem
    {
        public Item item { get; set; }
        public int index { get; set; } = -1;
        public int count { get; set; } = 1;
        public double price { get; set; } = 0;
        public void calculatePrice()
        {
            price = item.Price * count;
        }
    }
}