namespace AllenKRyansCOSC481.Models
{
    public class CartItem
    {
        public Item Item { get; set; }
        public int Index { get; set; } = -1;
        public int Count { get; set; } = 1;
        public double Price { get; set; } = 0;

        public void CalculatePrice()
        {
            Price = Item.Price * Count;
        }
    }
}