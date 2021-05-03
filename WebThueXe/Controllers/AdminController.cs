﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThueXe.Models;

namespace WebThueXe.Controllers
{
    public class AdminController : Controller
    {
        DBCarRentalEntities database = new DBCarRentalEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        #region Quản lý người dùng
        public ActionResult QuanLyNguoiDung()
        {
            return View(database.NguoiDungs.ToList());
        }

        public ActionResult ThemNguoiDung()
        {
            var dsNganHang = database.NganHangs.ToList();
            var dsQuyen = database.Quyens.ToList();
            ViewBag.DsNganHang = new SelectList(dsNganHang, "maNganHang", "tenNganHang");
            ViewBag.DsQuyen = new SelectList(dsQuyen, "maQuyen", "tenQuyen");
            return View();
        }
        [HttpPost]
        public ActionResult ThemNguoiDung(NguoiDung nguoiDung)
        {
            try
            {
                var dsNganHang = database.NganHangs.ToList();
                var dsQuyen = database.Quyens.ToList();
                ViewBag.DsNganHang = new SelectList(dsNganHang, "maNganHang", "tenNganHang");
                ViewBag.DsQuyen = new SelectList(dsQuyen, "maQuyen", "tenQuyen");
                database.NguoiDungs.Add(nguoiDung);
                database.SaveChanges();
                return RedirectToAction("QuanLyNguoiDung");
            }
            catch
            {
                return Content("lỗi thêm mới");
            }
        }
        public ActionResult SuaThongTinNguoiDung(int id)
        {
            var dsNganHang = database.NganHangs.ToList();
            var dsQuyen = database.Quyens.ToList();
            ViewBag.DsNganHang = new SelectList(dsNganHang, "maNganHang", "tenNganHang");
            ViewBag.DsQuyen = new SelectList(dsQuyen, "maQuyen", "tenQuyen");
            return View(database.NguoiDungs.Where(s => s.maNguoiDung == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaThongTinNguoiDung(int id, NguoiDung nguoiDung)
        {
            try
            {
                var dsNganHang = database.NganHangs.ToList();
                var dsQuyen = database.Quyens.ToList();
                ViewBag.DsNganHang = new SelectList(dsNganHang, "maNganHang", "tenNganHang");
                ViewBag.DsQuyen = new SelectList(dsQuyen, "maQuyen", "tenQuyen");
                database.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyNguoiDung");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        public ActionResult ChiTietThongTinNguoiDung(int id)
        {
            return View(database.NguoiDungs.Where(s => s.maNguoiDung == id).FirstOrDefault());
        }
        public ActionResult XoaNguoiDung(int id)
        {
            return View(database.NguoiDungs.Where(s => s.maNguoiDung == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaNguoiDung(int id, NguoiDung nguoiDung)
        {
            try
            {

                nguoiDung = database.NguoiDungs.Where(s => s.maNguoiDung == id).FirstOrDefault();
                database.NguoiDungs.Remove(nguoiDung);
                database.SaveChanges();
                return RedirectToAction("QuanLyNguoiDung");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        #endregion

        #region Quản lý phân quyền
        public ActionResult QuanLyPhanQuyen()
        {
            return View(database.Quyens.ToList());
        }

        public ActionResult ThemPhanQuyen()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemPhanQuyen(Quyen quyen)
        {
            try
            {
                database.Quyens.Add(quyen);
                database.SaveChanges();
                return RedirectToAction("QuanLyPhanQuyen");
            }
            catch
            {
                return Content("lỗi thêm mới");
            }
        }
        public ActionResult SuaPhanQuyen(int id)
        {
            return View(database.Quyens.Where(s => s.maQuyen == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaPhanQuyen(int id, Quyen quyen)
        {
            try
            {
                database.Entry(quyen).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyPhanQuyen");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        public ActionResult XoaPhanQuyen(int id)
        {
            return View(database.Quyens.Where(s => s.maQuyen == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaPhanQuyen(int id, Quyen quyen)
        {
            try
            {

                quyen = database.Quyens.Where(s => s.maQuyen == id).FirstOrDefault();
                database.Quyens.Remove(quyen);
                database.SaveChanges();
                return RedirectToAction("QuanLyPhanQuyen");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        #endregion
    }
}