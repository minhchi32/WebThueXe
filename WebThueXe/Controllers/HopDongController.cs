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
        public ActionResult DanhSachHopDong()
        {
            return View(db.HopDongs.ToList());
        }
        public ActionResult ThemHopDong()
        {
            return View();
        }
        public ActionResult LapThongTinHopDong()
        {
            return View();
        }
    }
}