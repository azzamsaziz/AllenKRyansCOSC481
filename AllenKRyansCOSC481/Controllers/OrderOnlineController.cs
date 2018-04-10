using AllenKRyansCOSC481.DAL;
using AllenKRyansCOSC481.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AllenKRyansCOSC481.Controllers
{
    public class OrderOnlineController : Controller
    {
        // DB for the restaurant
        private RestaurantContext restaurantDb = new RestaurantContext();

        // Post for the add to cart functionality
        [HttpPost]
        public ActionResult AddToCart()
        {
            // Get the item index in question, and the count of the item we want to add
            Guid.TryParse(Request["itemId"], out Guid itemId);
            int.TryParse(Request["quantity"], out int count);

            // Get the items from the DB
            var item = restaurantDb.Items.Single(itemInDb => itemInDb.ID == itemId);

            var cartItems = new List<CartItem>();

            // If the session is null, make a new one and add an item to it
            if (Session["cart"] == null)
            {
                cartItems = new List<CartItem>
                {
                    new CartItem { Item = item, Count = count }
                };

                Session["cart"] = cartItems;
            }
            // If the cart already exists then we add the items to the list
            else
            {
                cartItems = (List<CartItem>)(Session["cart"]);

                // Check if the item already exists within the cart. If so, add the count. Otherwise add the item
                var cartItem = cartItems.SingleOrDefault(crtItem => crtItem.Item.ID == item.ID);
                if (cartItem != null)
                {
                    cartItem.Count++;
                }
                else
                {
                    cartItems.Add(new CartItem { Item = item, Count = count });
                }
            }

            Session["cart"] = cartItems;

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Cart()
        {
            return View();
        }

        // GET: OrderOnline
        public ActionResult Index()
        {
            ViewBag.Message = "Your Online Order";

            if (Session["cart"] == null)
            {
                Session["cart"] = new List<CartItem>();
            }
            Session["count"] = 1;

            return View(restaurantDb.Items.OrderBy(x => x.Type));
        }
    }
}