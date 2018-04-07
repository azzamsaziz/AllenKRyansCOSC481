namespace AllenKRyansCOSC481.Models
{
    public class CartItem
    {
        public Item Item { get; set; }
        public int Count { get; set; } = 1;
        public double Price => Item.Price * Count;
    }
}