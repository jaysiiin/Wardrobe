using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe1.Models;

namespace Wardrobe1.Controllers
{
    public class ShoeStuffsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: ShoeStuffs
        public ActionResult Index()
        {
            return View(db.ShoeStuffs.ToList());
        }

        // GET: ShoeStuffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeStuff shoeStuff = db.ShoeStuffs.Find(id);
            if (shoeStuff == null)
            {
                return HttpNotFound();
            }
            return View(shoeStuff);
        }

        // GET: ShoeStuffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoeStuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoeID,Name,Photo,Type,Color,Season,Occasion")] ShoeStuff shoeStuff)
        {
            if (ModelState.IsValid)
            {
                db.ShoeStuffs.Add(shoeStuff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoeStuff);
        }

        // GET: ShoeStuffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeStuff shoeStuff = db.ShoeStuffs.Find(id);
            if (shoeStuff == null)
            {
                return HttpNotFound();
            }
            return View(shoeStuff);
        }

        // POST: ShoeStuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoeID,Name,Photo,Type,Color,Season,Occasion")] ShoeStuff shoeStuff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoeStuff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoeStuff);
        }

        // GET: ShoeStuffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeStuff shoeStuff = db.ShoeStuffs.Find(id);
            if (shoeStuff == null)
            {
                return HttpNotFound();
            }
            return View(shoeStuff);
        }

        // POST: ShoeStuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoeStuff shoeStuff = db.ShoeStuffs.Find(id);
            db.ShoeStuffs.Remove(shoeStuff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
