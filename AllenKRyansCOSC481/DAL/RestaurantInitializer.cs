using AllenKRyansCOSC481.Models;

using System.Collections.Generic;

namespace AllenKRyansCOSC481.DAL
{
    public class RestaurantInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RestaurantContext>
    {
        protected override void Seed(RestaurantContext context)
        {
            var students = new List<Item>
            {
                new Item{ Name = "Ribs", Price = 10.0, Type = ItemType.RIBS_ALONE, Description = "It's ribs" },
                new Item{ Name = "Chicken", Price = 50.0, Type = ItemType.CHICKEN_ALONE, Description = "It's chicken" }
            };

            students.ForEach(s => context.Items.Add(s));
            context.SaveChanges();
        }
    }
}