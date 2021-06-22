using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThueXe.Models;
using PagedList;
using PagedList.Mvc;

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
        public ActionResult QuanLyNguoiDung(int? page, string ten, int maQuyen = 0)
        {
            List<Quyen> list = database.Quyens.ToList();
            ViewBag.listQuyen = new SelectList(list, "maQuyen", "tenQuyen");
            int pageSize = 20;
            int pageNum = (page ?? 1);
            var result = database.NguoiDungs.ToList();
            
            

            if (ten != null)
            {
                ViewBag.ten = ten;
                result = result.Where(s => s.ten.Contains(ten)).ToList();
            }
            else
            {
                ViewBag.ten = "";
            }
            if (maQuyen==0)
            {
                ViewBag.maquyen = "";
            }
            else ViewBag.maquyen = maQuyen;
            if (maQuyen != 0)
            {
                result = result.Where(s => s.maQuyen == maQuyen).ToList();
            }
            return View(result.ToPagedList(pageNum, pageSize));
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
                nguoiDung.ConfirmPass = nguoiDung.password;
                nguoiDung.ngayThamGia = DateTime.Now;
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
                nguoiDung.ConfirmPass = nguoiDung.password;
                database.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyNguoiDung", "Admin");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                return Content(raise.ToString());
                //throw raise;
            }
            //catch (Exception e)
            //{
            //    return Content(e.ToString());
            //}
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
            if (ModelState.IsValid)
            {
                database.Quyens.Add(quyen);
                database.SaveChanges();
                return RedirectToAction("QuanLyPhanQuyen");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SuaPhanQuyen(int id)
        {
            return View(database.Quyens.Where(s => s.maQuyen == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaPhanQuyen(int id, Quyen quyen)
        {
            if (ModelState.IsValid)
            {
                database.Entry(quyen).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyPhanQuyen");
            }
            else
            {
                return View();
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
        public JsonResult SelectQuyen()
        {
            var quyens = database.Quyens.ToList();
            List<Quyens> listQuyens = new List<Quyens>();
            Quyens tmp = null;
            foreach (var item in quyens)
            {
                tmp = new Quyens();
                tmp.maQuyen = item.maQuyen;
                tmp.tenQuyen = item.tenQuyen;
                listQuyens.Add(tmp);
            }
            return Json(new
            {
                data = listQuyens,
                status = true
            });
        }
        #endregion
    }
}