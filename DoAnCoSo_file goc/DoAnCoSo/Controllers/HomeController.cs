using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoSo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Start()
        {
            return View();
        }
        public ActionResult ThongKe()
        {
            return View();
        }
        public ActionResult TimKiem()
        {
            return View();
        }
    }
}