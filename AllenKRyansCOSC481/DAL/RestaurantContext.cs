using AllenKRyansCOSC481.Models;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AllenKRyansCOSC481.DAL
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base("RestaurantContext")
        {
        }

        // Create the properties within the DB
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // When the model is created then remove the pluralizing table name convetion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}