using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamsSystemV1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult AdminHome()
        {
            return View();
        }
    }
}