using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThueXe.Models;

namespace WebThueXe.Controllers
{
    public class HopDongController : Controller
    {
        DBCarRentalEntities db = new DBCarRentalEntities();
        // GET: HopDong
        public ActionResult Index()
        {
            return View(db.HopDongs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create_Detail()
        {
            return View();
        }
    }
}