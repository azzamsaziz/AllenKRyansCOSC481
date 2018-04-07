namespace AllenKRyansCOSC481.Models
{
    public class CartItem
    {
        public Item Item { get; set; } = new Item();
        public int Index { get; set; } = -1;
        public int Count { get; set; } = 1;
        public double Price => Item.Price * Count;
    }
}