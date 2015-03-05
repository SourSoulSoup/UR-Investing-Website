using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UR_Investing.Models;

namespace UR_Investing.Controllers
{
    public class CarouselController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carousel
        public ActionResult Admin()
        {
            return View(db.CarouselItems.ToList());
        }

        // GET: Carousel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselItems carouselItems = db.CarouselItems.Find(id);
            if (carouselItems == null)
            {
                return HttpNotFound();
            }
            return View(carouselItems);
        }

        // GET: Carousel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carousel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,caption,filepath,rank")] CarouselItems carouselItems)
        {
            if (ModelState.IsValid)
            {
                db.CarouselItems.Add(carouselItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carouselItems);
        }

        // GET: Carousel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselItems carouselItems = db.CarouselItems.Find(id);
            if (carouselItems == null)
            {
                return HttpNotFound();
            }
            return View(carouselItems);
        }

        // POST: Carousel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,caption,filepath,rank")] CarouselItems carouselItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carouselItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carouselItems);
        }

        // GET: Carousel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselItems carouselItems = db.CarouselItems.Find(id);
            if (carouselItems == null)
            {
                return HttpNotFound();
            }
            return View(carouselItems);
        }

        // POST: Carousel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarouselItems carouselItems = db.CarouselItems.Find(id);
            db.CarouselItems.Remove(carouselItems);
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
