using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThueXe.Controllers
{
    public class XeController : Controller
    {
        // GET: Xe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChiTietXe(int id=0)
        {
            return View();
        }
        public ActionResult HopDongThueXe()
        {
            return View();
        }
    }
}