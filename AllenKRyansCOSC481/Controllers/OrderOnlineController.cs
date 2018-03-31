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

        public ActionResult AddToCart(int num)
        {
            List<Item> menu = new List<Item>();
            IEnumerable<Item> Model = db.Items.OrderBy(x => x.Type);
            foreach (var item in Model)
            {
                menu.Add(item);
            }
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<CartItem>();
                var lst = (List<CartItem>)(Session["cart"]);
                //lst.Add(new CartItem { item = menu[num], count = Request[]  });
            }
            else
            {
                var lst = (List<Item>)(Session["cart"]);
                lst.Add(menu[num]);
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
            foreach(var item in Model)
            {
                menu.Add(item);
            }

            return View(menu);
        }
    }
}