using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebThueXe.Models;
using PagedList;
using PagedList.Mvc;

namespace WebThueXe.Controllers
{
    public class XeController : Controller
    {
        DBCarRentalEntities database = new DBCarRentalEntities();
        // GET: Xe
        public ActionResult Index(int? page, double max = int.MaxValue, double min = int.MinValue, int loaiXe = 0, int hieuXe = 0)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var result = database.Xes.Where(s => s.maTinhTrangXe == 1 && (double)s.giaThueXe <= max && (double)s.giaThueXe >= min).ToList();
            if (loaiXe != 0)
                result = result.Where(s => s.maLoaiXe == loaiXe).ToList();
            if (hieuXe != 0)
                result = result.Where(s => s.maHieuXe == hieuXe).ToList();
            return View(result.ToPagedList(pageNum, pageSize));
        }
        public ActionResult ChiTietXe(int id)
        {
            return View(database.Xes.Where(s => s.maXe == id).FirstOrDefault());
        }
        public JsonResult LoadImages(int id)
        {
            var xe = database.Xes.Find(id);
            var images = xe.hinhplus;
            if (images != null)
            {
                XElement xImages = XElement.Parse(images);
                List<string> listImages = new List<string>();
                foreach (XElement element in xImages.Elements())
                {
                    listImages.Add(element.Value);
                }
                return Json(new
                {
                    data = listImages
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    data = ""
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult HopDongThueXe(int maXe, string tenXe, DateTime ngayThue, DateTime ngayTra, int soNgayThue, int tongTien, int donGia,string returnUrl)
        {
            int count = database.HopDongs.Count();
            if (Session["NguoiDung"] != null)
            {
                HopDong hopDong = new HopDong
                {
                    tenXe = tenXe,
                    maHopDong = count + 1,
                    maXe = maXe,
                    soNgayThue = soNgayThue,
                    ngayLapHopDong = DateTime.Now,
                    ngayThue = ngayThue,
                    ngayTra = ngayTra,
                    TongTien = tongTien,
                    donGia = donGia,
                };

                ViewData["myHopDong"] = hopDong;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User",new {returnUrl=returnUrl });
            }
        }
        public ActionResult DatXe(int maXe, int maNguoiDung, string hotenNguoiDatXe, string email, int SDT, string ghiChu, DateTime ngayThue, DateTime ngayTra, int soNgayThue, string diaChiNhanXe, int maPhuongThucThanhToan, int tongTien)
        {
            HopDong hopDong = new HopDong
            {
                maNguoiDung = maNguoiDung,
                hotenNguoiDatXe = hotenNguoiDatXe,
                email = email,
                SDT = SDT,
                ghiChu = ghiChu,
                diaChiNhanXe = diaChiNhanXe,
                maXe = maXe,
                soNgayThue = soNgayThue,
                ngayLapHopDong = DateTime.Now,
                ngayThue = ngayThue,
                ngayTra = ngayTra,
                daThanhToan = false,
                daDuyet = false,
                yeuCauHuyDon = false,
                TongTien = tongTien,
                maTinhTrangHopDong = 2,
                maPhuongThucThanhToan = maPhuongThucThanhToan
            };
            database.HopDongs.Add(hopDong);
            var xe = database.Xes.Find(maXe);
            xe.maTinhTrangXe = 2;
            database.SaveChanges();
            ViewBag.hopdongid = hopDong.maHopDong;
            return View(database.PhuongThucThanhToans.Where(s => s.maPhuongThucThanhToan == maPhuongThucThanhToan).FirstOrDefault());
        }
        public ActionResult Search()
        {
            if (ModelState.IsValid)
            {
                var dsLoaiXe = database.LoaiXes.ToList();
                var dsHieuXe = database.HieuXes.ToList();
                ViewBag.DsLoaiXe = new SelectList(dsLoaiXe, "maLoaiXe", "tenLoaiXe");
                ViewBag.DsHieuXe = new SelectList(dsHieuXe, "maHieuXe", "tenHieuXe");
                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult LoadBrand()
        {
            var brands = database.HieuXes.ToList();
            List<Brand> listBrand = new List<Brand>();
            Brand tmp = null;
            foreach (var item in brands)
            {
                tmp = new Brand();
                tmp.maHieuXe = item.maHieuXe;
                tmp.tenHieuXe = item.tenHieuXe;
                listBrand.Add(tmp);
            }
            return Json(new
            {
                data = listBrand,
                status = true
            });
        }
        public ActionResult LoadType()
        {
            var types = database.LoaiXes.ToList();
            List<Types> listTypes = new List<Types>();
            Types tmp = null;
            foreach (var item in types)
            {
                tmp = new Types();
                tmp.maLoaiXe = item.maLoaiXe;
                tmp.tenLoaiXe = item.tenLoaiXe;
                listTypes.Add(tmp);
            }
            return Json(new
            {
                data = listTypes,
                status = true
            });

        }
    }
}