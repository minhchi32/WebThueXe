﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThueXe.Models;

namespace WebThueXe.Controllers
{
    public class UserController : Controller
    {
        DBCarRentalEntities database = new DBCarRentalEntities();
        public NguoiDung GetCurrentUser()
        {
            NguoiDung currentUser = (NguoiDung)Session["NguoiDung"];
            return currentUser;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NguoiDung _user)
        {
            var check = database.NguoiDungs.Where(s => s.username == _user.username && s.password == _user.password).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai Info";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["NguoiDung"] = check;
                Session["ten"] = check.ten;
                Session["maQuyen"] = check.maQuyen;
                Session["id"] = check.maNguoiDung;
                ViewBag.ten = check.ten;
                switch (check.maQuyen)
                {
                    case 1:
                        return RedirectToAction("Index", "Admin");
                    case 3:
                        return RedirectToAction("Index", "GiamDoc");
                    case 4:
                        return RedirectToAction("Index", "KeToan");
                    default:
                        return RedirectToAction("Index", "TrangChu");
                }
            }
        }
        public ActionResult DanhSachDatXe()
        {
            NguoiDung nguoiDung = (NguoiDung)Session["NguoiDung"];
            if (Session["NguoiDung"] != null)
            {
                return View(database.HopDongs.Where(s => s.maNguoiDung == nguoiDung.maNguoiDung).ToList());
            }
            else
            {
                return RedirectToAction("Index", "User");

            }
        }
        public ActionResult Register()
        {
            var dsNganHang = database.NganHangs.ToList();
            ViewBag.DsNganHang = new SelectList(dsNganHang, "maNganHang", "tenNganHang");
            return View();
        }
        [HttpPost]
        public ActionResult Register(NguoiDung _user)
        {
            var dsNganHang = database.NganHangs.ToList();
            ViewBag.DsNganHang= new SelectList(dsNganHang, "maNganHang", "tenNganHang");
            _user.maQuyen = 2;
            _user.ngayThamGia = DateTime.Now;
            _user.ten = "";
            _user.SDT = "";
            _user.diaChi = "";
            _user.hoKhau = "";
            _user.CMND = "";
            var check_ID = database.NguoiDungs.Where(s => s.username == _user.username).FirstOrDefault();
            if (_user.maNganHang == 0)
            {
                ViewBag.nganHang = "Chọn loại ngân hàng";
                return View();
            }
            if (check_ID != null)
            {
                ViewBag.ErrorRegister = "This nameuser is exist";
                return View();
            }
            if (ModelState.IsValid)
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                database.NguoiDungs.Add(_user);
                database.SaveChanges();
                return RedirectToAction("Index", "User");
                
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "TrangChu");
        }
        public ActionResult XemThongTinCaNhan(int id)
        {
            return View(database.NguoiDungs.Where(s => s.maNguoiDung == id).FirstOrDefault());
        }
    }
}