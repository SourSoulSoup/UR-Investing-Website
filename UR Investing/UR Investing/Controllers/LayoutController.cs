using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UR_Investing.Controllers
{
    public class LayoutController : Controller
    {
        public ActionResult MemberList()
        {
            return PartialView("~/Views/Shared/_MemberList.cshtml");
        }
    }
}