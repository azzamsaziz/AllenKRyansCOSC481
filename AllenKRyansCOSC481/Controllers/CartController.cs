using AllenKRyans.Helpers;
using AllenKRyansCOSC481.DAL;
using AllenKRyansCOSC481.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllenKRyansCOSC481.Controllers
{
    public class CartController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        public ActionResult Order()
        {
            bool isUserLoggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (!isUserLoggedIn)
            {
                ViewBag.ErrorMessage = "You have to be logged in to make an order.";
                return View("Index");
            }

            List<CartItem> cartItems = (List<CartItem>)(Session["cart"]);

            // Add new order
            var newOrder = new Order
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            db.Orders.Add(newOrder);

            // Add new order items
            var newOrderItems = new List<OrderItem>();
            foreach (var cartItem in cartItems)
            {
                for (int i = 0; i < cartItem.Count; i++)
                {
                    var newOrderItem = new OrderItem
                    {
                        OrderId = newOrder.ID,
                        ItemId = cartItem.Item.ID,
                    };
                    newOrderItems.Add(newOrderItem);
                }
            }
            db.OrderItems.AddRange(newOrderItems);
            db.SaveChanges();

            // Reset the cart and send us back to the view
            Session["cart"] = null;

            ModelHelper.SendOrderConfirmationEmail(cartItems, UserManager.FindById(User.Identity.GetUserId()));

            return View("Index");
        }

        [HttpPost]
        public ActionResult Remove()
        {
            // Get the index of the item in the cart we want to remove
            Guid.TryParse(Request["itemId"], out Guid itemId);

            // Get the amount of items we want to remove from the cart
            int.TryParse(Request["amount"], out int amount);

            var cartItems = (List<CartItem>)(Session["cart"]);

            // Get the cart item in question
            var cartItem = cartItems.Single(crtItem => crtItem.Item.ID == itemId);

            // Reduce the amount of cart item
            // If the cart item count is 0, then remove it
            cartItem.Count -= amount;
            if (cartItem.Count == 0)
            {
                cartItems.Remove(cartItem);
            }
            if (!cartItems.Any()) // To clear the total calculations and the button from the Cart view
            {
                cartItems = null;
            }

            // Reset the cart and send us back to the view
            Session["cart"] = cartItems;

            return View("Index");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}