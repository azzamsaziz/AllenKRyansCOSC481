using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AllenKRyansCOSC481.DAL;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AllenKRyansCOSC481.Models
{
    public enum UserRoles
    {
        [Description("Admin")]
        ADMIN,
        [Description("Customer")]
        CUSTOMER
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        private IEnumerable<Order> GetOrders()
        {
            IEnumerable<Order> orders;

            using (var restaurantContext = new RestaurantContext())
            {
                // TODO: Add OrderItem to link between the two tables and avoid getting the entire table everytime.
                orders = restaurantContext.Orders;
            }

            return orders;
        }

        public IEnumerable<Order> ActiveOrders
        {
            get
            {
                return GetOrders()?.Where(order => (DateTime.Now - order.CreatedDate).TotalMinutes <= 15);
            }
        }

        public IEnumerable<Order> PreviousOrders
        {
            get
            {
                return GetOrders()?.Where(order => (DateTime.Now - order.CreatedDate).TotalMinutes > 15);
            }
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}