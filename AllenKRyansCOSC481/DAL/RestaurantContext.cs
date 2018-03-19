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

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}