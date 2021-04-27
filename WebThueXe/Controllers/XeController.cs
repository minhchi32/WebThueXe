using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThueXe.Models;

namespace WebThueXe.Controllers
{
    public class XeController : Controller
    {
        DBCarRentalEntities database = new DBCarRentalEntities();
        // GET: Xe
        public ActionResult Index()
        {
            return View(database.Xes.ToList());
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