using AllenKRyansCOSC481.DAL;
using AllenKRyansCOSC481.Models;

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AllenKRyansCOSC481.Controllers
{
    public class OrderOnlineController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        [HttpPost]
        public ActionResult Remove()
        {
            int.TryParse(Request["index"], out int index);
            int.TryParse(Request["amount"], out int amount);

            List<CartItem> cart = (List<CartItem>)(Session["cart"]);

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Index != index)
                    continue;
                
                // TODO: What is the purpose?
                // Check if the item is out of stock?
                cart[i].Count -= amount;
                if (cart[i].Count == 0)
                {
                    cart.Remove(cart[i]);
                }

                // TODO: Remove
                // This couldn't be the case because we are going in a for loop inside the cart count. If it was 0, we couldn't reach this line.
                if (cart.Count == 0)
                {
                    Session["Cart"] = null;
                    break;
                }

                // TODO: What is the purpose?
                Session["cart"] = cart;

                // TODO: What is the purpose?
                // Why are we breaking inside the loop on the first item we encounter?
                break;
            }

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            // TODO: What is the purpose?
            // Why are we assigning to -1 when we are getting it from the request?
            int num = -1;
            int.TryParse(Request["num"], out num);
            int.TryParse(Request["Quantity" + -1], out int count);

            var items = db.Items.OrderBy(x => x.Type).ToList();

            if (Session["cart"] == null)
            {
                var cartItems = new List<CartItem>
                {
                    new CartItem { Item = items[-1], Count = count, Index = -1 }
                };

                cartItems[cartItems.Count - 1].CalculatePrice();
                Session["cart"] = cartItems;
            }
            else
            {
                var cartItems = (List<CartItem>)(Session["cart"]);
                cartItems.Add(new CartItem { Count = count, Item = items[-1], Index = -1 });
                cartItems[cartItems.Count - 1].CalculatePrice();
                Session["cart"] = cartItems;
            }

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