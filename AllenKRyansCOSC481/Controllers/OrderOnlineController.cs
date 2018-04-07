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
        private RestaurantContext db = new RestaurantContext();

        [HttpPost]
        public ActionResult Order()
        {
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
            Session["cart"] = new List<CartItem>();

            return RedirectToAction("Cart");
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

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            // Get the item index in question, and the count of the item we want to add
            Guid.TryParse(Request["itemId"], out Guid itemId);
            int.TryParse(Request["quantity"], out int count);

            // Get the items from the DB
            var item = db.Items.Single(itemInDb => itemInDb.ID == itemId);

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
            else
            {
                cartItems = (List<CartItem>)(Session["cart"]);
                cartItems.Add(new CartItem { Item = item, Count = count });
            }

            Session["cart"] = cartItems;

            return RedirectToAction("Cart");
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

            return View(db.Items.OrderBy(x => x.Type));
        }
    }
}