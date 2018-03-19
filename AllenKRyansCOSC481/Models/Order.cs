using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AllenKRyansCOSC481.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public double TotalPrice => Items.Sum(item => (item.Price * 1.06));
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        //public ApplicationUser OrderedBy { get; set; }
        public string OrderNote { get; set; }
    }
}
