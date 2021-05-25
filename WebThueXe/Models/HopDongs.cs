using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThueXe.Models
{
    public class HopDongs
    {
        public int maHopDong { get; set; }
        public int maNguoiDung { get; set; }
        public string hotenNguoiDatXe { get; set; }
        public string email { get; set; }
        public int SDT { get; set; }
        public string ghiChu { get; set; }
        public int maXe { get; set; }
        public int soNgayThue { get; set; }
        public System.DateTime ngayLapHopDong { get; set; }
        public System.DateTime ngayThue { get; set; }
        public System.DateTime ngayTra { get; set; }
        public string diaChiNhanXe { get; set; }
        public int TongTien { get; set; }
        public bool daThanhToan { get; set; }
        public bool daDuyet { get; set; }
        public bool yeuCauHuyDon { get; set; }
        public int maTinhTrangHopDong { get; set; }
        public int maPhuongThucThanhToan { get; set; }
        public int donGia { get; set; }
        public string tenXe { get; set; }
        public string tenLoaiThanhToan { get; set; }
        public IEnumerable<Xe> listXe { get; set; }
        public IEnumerable<PhuongThucThanhToan> listLoaiThanhToan { get; set; }
        public IEnumerable<HopDong> listHopDong { get; set; }


    }
}