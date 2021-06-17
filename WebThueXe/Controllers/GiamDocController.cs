using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThueXe.Models;

namespace WebThueXe.Controllers
{
    public class GiamDocController : Controller
    {
        DBCarRentalEntities database = new DBCarRentalEntities();

        // GET: GiamDoc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BaoCaoHopDong(int? page,int month=0,int year=0,int daThanhToan=2)
        {
            int pageSize = 20;
            int pageNum = (page ?? 1);
            if (month == 0)
                month = DateTime.Now.Month;
            if (year == 0)
                year = DateTime.Now.Year;
            List<Xe> listXe = database.Xes.ToList();
            List<PhuongThucThanhToan> phuongThucThanhToans = database.PhuongThucThanhToans.ToList();
            List<HopDong> listHopDong = database.HopDongs.ToList();
            if(daThanhToan==0)
            {
                var hopDong = from _hopDong in listHopDong
                              join _xe in listXe on _hopDong.maXe equals _xe.maXe
                              join _phuongThucThanhToan in phuongThucThanhToans on _hopDong.maPhuongThucThanhToan equals _phuongThucThanhToan.maPhuongThucThanhToan
                              where _hopDong.ngayLapHopDong.Year == year && _hopDong.ngayLapHopDong.Month == month && _hopDong.daThanhToan == true
                              select new HopDong
                              {
                                  maHopDong = _hopDong.maHopDong,
                                  maNguoiDung = _hopDong.maNguoiDung,
                                  hotenNguoiDatXe = _hopDong.hotenNguoiDatXe,
                                  email = _hopDong.email,
                                  SDT = _hopDong.SDT,
                                  ghiChu = _hopDong.ghiChu,
                                  maXe = _hopDong.maXe,
                                  soNgayThue = _hopDong.soNgayThue,
                                  ngayLapHopDong = _hopDong.ngayLapHopDong,
                                  ngayThue = _hopDong.ngayThue,
                                  ngayTra = _hopDong.ngayTra,
                                  diaChiNhanXe = _hopDong.diaChiNhanXe,
                                  TongTien = _hopDong.TongTien,
                                  daThanhToan = _hopDong.daThanhToan,
                                  daDuyet = _hopDong.daDuyet,
                                  yeuCauHuyDon = _hopDong.yeuCauHuyDon,
                                  maTinhTrangHopDong = _hopDong.maTinhTrangHopDong,
                                  maPhuongThucThanhToan = _hopDong.maPhuongThucThanhToan,
                                  donGia = _xe.giaThueXe,
                                  tenXe = _xe.tenXe,
                                  tenLoaiThanhToan = _phuongThucThanhToan.tenPhuongThucThanhToan,
                              };
                double tongDoanhThu = 0;
                foreach (var item in hopDong)
                {
                    tongDoanhThu += item.TongTien;
                }
                ViewBag.TongDoanhThu = tongDoanhThu;

                ViewData["month"] = month;
                ViewData["year"] = year;
                ViewData["daThanhToan"] = daThanhToan;
                return View(hopDong.ToPagedList(pageNum, pageSize));
            }
            else if (daThanhToan == 1)
            {
                var hopDong = from _hopDong in listHopDong
                              join _xe in listXe on _hopDong.maXe equals _xe.maXe
                              join _phuongThucThanhToan in phuongThucThanhToans on _hopDong.maPhuongThucThanhToan equals _phuongThucThanhToan.maPhuongThucThanhToan
                              where _hopDong.ngayLapHopDong.Year == year && _hopDong.ngayLapHopDong.Month == month && _hopDong.daThanhToan == false
                              select new HopDong
                              {
                                  maHopDong = _hopDong.maHopDong,
                                  maNguoiDung = _hopDong.maNguoiDung,
                                  hotenNguoiDatXe = _hopDong.hotenNguoiDatXe,
                                  email = _hopDong.email,
                                  SDT = _hopDong.SDT,
                                  ghiChu = _hopDong.ghiChu,
                                  maXe = _hopDong.maXe,
                                  soNgayThue = _hopDong.soNgayThue,
                                  ngayLapHopDong = _hopDong.ngayLapHopDong,
                                  ngayThue = _hopDong.ngayThue,
                                  ngayTra = _hopDong.ngayTra,
                                  diaChiNhanXe = _hopDong.diaChiNhanXe,
                                  TongTien = _hopDong.TongTien,
                                  daThanhToan = _hopDong.daThanhToan,
                                  daDuyet = _hopDong.daDuyet,
                                  yeuCauHuyDon = _hopDong.yeuCauHuyDon,
                                  maTinhTrangHopDong = _hopDong.maTinhTrangHopDong,
                                  maPhuongThucThanhToan = _hopDong.maPhuongThucThanhToan,
                                  donGia = _xe.giaThueXe,
                                  tenXe = _xe.tenXe,
                                  tenLoaiThanhToan = _phuongThucThanhToan.tenPhuongThucThanhToan,
                              };
                double tongDoanhThu = 0;
                foreach (var item in hopDong)
                {
                    tongDoanhThu += item.TongTien;
                }
                ViewBag.TongDoanhThu = tongDoanhThu;

                ViewData["month"] = month;
                ViewData["year"] = year;
                ViewData["daThanhToan"] = daThanhToan;
                return View(hopDong.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var hopDong = from _hopDong in listHopDong
                              join _xe in listXe on _hopDong.maXe equals _xe.maXe
                              join _phuongThucThanhToan in phuongThucThanhToans on _hopDong.maPhuongThucThanhToan equals _phuongThucThanhToan.maPhuongThucThanhToan
                              where _hopDong.ngayLapHopDong.Year == year && _hopDong.ngayLapHopDong.Month == month
                              select new HopDong
                              {
                                  maHopDong = _hopDong.maHopDong,
                                  maNguoiDung = _hopDong.maNguoiDung,
                                  hotenNguoiDatXe = _hopDong.hotenNguoiDatXe,
                                  email = _hopDong.email,
                                  SDT = _hopDong.SDT,
                                  ghiChu = _hopDong.ghiChu,
                                  maXe = _hopDong.maXe,
                                  soNgayThue = _hopDong.soNgayThue,
                                  ngayLapHopDong = _hopDong.ngayLapHopDong,
                                  ngayThue = _hopDong.ngayThue,
                                  ngayTra = _hopDong.ngayTra,
                                  diaChiNhanXe = _hopDong.diaChiNhanXe,
                                  TongTien = _hopDong.TongTien,
                                  daThanhToan = _hopDong.daThanhToan,
                                  daDuyet = _hopDong.daDuyet,
                                  yeuCauHuyDon = _hopDong.yeuCauHuyDon,
                                  maTinhTrangHopDong = _hopDong.maTinhTrangHopDong,
                                  maPhuongThucThanhToan = _hopDong.maPhuongThucThanhToan,
                                  donGia = _xe.giaThueXe,
                                  tenXe = _xe.tenXe,
                                  tenLoaiThanhToan = _phuongThucThanhToan.tenPhuongThucThanhToan,
                              };
                double tongDoanhThu = 0;
                foreach (var item in hopDong)
                {
                    tongDoanhThu += item.TongTien;
                }
                ViewBag.TongDoanhThu = tongDoanhThu;
                ViewData["month"] = month;
                ViewData["year"] = year;
                ViewData["daThanhToan"] = daThanhToan;
                return View(hopDong.ToPagedList(pageNum, pageSize));
            }
            
            
        }
        public ActionResult BaoCaoDoanhThu(int? page, int month=0, int year=0)
        {
            int pageSize = 20;
            int pageNum = (page ?? 1);
            if (month == 0)
                month = DateTime.Now.Month;
            if (year == 0)
                year = DateTime.Now.Year;
            List<Xe> listXe = database.Xes.ToList();
            List<PhuongThucThanhToan> phuongThucThanhToans = database.PhuongThucThanhToans.ToList();
            List<HopDong> listHopDong = database.HopDongs.ToList();
            
            var hopDong = from _hopDong in listHopDong
                            join _xe in listXe on _hopDong.maXe equals _xe.maXe
                            join _phuongThucThanhToan in phuongThucThanhToans on _hopDong.maPhuongThucThanhToan equals _phuongThucThanhToan.maPhuongThucThanhToan
                            where _hopDong.ngayLapHopDong.Year == year && _hopDong.ngayLapHopDong.Month == month && _hopDong.daThanhToan == true
                            select new HopDong
                            {
                                maHopDong = _hopDong.maHopDong,
                                maNguoiDung = _hopDong.maNguoiDung,
                                hotenNguoiDatXe = _hopDong.hotenNguoiDatXe,
                                email = _hopDong.email,
                                SDT = _hopDong.SDT,
                                ghiChu = _hopDong.ghiChu,
                                maXe = _hopDong.maXe,
                                soNgayThue = _hopDong.soNgayThue,
                                ngayLapHopDong = _hopDong.ngayLapHopDong,
                                ngayThue = _hopDong.ngayThue,
                                ngayTra = _hopDong.ngayTra,
                                diaChiNhanXe = _hopDong.diaChiNhanXe,
                                TongTien = _hopDong.TongTien,
                                daThanhToan = _hopDong.daThanhToan,
                                daDuyet = _hopDong.daDuyet,
                                yeuCauHuyDon = _hopDong.yeuCauHuyDon,
                                maTinhTrangHopDong = _hopDong.maTinhTrangHopDong,
                                maPhuongThucThanhToan = _hopDong.maPhuongThucThanhToan,
                                donGia = _xe.giaThueXe,
                                tenXe = _xe.tenXe,
                                tenLoaiThanhToan = _phuongThucThanhToan.tenPhuongThucThanhToan,
                            };
            double tongDoanhThu = 0;
            foreach (var item in hopDong)
            {
                tongDoanhThu += item.TongTien;
            }
            ViewBag.TongDoanhThu = tongDoanhThu;

            ViewData["month"] = month;
            ViewData["year"] = year;
            return View(hopDong.ToPagedList(pageNum, pageSize));

        }
        public ActionResult BaoCaoXe(int? page, string sortOrder, int month = 0, int year = 0)
        {
            ViewBag.Sort = sortOrder == "Count" ? "countdesc" : "Count";

            int pageSize = 30;
            int pageNum = (page ?? 1);

            if (month == 0)
                month = DateTime.Now.Month;
            if (year == 0)
                year = DateTime.Now.Year;
            List<Xe> listXe = database.Xes.ToList();
            
            List<HopDong> listHopDong = database.HopDongs.ToList();

            var xe = (from _xe in listXe
                      select new Xe
                      {
                          maXe = _xe.maXe,
                          tenXe = _xe.tenXe,
                          bienSo = _xe.bienSo,
                          giaXe = _xe.giaXe,
                          moTaXe = _xe.moTaXe,
                          maTinhTrangXe = _xe.maTinhTrangXe,
                          giaThueXe = _xe.giaThueXe,
                          maLoaiXe = _xe.maLoaiXe,
                          maHieuXe = _xe.maHieuXe,
                          hinh = _xe.hinh,
                          hinhplus = _xe.hinhplus,
                          LoaiXe = database.LoaiXes.Where(s => s.maLoaiXe == _xe.maLoaiXe).FirstOrDefault(),
                          HieuXe = database.HieuXes.Where(s => s.maHieuXe == _xe.maHieuXe).FirstOrDefault(),
                          count = database.HopDongs.Where(s => s.maXe == _xe.maXe && s.ngayLapHopDong.Month == month && s.ngayLapHopDong.Year == year &&s.maTinhTrangHopDong==1).Count()
                      }).ToList();
            if (sortOrder == "Count")
            {
                xe = (from _xe in xe
                      orderby _xe.count ascending
                      select _xe).ToList();
            }
            else
            {
                xe = (from _xe in xe
                      orderby _xe.count descending
                      select _xe).ToList();
            }

            ViewData["month"] = month;
            ViewData["year"] = year;
            return View(xe.ToPagedList(pageNum, pageSize));

        }
    }
}