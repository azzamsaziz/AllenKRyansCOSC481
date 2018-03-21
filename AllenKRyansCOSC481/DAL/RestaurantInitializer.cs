using AllenKRyansCOSC481.Models;

using System.Collections.Generic;
using System.Data.Entity;

namespace AllenKRyansCOSC481.DAL
{
    public class RestaurantInitializer : DropCreateDatabaseIfModelChanges<RestaurantContext>
    {
        protected override void Seed(RestaurantContext context)
        {
            var items = new List<Item>
            {
                new Item{ Name = "30 Piece Party Pack", Price = 75.99, Type = ItemType.PARTY_PACK, Description = "30 pieces of great chicken, a half pan of potato wedges, one-third pan of our famous homemade coleslaw and bread. Enough for 12–15 people." },
                new Item{ Name = "50 Piece Party Pack", Price = 115.99, Type = ItemType.PARTY_PACK, Description = "50 pieces of great chicken, full pan of potato wedges, a half pan of our famous homemade coleslaw and bread. Enough for 24–30 people." },
                new Item{ Name = "Full Pan of Ribs", Price = 104.95, Type = ItemType.PARTY_PACK, Description = "Approximately five slabs of BBQ ribs cut into two-bone sections. 28–30 pieces. Designed to go with our 50-piece party pack." },
                new Item{ Name = "Half Pan of Ribs", Price = 62.97, Type = ItemType.PARTY_PACK, Description = "Approximately three slabs of our mouth-watering BBQ ribs cut into two-bone sections. 16–18 pieces. Designed to go with our 30-piece party pack." },
                new Item{ Name = "10 pc Cod Bucket", Price = 30.99, Type = ItemType.BUCKET, Description = "Plus potato and pint of coleslaw." },
                new Item{ Name = "Bucket of 10 Wings", Price = 11.49, Type = ItemType.BUCKET, Description = "BBQ, Plain, or Half-and-Half." },
                new Item{ Name = "Family Chicken and Rib Combo", Price = 36.99, Type = ItemType.BUCKET, Description = "Eight pieces of chicken, one whole slab of ribs, potatoes, cole slaw & bread. Feeds 3–4 people." },
                new Item{ Name = "Family Value Bucket", Price = 20.99, Type = ItemType.BUCKET, Description = "10 pieces plus potato, and a pint of cole slaw & bread." },
                new Item{ Name = "Large Bucket", Price = 32.99, Type = ItemType.BUCKET, Description = "16 pieces plus 2 potatoes, 1 cole slaw & bread." },
                new Item{ Name = "X-Large Bucket", Price = 42.99, Type = ItemType.BUCKET, Description = "24 pieces plus 2 potatoes, 2 cole slaw & bread." },
                new Item{ Name = "Broasted Chicken Breast", Price = 2.69, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "Chicken Leg", Price = 1.39, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "Chicken Thigh", Price = 1.89, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "Chicken Wings", Price = 1.19, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "Grilled Chicken Breast", Price = 2.99, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "4 Bones", Price = 7.99, Type = ItemType.RIBS_ALONE, Description = "" },
                new Item{ Name = "6 Bones", Price = 10.99, Type = ItemType.RIBS_ALONE, Description = "" },
                new Item{ Name = "8 Bones", Price = 14.99, Type = ItemType.RIBS_ALONE, Description = "" },
                new Item{ Name = "Full Slab", Price = 20.99, Type = ItemType.RIBS_ALONE, Description = "" },
                new Item{ Name = "10 Pieces", Price = 13.50, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "12 Pieces", Price = 16.20, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "14 Pieces", Price = 18.90, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "16 Pieces", Price = 21.60, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "2 Piece Breast & Wing", Price = 3.50, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "2 Piece Leg & Thigh", Price = 2.70, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "20 Pieces", Price = 27.00, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "24 Pieces", Price = 32.40, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "4 Pieces", Price = 5.40, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "6 Pieces", Price = 8.10, Type = ItemType.PARTY_PACK, Description = "" },
                new Item{ Name = "8 Pieces", Price = 10.80, Type = ItemType.PARTY_PACK, Description = "" },
                new Item{ Name = "Battered Onion Rings (Large)", Price = 5.99, Type = ItemType.APPETIZER_SIDE, Description = "Serves 3-4 people. With ranch dressing add 75¢" },
                new Item{ Name = "Battered Onion Rings (Small)", Price = 2.99, Type = ItemType.APPETIZER_SIDE, Description = "With ranch dressing add 75¢" },
                new Item{ Name = "French Fries (Large)", Price = 4.99, Type = ItemType.APPETIZER_SIDE, Description = "Serves 3-4 people." },
                new Item{ Name = "French Fries (Small)", Price = 1.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Fried Cheese Stix", Price = 4.99, Type = ItemType.APPETIZER_SIDE, Description = "With pizza sauce or ranch add 75¢." },
                new Item{ Name = "Homemade Hearty Soup (Bowl)", Price = 2.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Homemade Hearty Soup (Pint)", Price = 5.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Homemade Hearty Soup (Quart)", Price = 11.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Mashed Potatoes & Gravy (Large)", Price = 5.99, Type = ItemType.APPETIZER_SIDE, Description = "Serves 3-4 people." },
                new Item{ Name = "Mashed Potatoes & Gravy (Small)", Price = 2.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Mushrooms, Cauliflower or Zucchini", Price = 4.99, Type = ItemType.APPETIZER_SIDE, Description = "Lightly breaded & cooked golden brown. With ranch dressing add 75¢." },
                new Item{ Name = "The Famous 4 x 4", Price = 6.99, Type = ItemType.PARTY_PACK, Description = "Onion rings, mushrooms, cauliflower, and zucchini." }
            };

            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();
        }
    }
}