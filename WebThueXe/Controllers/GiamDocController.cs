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
        public ActionResult BaoCaoHopDong(int month=1,int year=2021,bool daThanhToan=true,string tenXe="")
        {
            List<Xe> listXe = database.Xes.ToList();
            List<PhuongThucThanhToan> phuongThucThanhToans = database.PhuongThucThanhToans.ToList();
            List<HopDong> listHopDong = database.HopDongs.ToList();
            if (tenXe == "tenXeId")
            {
                var hopDong = from _hopDong in listHopDong
                              join _xe in listXe on _hopDong.maXe equals _xe.maXe
                              join _phuongThucThanhToan in phuongThucThanhToans on _hopDong.maPhuongThucThanhToan equals _phuongThucThanhToan.maPhuongThucThanhToan
                              where _hopDong.ngayLapHopDong.Year == year && _hopDong.ngayLapHopDong.Month == month && _hopDong.daThanhToan == daThanhToan
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

                return View(hopDong);
            }
            else
            {
                var hopDong = from _hopDong in listHopDong
                              join _xe in listXe on _hopDong.maXe equals _xe.maXe
                              join _phuongThucThanhToan in phuongThucThanhToans on _hopDong.maPhuongThucThanhToan equals _phuongThucThanhToan.maPhuongThucThanhToan
                              where _hopDong.ngayLapHopDong.Year == year && _hopDong.ngayLapHopDong.Month == month && _hopDong.daThanhToan == daThanhToan && _xe.tenXe == tenXe
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
                return View(hopDong);
            }
            
        }
        public JsonResult LoadTenXe(int month = 1, int year = 2021, bool daThanhToan = true)
        {
            List<Xe> listXe = database.Xes.ToList();
            List<PhuongThucThanhToan> phuongThucThanhToans = database.PhuongThucThanhToans.ToList();
            List<HopDong> listHopDong = database.HopDongs.ToList();
            
            var hopDong = from _hopDong in listHopDong
                          join _xe in listXe on _hopDong.maXe equals _xe.maXe
                          join _phuongThucThanhToan in phuongThucThanhToans on _hopDong.maPhuongThucThanhToan equals _phuongThucThanhToan.maPhuongThucThanhToan
                          where _hopDong.ngayLapHopDong.Year == year && _hopDong.ngayLapHopDong.Month == month && _hopDong.daThanhToan == daThanhToan
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
            List<Xes> listTenXe = new List<Xes>();
            Xes xes = null;
            foreach (var item in hopDong)
            {
                xes = new Xes();
                xes.maXe = item.maXe;
                xes.tenXe = item.tenXe;
                listTenXe.Add(xes);
            }
            return Json(new
            {
                data = listTenXe,
                status = true
            });
        }
    }
}