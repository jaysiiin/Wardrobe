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
    public class BottomStuffsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: BottomStuffs
        public ActionResult Index()
        {
            return View(db.BottomStuffs.ToList());
        }

        // GET: BottomStuffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomStuff bottomStuff = db.BottomStuffs.Find(id);
            if (bottomStuff == null)
            {
                return HttpNotFound();
            }
            return View(bottomStuff);
        }

        // GET: BottomStuffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BottomStuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BottomID,Name,Photo,Type,Color,Season,Occasion")] BottomStuff bottomStuff)
        {
            if (ModelState.IsValid)
            {
                db.BottomStuffs.Add(bottomStuff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bottomStuff);
        }

        // GET: BottomStuffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomStuff bottomStuff = db.BottomStuffs.Find(id);
            if (bottomStuff == null)
            {
                return HttpNotFound();
            }
            return View(bottomStuff);
        }

        // POST: BottomStuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BottomID,Name,Photo,Type,Color,Season,Occasion")] BottomStuff bottomStuff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottomStuff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottomStuff);
        }

        // GET: BottomStuffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomStuff bottomStuff = db.BottomStuffs.Find(id);
            if (bottomStuff == null)
            {
                return HttpNotFound();
            }
            return View(bottomStuff);
        }

        // POST: BottomStuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BottomStuff bottomStuff = db.BottomStuffs.Find(id);
            db.BottomStuffs.Remove(bottomStuff);
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
