using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AllenKRyansCOSC481.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AllenKRyansCOSC481.Models
{
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

        //public IEnumerable<Order> GetOrders()
        //{
        //    IEnumerable<Order> orders;

        //    using (var restaurantContext = new RestaurantContext())
        //    {
        //        IQueryable<Order> ordersQueriable = from temp in restaurantContext.Orders select temp;
        //        orders = ordersQueriable.ToList();
        //    }

        //    return orders;
        //}

        //private IEnumerable<Order> _orders;
        //public IEnumerable<Order> Orders
        //{
        //    get
        //    {
        //        if (!_orders.Any())
        //        {
        //            _orders = GetOrders();
        //            return _orders;
        //        }

        //        return _orders;
        //    }
        //    set { _orders = value; }
        //}
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