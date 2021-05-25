﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebThueXe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.CTHoaDons = new HashSet<CTHoaDon>();
        }



        [Display(Name = "Mã hóa đơn")]
        public int maHoaDon { get; set; }


        [Display(Name = "Ngày")]
        [Required(ErrorMessage = "Can not empty")]
        public System.DateTime ngay { get; set; }


        [Display(Name = "Tổng thanh toán")]
        [Required(ErrorMessage = "Can not empty")]
        public int tongThanhToan { get; set; }


        [Display(Name = "Đã thanh toán")]
        [Required(ErrorMessage = "Can not empty")]
        public int daThanhToan { get; set; }


        [Display(Name = "Còn nợ")]
        [Required(ErrorMessage = "Can not empty")]
        public int conNo { get; set; }


        [Display(Name = "Mã khách hàng")]
        [Required(ErrorMessage = "Can not empty")]
        public int maKhachHang { get; set; }


        [Display(Name = "Mã kế toán")]
        [Required(ErrorMessage = "Can not empty")]
        public int maKeToan { get; set; }


        [Display(Name = "Mã hợp đồng")]
        [Required(ErrorMessage = "Can not empty")]
        public int maHopDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }
        public virtual HopDong HopDong { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual NguoiDung NguoiDung1 { get; set; }
    }
}