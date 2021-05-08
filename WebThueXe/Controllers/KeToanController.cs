using System;
using System.Collections.Generic;
using System.IO;
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
        #region Quản lý xe
        public ActionResult QuanLyXe()
        {
            return View(database.Xes.ToList());
        }

        public ActionResult ChiTietThongTinXe(int id)
        {
            return View(database.Xes.Where(s => s.maXe == id).FirstOrDefault());
        }

        public ActionResult ThemXe()
        {
            var dsTinhTrangXe = database.TinhTrangXes.ToList();
            var dsLoaiXe = database.LoaiXes.ToList();
            var dsHieuXe = database.HieuXes.ToList();
            ViewBag.DsTinhTrangXe = new SelectList(dsTinhTrangXe, "maTinhTrangXe", "tenTinhTrangXe");
            ViewBag.DsLoaiXe = new SelectList(dsLoaiXe, "maLoaiXe", "tenLoaiXe");
            ViewBag.DsHieuXe = new SelectList(dsHieuXe, "maHieuXe", "tenHieuXe");
            return View();
        }
        [HttpPost]
        public ActionResult ThemXe(Xe xe)
        {
            try
            {
                var dsTinhTrangXe = database.TinhTrangXes.ToList();
                var dsLoaiXe = database.LoaiXes.ToList();
                var dsHieuXe = database.HieuXes.ToList();
                ViewBag.DsTinhTrangXe = new SelectList(dsTinhTrangXe, "maTinhTrangXe", "tenTinhTrangXe");
                ViewBag.DsLoaiXe = new SelectList(dsLoaiXe, "maLoaiXe", "tenLoaiXe");
                ViewBag.DsHieuXe = new SelectList(dsHieuXe, "maHieuXe", "tenHieuXe");
                if (xe.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(xe.UploadImage.FileName);
                    string extent = Path.GetExtension(xe.UploadImage.FileName);
                    filename = filename + extent;
                    xe.hinh = "~/Content/images/" + filename;
                    xe.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                database.Xes.Add(xe);
                database.SaveChanges();
                return RedirectToAction("QuanLyXe");
            }
            catch
            {
                return View("ThemXe",xe);
            }
        }
        public ActionResult SuaThongTinXe(int id)
        {
            var dsTinhTrangXe = database.TinhTrangXes.ToList();
            var dsLoaiXe = database.LoaiXes.ToList();
            var dsHieuXe = database.HieuXes.ToList();
            ViewBag.DsTinhTrangXe = new SelectList(dsTinhTrangXe, "maTinhTrangXe", "tenTinhTrangXe");
            ViewBag.DsLoaiXe = new SelectList(dsLoaiXe, "maLoaiXe", "tenLoaiXe");
            ViewBag.DsHieuXe = new SelectList(dsHieuXe, "maHieuXe", "tenHieuXe");

            return View(database.Xes.Where(s => s.maXe == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult SuaThongTinXe(int id, Xe xe)
        {
            if (ModelState.IsValid)
            {
                var dsTinhTrangXe = database.TinhTrangXes.ToList();
                var dsLoaiXe = database.LoaiXes.ToList();
                var dsHieuXe = database.HieuXes.ToList();
                ViewBag.DsTinhTrangXe = new SelectList(dsTinhTrangXe, "maTinhTrangXe", "tenTinhTrangXe");
                ViewBag.DsLoaiXe = new SelectList(dsLoaiXe, "maLoaiXe", "tenLoaiXe");
                ViewBag.DsHieuXe = new SelectList(dsHieuXe, "maHieuXe", "tenHieuXe");
                database.Entry(xe).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyXe");

            }
            else
            {
                return View();
            }
        }

        public ActionResult XoaXe(int id)
        {
            return View(database.Xes.Where(s => s.maXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaXe(int id, Xe xe)
        {
            try
            {
                xe = database.Xes.Where(s => s.maXe == id).FirstOrDefault();
                database.Xes.Remove(xe);
                database.SaveChanges();
                return RedirectToAction("QuanLyXe");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        #endregion

        #region Quản lý loại xe
        public ActionResult QuanLyLoaiXe()
        {
            return View(database.LoaiXes.ToList());
        }

        public ActionResult ThemLoaiXe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemLoaiXe(LoaiXe loaiXe)
        {
            if (ModelState.IsValid)
            {
                database.LoaiXes.Add(loaiXe);
                database.SaveChanges();
                return RedirectToAction("QuanLyLoaiXe");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SuaLoaiXe(int id)
        {
            return View(database.LoaiXes.Where(s => s.maLoaiXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaLoaiXe(int id, LoaiXe loaiXe)
        {
            if (ModelState.IsValid)
            {
                database.Entry(loaiXe).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyLoaiXe");
            }
            else
            {
                return View();
            }
        }
        public ActionResult XoaLoaiXe(int id)
        {
            return View(database.LoaiXes.Where(s => s.maLoaiXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaLoaiXe(int id, LoaiXe loaiXe)
        {
            try
            {

                loaiXe = database.LoaiXes.Where(s => s.maLoaiXe == id).FirstOrDefault();
                database.LoaiXes.Remove(loaiXe);
                database.SaveChanges();
                return RedirectToAction("QuanLyLoaiXe");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        #endregion

        #region Quản lý hiệu xe
        public ActionResult QuanLyHieuXe()
        {
            return View(database.HieuXes.ToList());
        }

        public ActionResult ThemHieuXe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemHieuXe(HieuXe hieuXe)
        {
            if (ModelState.IsValid)
            {
                database.HieuXes.Add(hieuXe);
                database.SaveChanges();
                return RedirectToAction("QuanLyHieuXe");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SuaHieuXe(int id)
        {
            return View(database.HieuXes.Where(s => s.maHieuXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaHieuXe(int id, HieuXe hieuXe)
        {
            if (ModelState.IsValid)
            {
                database.Entry(hieuXe).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyHieuXe");
            }
            else
            {
                return View();
            }
        }
        public ActionResult XoaHieuXe(int id)
        {
            return View(database.HieuXes.Where(s => s.maHieuXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaHieuXe(int id, HieuXe hieuXe)
        {
            try
            {

                hieuXe = database.HieuXes.Where(s => s.maHieuXe == id).FirstOrDefault();
                database.HieuXes.Remove(hieuXe);
                database.SaveChanges();
                return RedirectToAction("QuanLyHieuXe");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        #endregion

    }
}