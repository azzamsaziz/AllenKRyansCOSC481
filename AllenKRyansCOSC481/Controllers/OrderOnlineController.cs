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
            List<CartItem> cart = (List<CartItem>)(Session["cart"]);

            var newOrder = new Order
            {
                Items = cart.Select(item => item.Item).ToList(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var addedOrder = db.Orders.Add(newOrder);
            
            foreach (var addedOrderItem in addedOrder.Items)
            {
                var newOrderItem = new OrderItem
                {
                    OrderId = addedOrder.ID,
                    ItemId = addedOrderItem.ID
                };
            }

            //db.SaveChanges();

            // Reset the cart and send us back to the view
            Session["cart"] = new List<CartItem>();

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult Remove()
        {
            // Get the index of the item in the cart we want to remove
            int.TryParse(Request["index"], out int index);
            //index--; // Ensure that the index is 0 based

            // Get the amount of items we want to remove from the cart
            int.TryParse(Request["amount"], out int amount);

            List<CartItem> cart = (List<CartItem>)(Session["cart"]);

            // Get the cart item in question
            var cartItem = cart.Single(item => item.Index == index);

            // Reduce the amount of cart item
            // If the cart item count is 0, then remove it
            cartItem.Count -= amount;
            if (cartItem.Count == 0)
            {
                cart.Remove(cartItem);
            }

            // Reset the cart and send us back to the view
            Session["cart"] = cart;

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            // Get the item index in question, and the count of the item we want to add
            int.TryParse(Request["itemIndex"], out int itemIndex);
            int.TryParse(Request["quantity"], out int count);

            // Get the items from the DB
            var items = db.Items.ToList();

            var cartItems = new List<CartItem>();

            // If the session is null, make a new one and add an item to it
            if (Session["cart"] == null)
            {
                cartItems = new List<CartItem>
                {
                    new CartItem { Item = items[itemIndex], Count = count, Index = itemIndex }
                };

                Session["cart"] = cartItems;
            }
            else
            {
                cartItems = (List<CartItem>)(Session["cart"]);
                cartItems.Add(new CartItem { Count = count, Item = items[itemIndex], Index = itemIndex });
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