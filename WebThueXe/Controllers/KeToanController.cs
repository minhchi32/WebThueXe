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
    public class KeToanController : Controller
    {
        DBCarRentalEntities database = new DBCarRentalEntities();
        // GET: KeToan
        public ActionResult Index()
        {
            return View();
        }
        #region Quản lý xe
        public ActionResult QuanLyXe(int? page)
        {
            int pageSize = 10;
            int pageNum = (page ?? 1);
            var result = database.Xes.ToList();
            return View(result.ToPagedList(pageNum, pageSize));
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
            Xe xe = new Xe();
            return View(xe);
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
                    xe.hinh = "/Content/images/" + filename;
                    xe.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                database.Xes.Add(xe);
                database.SaveChanges();
                SaveToMainFolder(xe.maXe);
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

        #region Thêm nhiều ảnh
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveToTemp(HttpPostedFileBase file)
        {
            try
            {
                string filename = "";
                string imgepath = "Null";
                if (file != null)
                {
                    filename = file.FileName;
                    imgepath = filename;
                    string extension = Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/tmp/"), filename);
                    file.SaveAs(path);
                }
                return Json(filename, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult RemoveFile(string url)
        {
            try
            {
                var path = Path.Combine(Server.MapPath("~/"), url);
                if (System.IO.File.Exists(path))
                {
                    try
                    {
                        System.IO.File.Delete(path);
                        return Json(url, JsonRequestBehavior.AllowGet);

                    }
                    catch (System.IO.IOException e)
                    {
                        return Json(e, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(url, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// This method is used to move files from Temp folder to Destinatin folder.
        /// </summary>
        /// <returns></returns>
        public void SaveToMainFolder(int maXe)
        {
            var xe = database.Xes.Find(maXe);
            string fileName = "";
            string destFile = "";
            string sourcePath = Server.MapPath("~/Content/tmp/");
            string targetPath = Server.MapPath("~/Content/images/");
            XElement xElement = new XElement("Images");
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                // Copy the files. 
                foreach (string file in files)
                {
                    fileName = System.IO.Path.GetFileName(file);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(file, destFile, true);
                    string tmp = "/Content/images/" + fileName;
                    xElement.Add(new XElement("Images", tmp));
                }
                xe.hinhplus = xElement.ToString();
                database.SaveChanges();
                RemoveFiles();
            }
        }

        /// <summary>
        /// Make Temp folder empty once all files are copied to destination folder.
        /// </summary>
        public void RemoveFiles()
        {
            string sourcePath = Server.MapPath("~/Content/tmp/");
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            foreach (string file in files)
            {
                if (System.IO.File.Exists(System.IO.Path.Combine(sourcePath, file)))
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch (System.IO.IOException e)
                    {
                        return;
                    }
                }
            }
        }
        #endregion

        #region Quản lý người dùng
        public ActionResult QuanLyNguoiDung(int? page, string ten, int maQuyen = 0)
        {
            List<Quyen> list = database.Quyens.ToList();
            ViewBag.listQuyen = new SelectList(list, "maQuyen", "tenQuyen");
            int pageSize = 20;
            int pageNum = (page ?? 1);
            var result = database.NguoiDungs.Where(s=>s.maQuyen==2).ToList();
            if (ten != null)
                result = result.Where(s => s.ten.Contains(ten)).ToList();
            if (maQuyen != 0)
                result = result.Where(s => s.maQuyen == maQuyen).ToList();
            return View(result.ToPagedList(pageNum, pageSize));
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

        #region Quản lý hợp đồng
        public ActionResult DanhSachDonDatXe()
        {
            return View(database.HopDongs.Where(s => s.daDuyet == false).OrderByDescending(s => s.ngayLapHopDong).ToList());
        }
        public ActionResult DanhSachHopDong()
        {
            return View(database.HopDongs.Where(s => s.daDuyet == true).OrderByDescending(s => s.ngayLapHopDong).ToList());
        }
        public ActionResult DanhSachYeuCauHuyDonDatXe()
        {
            return View(database.HopDongs.Where(s => s.daDuyet == false && s.yeuCauHuyDon == true).OrderByDescending(s => s.ngayLapHopDong).ToList());
        }
        public ActionResult DanhSachYeuCauHuyHopDong()
        {
            return View(database.HopDongs.Where(s => s.daDuyet == true&&s.yeuCauHuyDon==true).OrderByDescending(s => s.ngayLapHopDong).ToList());
        }
        public ActionResult ChiTietHopDong(int id)
        {
            List<Xe> listXe = database.Xes.ToList();
            List<PhuongThucThanhToan> phuongThucThanhToans = database.PhuongThucThanhToans.ToList();
            List<HopDong> listHopDong = database.HopDongs.ToList();

            var tenXe = from _xe in listXe
                        join _hopDong1 in listHopDong on _xe.maXe equals _hopDong1.maXe
                        where _hopDong1.maHopDong == id
                        select _xe.tenXe;
            string[] strTenXe = tenXe.ToArray();
            var donGia = from _xe in listXe
                         join _hopDong1 in listHopDong on _xe.maXe equals _hopDong1.maXe
                         where _hopDong1.maHopDong == id
                         select _xe.giaThueXe;
            int[] strDonGia = donGia.ToArray();
            var pttt = from _phuongThucThanhToan in phuongThucThanhToans
                       join _hopDong1 in listHopDong on _phuongThucThanhToan.maPhuongThucThanhToan equals _hopDong1.maPhuongThucThanhToan
                       where _hopDong1.maHopDong == id
                       select _phuongThucThanhToan.tenPhuongThucThanhToan;
            string[] strPTTT = pttt.ToArray();

            var hopDong = from _hopDong in listHopDong
                          where _hopDong.maHopDong == id
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
                              donGia = strDonGia[0],
                              tenXe = strTenXe[0],
                              tenLoaiThanhToan = strPTTT[0],
                          };
            return PartialView(hopDong);
        }
        public JsonResult DuyetDonDatXe(int id)
        {
            var donDatXe = database.HopDongs.Find(id);
            donDatXe.daDuyet = true;
            database.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DuyetHopDong(int id)
        {
            var donDatXe = database.HopDongs.Find(id);
            donDatXe.maTinhTrangHopDong = 1;
            database.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public JsonResult YeuCauHuyHopDong(int id)
        {
            var donDatXe = database.HopDongs.Find(id);
            donDatXe.yeuCauHuyDon = true;
            database.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public JsonResult XacNhanThanhToan(int id)
        {
            var donDatXe = database.HopDongs.Find(id);
            donDatXe.daThanhToan = true;
            database.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        public JsonResult XoaHopDong(int id)
        {
            var donDatXe = database.HopDongs.Where(s => s.maHopDong == id).FirstOrDefault();
            database.HopDongs.Remove(donDatXe);
            database.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
        #endregion

        #region Quản lý hóa đơn
        public ActionResult DanhSachHoaDon()
        {
            return View(database.HoaDons.OrderByDescending(s => s.ngay).ToList());
        }
        public ActionResult ChiTietHoaDon(int id=1)
        {
            List<Xe> listXe = database.Xes.ToList();
            List<PhuongThucThanhToan> phuongThucThanhToans = database.PhuongThucThanhToans.ToList();
            List<HopDong> listHopDong = database.HopDongs.ToList();

            var tenXe = from _xe in listXe
                        join _hopDong1 in listHopDong on _xe.maXe equals _hopDong1.maXe
                        where _hopDong1.maHopDong == id
                        select _xe.tenXe;
            string[] strTenXe = tenXe.ToArray();
            var donGia = from _xe in listXe
                         join _hopDong1 in listHopDong on _xe.maXe equals _hopDong1.maXe
                         where _hopDong1.maHopDong == id
                         select _xe.giaThueXe;
            int[] strDonGia = donGia.ToArray();
            var pttt = from _phuongThucThanhToan in phuongThucThanhToans
                       join _hopDong1 in listHopDong on _phuongThucThanhToan.maPhuongThucThanhToan equals _hopDong1.maPhuongThucThanhToan
                       where _hopDong1.maHopDong == id
                       select _phuongThucThanhToan.tenPhuongThucThanhToan;
            string[] strPTTT = pttt.ToArray();

            var hopDong = from _hopDong in listHopDong
                          where _hopDong.maHopDong == id
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
                              donGia = strDonGia[0],
                              tenXe = strTenXe[0],
                              tenLoaiThanhToan = strPTTT[0],
                              Xe = database.Xes.Where(s => s.maXe == _hopDong.maXe).FirstOrDefault()
                          };
            ViewBag.ToDay = DateTime.Now;
            return PartialView(hopDong);
        }
        #endregion
    }
}