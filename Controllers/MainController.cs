using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace staj2.Controllers
{
    public class MainController : Controller
    {
        // GET: Anasayfa
        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}