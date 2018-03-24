using AllenKRyansCOSC481.Models;

using System.Collections.Generic;
using System.Data.Entity;

namespace AllenKRyansCOSC481.DAL
{
    public class RestaurantInitializer : DropCreateDatabaseAlways<RestaurantContext>
    {
        protected override void Seed(RestaurantContext context)
        {
            var items = new List<Item>
            {
                // Party Packs
                new Item{ Name = "30 Piece Party Pack", Price = 75.99, Type = ItemType.PARTY_PACK, Description = "30 pieces of great chicken, a half pan of potato wedges, one-third pan of our famous homemade coleslaw and bread. Enough for 12–15 people." },
                new Item{ Name = "50 Piece Party Pack", Price = 115.99, Type = ItemType.PARTY_PACK, Description = "50 pieces of great chicken, full pan of potato wedges, a half pan of our famous homemade coleslaw and bread. Enough for 24–30 people." },
                new Item{ Name = "Full Pan of Ribs", Price = 104.95, Type = ItemType.PARTY_PACK, Description = "Approximately five slabs of BBQ ribs cut into two-bone sections. 28–30 pieces. Designed to go with our 50-piece party pack." },
                new Item{ Name = "Half Pan of Ribs", Price = 62.97, Type = ItemType.PARTY_PACK, Description = "Approximately three slabs of our mouth-watering BBQ ribs cut into two-bone sections. 16–18 pieces. Designed to go with our 30-piece party pack." },
                
                // Buckets
                new Item{ Name = "Family Chicken and Rib Combo", Price = 36.99, Type = ItemType.BUCKET, Description = "Eight pieces of chicken, one whole slab of ribs, potatoes, cole slaw & bread. Feeds 3–4 people." },
                new Item{ Name = "Family Value Bucket", Price = 20.99, Type = ItemType.BUCKET, Description = "10 pieces plus potato, and a pint of cole slaw & bread." },
                new Item{ Name = "Large Bucket", Price = 32.99, Type = ItemType.BUCKET, Description = "16 pieces plus 2 potatoes, 1 cole slaw & bread." },
                new Item{ Name = "X-Large Bucket", Price = 42.99, Type = ItemType.BUCKET, Description = "24 pieces plus 2 potatoes, 2 cole slaw & bread." },
                new Item{ Name = "Bucket of 10 Wings", Price = 11.49, Type = ItemType.BUCKET, Description = "BBQ, Plain, or Half-and-Half." },
                new Item{ Name = "10 Piece Cod Bucket", Price = 30.99, Type = ItemType.BUCKET, Description = "Plus potato and pint of coleslaw." },

               // Chicken by Itself
                new Item{ Name = "Broasted Chicken Breast", Price = 2.69, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "Grilled Chicken Breast", Price = 2.99, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "Chicken Wings", Price = 1.19, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "Chicken Leg", Price = 1.39, Type = ItemType.CHICKEN_ALONE, Description = "" },
                new Item{ Name = "Chicken Thigh", Price = 1.89, Type = ItemType.CHICKEN_ALONE, Description = "" },

                // Ribs by Themselves
                new Item{ Name = "4 Bones", Price = 7.99, Type = ItemType.RIBS_ALONE, Description = "" },
                new Item{ Name = "6 Bones", Price = 10.99, Type = ItemType.RIBS_ALONE, Description = "" },
                new Item{ Name = "8 Bones", Price = 14.99, Type = ItemType.RIBS_ALONE, Description = "" },
                new Item{ Name = "Full Slab", Price = 20.99, Type = ItemType.RIBS_ALONE, Description = "" },

                // Mixed Chicken
                // Additional charge for all white meat or barbecued.
                new Item{ Name = "2 Piece Leg & Thigh", Price = 2.70, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "2 Piece Breast & Wing", Price = 3.50, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "4 Pieces", Price = 5.40, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "6 Pieces", Price = 8.10, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "8 Pieces", Price = 10.80, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "10 Pieces", Price = 13.50, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "12 Pieces", Price = 16.20, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "14 Pieces", Price = 18.90, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "16 Pieces", Price = 21.60, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "20 Pieces", Price = 27.00, Type = ItemType.MIXED_CHICKEN, Description = "" },
                new Item{ Name = "24 Pieces", Price = 32.40, Type = ItemType.MIXED_CHICKEN, Description = "" },

                // Appetizers and Sides
                new Item{ Name = "Homemade Hearty Soup (Bowl)", Price = 2.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Homemade Hearty Soup (Pint)", Price = 5.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Homemade Hearty Soup (Quart)", Price = 11.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Mushrooms, Cauliflower or Zucchini", Price = 4.99, Type = ItemType.APPETIZER_SIDE, Description = "Lightly breaded & cooked golden brown. With ranch dressing add 75¢." },
                new Item{ Name = "The Famous 4 x 4", Price = 6.99, Type = ItemType.APPETIZER_SIDE, Description = "Onion rings, mushrooms, cauliflower, and zucchini." },
                new Item{ Name = "Fried Cheese Stix", Price = 4.99, Type = ItemType.APPETIZER_SIDE, Description = "With pizza sauce or ranch add 75¢." },
                new Item{ Name = "Battered Onion Rings (Small)", Price = 2.99, Type = ItemType.APPETIZER_SIDE, Description = "With ranch dressing add 75¢." },
                new Item{ Name = "Battered Onion Rings (Large)", Price = 5.99, Type = ItemType.APPETIZER_SIDE, Description = "Serves 3-4 people. With ranch dressing add 75¢." },
                new Item{ Name = "Vegetable of the Day", Price = 2.49, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Mashed Potatoes & Gravy (Small)", Price = 2.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Mashed Potatoes & Gravy (Large)", Price = 5.99, Type = ItemType.APPETIZER_SIDE, Description = "Serves 3-4 people." },
                new Item{ Name = "French Fries (Small)", Price = 1.99, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "French Fries (Large)", Price = 4.99, Type = ItemType.APPETIZER_SIDE, Description = "Serves 3-4 people." },
                new Item{ Name = "Potato Wedges (Small)", Price = 1.99, Type = ItemType.APPETIZER_SIDE , Description = "Served with sour cream or ranch add 75¢." },
                new Item{ Name = "Potato Wedges (Large)", Price = 4.99, Type = ItemType.APPETIZER_SIDE, Description = "Serves 3-4 people. Served with sour cream or ranch add 75¢." },
                new Item{ Name = "Cheezie Potatoes", Price = 5.99, Type = ItemType.APPETIZER_SIDE, Description = "Comes with melted cheddar cheese and bacon bits. With sour cream or ranch add 75¢." },
                new Item{ Name = "Chicken Wings", Price = 6.99, Type = ItemType.APPETIZER_SIDE, Description = "Try ‘em plain, BBQ’d or half & half. With Honey mustard or Ranch add 75¢." },
                new Item{ Name = "Homemade Mac n Cheese (Small)", Price = 2.49, Type = ItemType.APPETIZER_SIDE, Description = "" },
                new Item{ Name = "Homemade Mac n Cheese (Large)", Price = 4.99, Type = ItemType.APPETIZER_SIDE, Description = "" },

                /* Salads
                 Add any of these to your salad:
                 Chicken 2.59
                 Crumbled Bacon 1.49 
                 Cheddar Cheese 1.29
                 Turkey or Ham 2.29
                 Extra Dressing .75 */ 
                new Item{ Name = "Homemade Creamy Cole Slaw (6 oz)", Price = 1.99, Type = ItemType.SALAD, Description = "Finely chopped with a sweet, creamy homemade dressing. Made fresh daily." },
                new Item{ Name = "Homemade Creamy Cole Slaw (Pint)", Price = 4.99, Type = ItemType.SALAD, Description = "Finely chopped with a sweet, creamy homemade dressing. Made fresh daily." },
                new Item{ Name = "Homemade Creamy Cole Slaw (Quart)", Price = 9.99, Type = ItemType.SALAD, Description = "Finely chopped with a sweet, creamy homemade dressing. Made fresh daily." },
                new Item{ Name = "Potato Salad (6 oz)", Price = 2.49, Type = ItemType.SALAD, Description = "" },
                new Item{ Name = "Potato Salad (Pint)", Price = 4.99, Type = ItemType.SALAD, Description = "" },
                new Item{ Name = "Potato Salad (Quart)", Price = 9.99, Type = ItemType.SALAD, Description = "" },
                new Item{ Name = "Chef’s Salad (Small)", Price = 6.99, Type = ItemType.SALAD, Description = "Turkey, ham, bacon and cheddar cheese on tossed salad with tomato and cucumber." },
                new Item{ Name = "Chef’s Salad (Large)", Price = 8.99, Type = ItemType.SALAD, Description = "Turkey, ham, bacon and cheddar cheese on tossed salad with tomato and cucumber." },
                new Item{ Name = "Cobb Salad (Small)", Price = 6.99, Type = ItemType.SALAD, Description = "We start with a bed of greens and add bacon, cucumbers, tomatoes, chicken and cheddar cheese." },
                new Item{ Name = "Cobb Salad (Large)", Price = 8.99, Type = ItemType.SALAD, Description = "We start with a bed of greens and add bacon, cucumbers, tomatoes, chicken and cheddar cheese." },
                new Item{ Name = "Tossed Salad (Small)", Price = 2.99, Type = ItemType.SALAD, Description = "" },
                new Item{ Name = "Tossed Salad (Large)", Price = 5.99, Type = ItemType.SALAD, Description = "" },
                new Item{ Name = "Pasta Plus (Small)", Price = 6.99, Type = ItemType.SALAD, Description = "Pasta and vegetables on a bed of fresh greens with your choice of grilled chicken, ham or turkey on top." },
                new Item{ Name = "Pasta Plus (Large)", Price = 8.49, Type = ItemType.SALAD, Description = "Pasta and vegetables on a bed of fresh greens with your choice of grilled chicken, ham or turkey on top." },
                new Item{ Name = "Vegetarian Pasta (Small)", Price = 6.99, Type = ItemType.SALAD, Description = "Pasta and vegetables on a bed of fresh greens and cheddar cheese." },
                new Item{ Name = "Vegetarian Pasta (Large)", Price = 7.99, Type = ItemType.SALAD, Description = "Pasta and vegetables on a bed of fresh greens and cheddar cheese." },

                // All sandwiches include choice of cole slaw or potatoes.
                // * indicates ”Ask your server about menu items cooked to order or served raw. Consuming raw or undercooked meats may increase the risk of food-borne illness.”
                new Item{ Name = "Original Chicken Sandwich", Price = 6.49, Type = ItemType.SANDWICH_BURGER, Description = "Marinated just right." },
                new Item{ Name = "The Alpine Chicken Sandwich", Price = 7.49, Type = ItemType.SANDWICH_BURGER, Description = "Barbequed with Swiss cheese." },
                new Item{ Name = "The Cordon Bleu Chicken Sandwich", Price = 8.49, Type = ItemType.SANDWICH_BURGER, Description = "With ham and Swiss cheese." },
                new Item{ Name = "Turkey Sandwich", Price = 5.99, Type = ItemType.SANDWICH_BURGER, Description = ""  },
                new Item{ Name = "Turkey Club", Price = 7.49, Type = ItemType.SANDWICH_BURGER, Description = "With bacon and mayonnaise." },
                new Item{ Name = "Ham & Swiss", Price = 6.99, Type = ItemType.SANDWICH_BURGER, Description = "Hot or cold." },
                new Item{ Name = "*1/2 lb Burger", Price = 7.49, Type = ItemType.SANDWICH_BURGER, Description = "American or Swiss cheese add $.99, cheddar cheese add $1.29, Bacon burger or Ham-It-Up add $1.49." },
                new Item{ Name = "*1/3 lb burger", Price = 6.49, Type = ItemType.SANDWICH_BURGER, Description = "American or Swiss cheese add $.99, cheddar cheese add $1.29, Bacon burger or Ham-It-Up add $1.49." },

                // Chicken and Rib Dinners
                // All meals include potato wedges or french fries/coleslaw and bread
                // Served with or without our own special barbeque sauce
                // Try your Chicken BBQ’d For an additional charge. When ordering BBQ’d food, one cup of sauce compliments each order.
                // For any additional cups of sauce, there is a charge of 75¢ per cup
                new Item{ Name = "Regular", Price = 9.49, Type = ItemType.CHICKEN_RIBS, Description = "Breast, wing, leg and thigh." },
                new Item{ Name = "White", Price = 10.49, Type = ItemType.CHICKEN_RIBS, Description = "Two breasts and two wings." },
                new Item{ Name = "Dark", Price = 9.49, Type = ItemType.CHICKEN_RIBS, Description = "Two legs and two thighs." },
                new Item{ Name = "Six Wings", Price = 10.49, Type = ItemType.CHICKEN_RIBS, Description = "" },
                new Item{ Name = "Two Breasts", Price = 9.49, Type = ItemType.CHICKEN_RIBS, Description = "" },
                new Item{ Name = "Lite Bite White", Price = 7.49, Type = ItemType.CHICKEN_RIBS, Description = "Breast and wing." },
                new Item{ Name = "Lite Bite Dark", Price = 6.99, Type = ItemType.CHICKEN_RIBS, Description = "Leg and thigh." },
                new Item{ Name = "Hearty Cut", Price = 22.99, Type = ItemType.CHICKEN_RIBS, Description = "Whole slab (about 12 bones)." },
                new Item{ Name = "Hearty Cut (Split it)", Price = 25.99, Type = ItemType.CHICKEN_RIBS, Description = "If you want to split a slab with someone, you can both choose two side items." },
                new Item{ Name = "House Cut", Price = 17.99, Type = ItemType.CHICKEN_RIBS, Description = "About 8 bones." },
                new Item{ Name = "Half Slab", Price = 13.99, Type = ItemType.CHICKEN_RIBS, Description = "About 6 bones." },
                new Item{ Name = "Lite Rib", Price = 10.99, Type = ItemType.CHICKEN_RIBS, Description = "About 4 bones." },
                new Item{ Name = "Shrimp Half Portion (6 Piece)", Price = 8.99, Type = ItemType.CHICKEN_RIBS, Description = "Plump shrimp, lightly breaded." },
                new Item{ Name = "Shrimp Full Portion (10 Piece)", Price = 13.99, Type = ItemType.CHICKEN_RIBS, Description = "Plump shrimp, lightly breaded." },
                new Item{ Name = "Fish & Chips Half Portion (2 Piece)", Price = 7.99, Type = ItemType.CHICKEN_RIBS, Description = "Lightly floured cod." },
                new Item{ Name = "Fish & Chips Full Portion (3 Piece)", Price = 9.99, Type = ItemType.CHICKEN_RIBS, Description = "Lightly floured cod." },
                new Item{ Name = "2 Grilled Chicken Breasts", Price = 9.99, Type = ItemType.CHICKEN_RIBS, Description = "Marinated just right." },
                new Item{ Name = "Chicken Tender Dinner", Price = 9.49, Type = ItemType.CHICKEN_RIBS, Description = "100% white meat Broaster Recipe" },

                // Combinations 
                // All meals include potato wedges or french fries/coleslaw and bread
                new Item{ Name = "Chicken and Ribs (Small Combo)", Price = 12.99, Type = ItemType.COMBO, Description = "2 piece chicken, 3 bone rib." },
                new Item{ Name = "Chicken and Ribs (Large Combo)", Price = 16.49, Type = ItemType.COMBO, Description = "2 piece chicken, 6 bone rib." },
                new Item{ Name = "Ribs and Shrimp (Small Combo)", Price = 14.99, Type = ItemType.COMBO, Description = "3 bone rib, 4 piece shrimp." },
                new Item{ Name = "Ribs and Shrimp (Large Combo)", Price = 17.49, Type = ItemType.COMBO, Description = "6 bone rib, 6 piece shrimp." },
                new Item{ Name = "Chicken and Shrimp (Small Combo)", Price = 12.99, Type = ItemType.COMBO, Description = " 2 piece chicken, 4 piece shrimp." },
                new Item{ Name = "Chicken and Shrimp (Large Combo)", Price = 15.49, Type = ItemType.COMBO, Description = "2 piece chicken, 6 piece shrimp." },  
                new Item{ Name = "Triple Play", Price = 16.99, Type = ItemType.COMBO, Description = "2 pieces of chicken, three shrimp and 3 bones of barbeque ribs." }
            };

            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();
        }
    }
}