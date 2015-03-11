using System;
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
    public class LayoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult MemberList()
        {
            ViewBag.Teams = db.Teams.OrderByDescending(r => r.rank).ToList();

            var members = db.Members.Include(m => m.Position).Include(m => m.Team).OrderByDescending(m => m.Team.rank);
            return PartialView("~/Views/Shared/_MemberList.cshtml", members.ToList());
        }
    }
}