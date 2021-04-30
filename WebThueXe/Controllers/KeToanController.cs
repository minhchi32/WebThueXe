using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThueXe.Models;

namespace WebThueXe.Controllers
{
    public class KeToanController : Controller
    {
        DBCarRentalEntities database = new DBCarRentalEntities();
        // GET: KeToan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QuanLyXe()
        {
            return View(database.Xes.ToList());
        }
    }
}