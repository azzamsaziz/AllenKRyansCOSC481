using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using AllenKRyansCOSC481.DAL;
using AllenKRyansCOSC481.Models;

namespace AllenKRyansCOSC481.Controllers
{
    public class ItemsController : Controller
    {
        // The restaurant DB
        private RestaurantContext restaurantDb = new RestaurantContext();

        // GET: Items
        // Return the view to the user. This is mostly the admin
        public ActionResult Index()
        {
            return View(restaurantDb.Items.ToList());
        }

        // GET: Items/Details/5
        // Show the details of the items within the DB
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = restaurantDb.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Price,Type,Name,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                restaurantDb.Items.Add(item);
                restaurantDb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        // Edit the item within the DB
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = restaurantDb.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Price,Type,Name,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                restaurantDb.Entry(item).State = EntityState.Modified;
                restaurantDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        // Delete an item from the DB
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = restaurantDb.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = restaurantDb.Items.Find(id);
            restaurantDb.Items.Remove(item);
            restaurantDb.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                restaurantDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
