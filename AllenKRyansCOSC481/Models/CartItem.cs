using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllenKRyansCOSC481.Models
{
    public class CartItem
    {
        public Item item { get; set; }
        public int count { get; set; } = 1;
    }
}