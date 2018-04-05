using System.ComponentModel.DataAnnotations;

namespace AllenKRyansCOSC481.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
    }
}