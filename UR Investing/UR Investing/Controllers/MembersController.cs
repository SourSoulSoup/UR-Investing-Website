﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UR_Investing.Models;

namespace UR_Investing.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Members
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.currentPage = "Members";
            var members = db.Members.Include(m => m.Position).Include(m => m.Team);
            ViewBag.Positions = db.Positions.OrderByDescending(s => s.rank).ToList();
            ViewBag.Teams = db.Teams.OrderByDescending(s => s.rank).ToList();
            return View(members.ToList());
        }

        // GET: Members/Admin
        public ActionResult Admin()
        {
            var members = db.Members.Include(m => m.Position).Include(m => m.Team);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.currentPage = "Members";
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                RedirectToAction("Index");
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                //return HttpNotFound();
                RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.positionName = new SelectList(db.Positions, "name", "name");
            ViewBag.teamName = new SelectList(db.Teams, "name", "name");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,biography,teamName,positionName")] Member member)
        {

            HttpPostedFileBase photo = Request.Files["picturePath"];

            if (ModelState.IsValid)
            {            
                if (photo != null && photo.ContentLength > 0)
                {
                    //var fileName = Path.GetFileName(photo.FileName);
                    //photo.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
                    photo.SaveAs(Path.Combine(Server.MapPath("~/Content/Files"), Path.GetFileName(photo.FileName)));
                    member.picturePath = "/Content/Files/" + Path.GetFileName(photo.FileName);
                }
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            ViewBag.positionName = new SelectList(db.Positions, "name", "name", member.positionName);
            ViewBag.teamName = new SelectList(db.Teams, "name", "name", member.teamName);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Admin");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.positionName = new SelectList(db.Positions, "name", "name", member.positionName);
            ViewBag.teamName = new SelectList(db.Teams, "name", "name", member.teamName);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,biography,teamName,positionName")] Member member)
        {
            HttpPostedFileBase photo = Request.Files["picturePath"];

            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    //Console.WriteLine("There is a photo");
                    //var fileName = Path.GetFileName(photo.FileName);
                    //photo.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
                    //member.picturePath = fileName;
                    photo.SaveAs(Path.Combine(Server.MapPath("~/Content/Files"), Path.GetFileName(photo.FileName)));
                    member.picturePath = "/Content/Files/" + Path.GetFileName(photo.FileName);
                }
               
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            ViewBag.positionName = new SelectList(db.Positions, "name", "description", member.positionName);
            ViewBag.teamName = new SelectList(db.Teams, "name", "description", member.teamName);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Admin");
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
