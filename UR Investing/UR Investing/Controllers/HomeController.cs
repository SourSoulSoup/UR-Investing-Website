using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UR_Investing.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.currentPage = "Home";
            return View();
        }

        public ActionResult Photo()
        {
            ViewBag.currentPage = "Photo";
            ViewBag.path = Server.MapPath("~/Images");
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {

            HttpPostedFileBase photo = Request.Files["photo"];
            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
            }

            return RedirectToAction("Photo");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}