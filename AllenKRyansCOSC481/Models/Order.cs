using AllenKRyansCOSC481.DAL;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AllenKRyansCOSC481.Models
{
    public class Order
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        public double TotalPrice => Items.Sum(item => (item.Price)) * 1.06; // Taxes
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string OrderNote { get; set; } = string.Empty;

        [NotMapped]
        private List<Item> Items
        {
            get
            {
                return GetRelevantItems(ID).ToList();
            }
        }

        [NotMapped]
        public List<CartItem> CartItems
        {
            get
            {
                var cartItems = new List<CartItem>();
                var items = GetRelevantItems(ID).ToList();

                var groupedItems = items.GroupBy(item => item.ID);
                foreach (var groupedItem in groupedItems)
                {
                    var newCartItem = new CartItem
                    {
                        Count = groupedItem.Count(),
                        Item = groupedItem.ElementAt(0)
                    };
                    cartItems.Add(newCartItem);
                }

                return cartItems;
            }
        }

        private IEnumerable<Item> GetRelevantItems(Guid orderId)
        {
            IEnumerable<OrderItem> OrderItems;
            var Items = new List<Item>();

            using (var restaurantContext = new RestaurantContext())
            {
                OrderItems = restaurantContext.OrderItems.Where(orderItem => orderItem.OrderId == orderId);

                foreach (var orderItem in OrderItems)
                {
                    var itemFromDb = restaurantContext.Items.SingleOrDefault(item => item.ID == orderItem.ItemId);
                    if (itemFromDb != null)
                    {
                        Items.Add(itemFromDb);
                    }
                }
            }

            return Items;
        }
    }
}
