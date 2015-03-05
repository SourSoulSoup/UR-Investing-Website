using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UR_Investing.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Members()
        {
            return RedirectToAction("Admin", "Members");
        }

        public ActionResult Teams()
        {
            return RedirectToAction("Admin", "Teams");
        }

        public ActionResult Positions()
        {
            return RedirectToAction("Admin", "Positions");
        }

        public ActionResult A()
        {
            return RedirectToAction("Admin", "Members");
        }

        public ActionResult B()
        {
            return RedirectToAction("Admin", "Members");
        }

        public ActionResult C()
        {
            return RedirectToAction("Admin", "Members");
        }
    }
}