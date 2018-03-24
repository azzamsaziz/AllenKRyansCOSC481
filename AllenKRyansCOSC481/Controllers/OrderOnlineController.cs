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
        private List<Item> cart = new List<Item>();

        // GET: OrderOnline
        public ActionResult Index()
        {
            ViewBag.Message = "Your Online Order";

            return View(db.Items.OrderBy(x => x.Type));
        }
    }
}