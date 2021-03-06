﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
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
        RestaurantContext restaurantContext = new RestaurantContext();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // Get all the orders in the DB
        private IEnumerable<Order> GetOrders()
        {
            IEnumerable<Order> orders;

            // TODO: Add OrderItem to link between the two tables and avoid getting the entire table everytime.
            orders = restaurantContext.Orders;

            return orders;
        }

        // Add the custom property of finding the active orders
        public IEnumerable<Order> ActiveOrders
        {
            get
            {
                return GetOrders()?.Where(order => (DateTime.Now - order.CreatedDate).TotalMinutes <= 15);
            }
        }

        // Add the custom property of finding the previous orders
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