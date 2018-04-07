using System;
using System.ComponentModel.DataAnnotations;

namespace AllenKRyansCOSC481.Models
{
    public class OrderItem
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid ItemId { get; set; }
        public Guid OrderId { get; set; }
    }
}