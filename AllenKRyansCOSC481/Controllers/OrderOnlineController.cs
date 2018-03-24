﻿using AllenKRyansCOSC481.DAL;
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
        static private List<Item> cart = new List<Item>();
        static private List<Item> menu = new List<Item>();

        public ActionResult AddToCart(int num)
        {
            cart.Add(menu[num]);
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            return View(cart);
        }

        // GET: OrderOnline
        public ActionResult Index()
        {
            ViewBag.Message = "Your Online Order";
            IEnumerable<Item> Model = db.Items.OrderBy(x => x.Type);
            foreach(var item in Model)
            {
                menu.Add(item);
            }

            return View(menu);
        }
    }
}