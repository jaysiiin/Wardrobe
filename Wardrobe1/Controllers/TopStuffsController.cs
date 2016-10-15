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
    public class TopStuffsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: TopStuffs
        public ActionResult Index()
        {
            return View(db.TopStuffs.ToList());
        }

        // GET: TopStuffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopStuff topStuff = db.TopStuffs.Find(id);
            if (topStuff == null)
            {
                return HttpNotFound();
            }
            return View(topStuff);
        }

        // GET: TopStuffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopStuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopsID,Name,Photo,Type,Color,Season,Occasion")] TopStuff topStuff)
        {
            if (ModelState.IsValid)
            {
                db.TopStuffs.Add(topStuff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topStuff);
        }

        // GET: TopStuffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopStuff topStuff = db.TopStuffs.Find(id);
            if (topStuff == null)
            {
                return HttpNotFound();
            }
            return View(topStuff);
        }

        // POST: TopStuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopsID,Name,Photo,Type,Color,Season,Occasion")] TopStuff topStuff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topStuff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topStuff);
        }

        // GET: TopStuffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopStuff topStuff = db.TopStuffs.Find(id);
            if (topStuff == null)
            {
                return HttpNotFound();
            }
            return View(topStuff);
        }

        // POST: TopStuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopStuff topStuff = db.TopStuffs.Find(id);
            db.TopStuffs.Remove(topStuff);
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
