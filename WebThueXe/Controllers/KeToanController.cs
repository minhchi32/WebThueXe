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
        #region Quản lý xe
        public ActionResult QuanLyXe()
        {
            return View(database.Xes.ToList());
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
            try
            {
                database.LoaiXes.Add(loaiXe);
                database.SaveChanges();
                return RedirectToAction("QuanLyLoaiXe");
            }
            catch
            {
                return Content("lỗi thêm mới");
            }
        }
        public ActionResult SuaLoaiXe(int id)
        {
            return View(database.LoaiXes.Where(s => s.maLoaiXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaLoaiXe(int id, LoaiXe loaiXe)
        {
            try
            {
                database.Entry(loaiXe).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyLoaiXe");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
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
            try
            {
                database.HieuXes.Add(hieuXe);
                database.SaveChanges();
                return RedirectToAction("QuanLyHieuXe");
            }
            catch
            {
                return Content("lỗi thêm mới");
            }
        }
        public ActionResult SuaHieuXe(int id)
        {
            return View(database.HieuXes.Where(s => s.maHieuXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaHieuXe(int id, HieuXe hieuXe)
        {
            try
            {
                database.Entry(hieuXe).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyHieuXe");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
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