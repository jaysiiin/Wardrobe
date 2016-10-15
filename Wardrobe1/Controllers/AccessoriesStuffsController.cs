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
    public class AccessoriesStuffsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: AccessoriesStuffs
        public ActionResult Index()
        {
            return View(db.AccessoriesStuffs.ToList());
        }

        // GET: AccessoriesStuffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoriesStuff accessoriesStuff = db.AccessoriesStuffs.Find(id);
            if (accessoriesStuff == null)
            {
                return HttpNotFound();
            }
            return View(accessoriesStuff);
        }

        // GET: AccessoriesStuffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessoriesStuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoriesID,Name,Photo,Type,Color,Season,Occasion")] AccessoriesStuff accessoriesStuff)
        {
            if (ModelState.IsValid)
            {
                db.AccessoriesStuffs.Add(accessoriesStuff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessoriesStuff);
        }

        // GET: AccessoriesStuffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoriesStuff accessoriesStuff = db.AccessoriesStuffs.Find(id);
            if (accessoriesStuff == null)
            {
                return HttpNotFound();
            }
            return View(accessoriesStuff);
        }

        // POST: AccessoriesStuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoriesID,Name,Photo,Type,Color,Season,Occasion")] AccessoriesStuff accessoriesStuff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoriesStuff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessoriesStuff);
        }

        // GET: AccessoriesStuffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoriesStuff accessoriesStuff = db.AccessoriesStuffs.Find(id);
            if (accessoriesStuff == null)
            {
                return HttpNotFound();
            }
            return View(accessoriesStuff);
        }

        // POST: AccessoriesStuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessoriesStuff accessoriesStuff = db.AccessoriesStuffs.Find(id);
            db.AccessoriesStuffs.Remove(accessoriesStuff);
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
