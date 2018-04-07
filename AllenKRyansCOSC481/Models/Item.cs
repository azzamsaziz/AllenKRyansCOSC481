using System;
using System.ComponentModel.DataAnnotations;

namespace AllenKRyansCOSC481.Models
{
    public enum ItemType
    {
        PARTY_PACK,
        BUCKET,
        CHICKEN_ALONE,
        RIBS_ALONE,
        MIXED_CHICKEN,
        APPETIZER_SIDE,
        SALAD,
        SANDWICH_BURGER,
        CHICKEN_RIBS,
        COMBO,
        OTHER,
        BAD_DATA
    }

    public class Item
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        public double Price { get; set; }
        public ItemType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}