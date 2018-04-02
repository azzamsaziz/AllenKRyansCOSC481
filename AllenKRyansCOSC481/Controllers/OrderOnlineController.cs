using AllenKRyansCOSC481.DAL;
using AllenKRyansCOSC481.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllenKRyansCOSC481.Controllers
{
    public class OrderOnlineController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        [HttpPost]
        public ActionResult Remove()
        {
            int amt = 1;
            int index = 0;
            int.TryParse(Request["index"], out index);
            int.TryParse(Request["amount"], out amt);

            List<CartItem> cart = (List<CartItem>)(Session["cart"]);

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].index == index)
                {
                    cart[i].count -= amt;
                    if (cart[i].count == 0)
                    {
                        cart.Remove(cart[i]);
                    }
                    if (cart.Count == 0)
                    {
                        Session["Cart"] = null;
                        break;
                    }
                    Session["cart"] = cart;

                    break;
                }
            }
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            int cnt = 1;
            int num = -1;
            int.TryParse(Request["num"], out num);
            int.TryParse(Request["Quantity" + num], out cnt);
            List<Item> menu = new List<Item>();
            IEnumerable<Item> Model = db.Items.OrderBy(x => x.Type);
            foreach (var item in Model)
            {
                menu.Add(item);
            }
            if (Session["cart"] == null)
            {
                var lst = new List<CartItem>();
                lst.Add(new CartItem { item = menu[num], count = cnt, index = num });
                lst[lst.Count - 1].calculatePrice();
                Session["cart"] = lst;
            }
            else
            {
                var lst = (List<CartItem>)(Session["cart"]);
                lst.Add(new CartItem { count = cnt, item = menu[num], index = num });
                lst[lst.Count - 1].calculatePrice();
                Session["cart"] = lst;
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
            List<Item> menu = new List<Item>();
            IEnumerable<Item> Model = db.Items.OrderBy(x => x.Type);
            foreach (var item in Model)
            {
                menu.Add(item);
            }
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<CartItem>();
            }
            Session["count"] = 1;

            return View(menu);
        }
    }
}