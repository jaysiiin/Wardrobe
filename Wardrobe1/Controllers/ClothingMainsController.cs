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
    public class ClothingMainsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: ClothingMains
        public ActionResult Index()
        {
            var clothingMains = db.ClothingMains.Include(c => c.AccessoriesStuff).Include(c => c.BottomStuff).Include(c => c.ShoeStuff).Include(c => c.TopStuff);
            return View(clothingMains.ToList());
        }

        // GET: ClothingMains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingMain clothingMain = db.ClothingMains.Find(id);
            if (clothingMain == null)
            {
                return HttpNotFound();
            }
            return View(clothingMain);
        }

        // GET: ClothingMains/Create
        public ActionResult Create()
        {
            ViewBag.AccessoriesID = new SelectList(db.AccessoriesStuffs, "AccessoriesID", "Name");
            ViewBag.BottomsID = new SelectList(db.BottomStuffs, "BottomID", "Name");
            ViewBag.ShoesID = new SelectList(db.ShoeStuffs, "ShoeID", "Name");
            ViewBag.TopsID = new SelectList(db.TopStuffs, "TopsID", "Name");
            return View();
        }

        // POST: ClothingMains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClothingID,TopsID,BottomsID,ShoesID,AccessoriesID")] ClothingMain clothingMain)
        {
            if (ModelState.IsValid)
            {
                db.ClothingMains.Add(clothingMain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoriesID = new SelectList(db.AccessoriesStuffs, "AccessoriesID", "Name", clothingMain.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.BottomStuffs, "BottomID", "Name", clothingMain.BottomsID);
            ViewBag.ShoesID = new SelectList(db.ShoeStuffs, "ShoeID", "Name", clothingMain.ShoesID);
            ViewBag.TopsID = new SelectList(db.TopStuffs, "TopsID", "Name", clothingMain.TopsID);
            return View(clothingMain);
        }

        // GET: ClothingMains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingMain clothingMain = db.ClothingMains.Find(id);
            if (clothingMain == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoriesID = new SelectList(db.AccessoriesStuffs, "AccessoriesID", "Name", clothingMain.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.BottomStuffs, "BottomID", "Name", clothingMain.BottomsID);
            ViewBag.ShoesID = new SelectList(db.ShoeStuffs, "ShoeID", "Name", clothingMain.ShoesID);
            ViewBag.TopsID = new SelectList(db.TopStuffs, "TopsID", "Name", clothingMain.TopsID);
            return View(clothingMain);
        }

        // POST: ClothingMains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClothingID,TopsID,BottomsID,ShoesID,AccessoriesID")] ClothingMain clothingMain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothingMain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoriesID = new SelectList(db.AccessoriesStuffs, "AccessoriesID", "Name", clothingMain.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.BottomStuffs, "BottomID", "Name", clothingMain.BottomsID);
            ViewBag.ShoesID = new SelectList(db.ShoeStuffs, "ShoeID", "Name", clothingMain.ShoesID);
            ViewBag.TopsID = new SelectList(db.TopStuffs, "TopsID", "Name", clothingMain.TopsID);
            return View(clothingMain);
        }

        // GET: ClothingMains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingMain clothingMain = db.ClothingMains.Find(id);
            if (clothingMain == null)
            {
                return HttpNotFound();
            }
            return View(clothingMain);
        }

        // POST: ClothingMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClothingMain clothingMain = db.ClothingMains.Find(id);
            db.ClothingMains.Remove(clothingMain);
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
