using System;
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
                Session["ten"] = check.ten;
                Session["maQuyen"] = _user.maQuyen;
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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(NguoiDung _user)
        {
            if (ModelState.IsValid)
            {
                var check_ID = database.NguoiDungs.Where(s => s.username == _user.username).FirstOrDefault();
                if (check_ID == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.NguoiDungs.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "This nameuser is exist";
                    return View();
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "TrangChu");
        }
    }
}