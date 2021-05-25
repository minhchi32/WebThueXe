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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            this.CTHoaDons = new HashSet<CTHoaDon>();
            this.CTPhieuPhats = new HashSet<CTPhieuPhat>();
            this.HopDongs = new HashSet<HopDong>();
            this.SoDatXes = new HashSet<SoDatXe>();
            this.SoXes = new HashSet<SoXe>();
            hinh = "~/Content/images/car01.jpg";
        }

        [Display(Name = "Mã xe")]
        public int maXe { get; set; }

        [Display(Name = "Tên xe")]
        [Required(ErrorMessage = "Can not empty")]
        public string tenXe { get; set; }

        [Display(Name = "Biển số")]
        [Required(ErrorMessage = "Can not empty")]
        public string bienSo { get; set; }

        [Display(Name = "Giá xe")]
        [Required(ErrorMessage = "Can not empty")]
        public string giaXe { get; set; }

        [Display(Name = "Mô tả xe")]
        public string moTaXe { get; set; }

        [Display(Name = "Mã tình trạng xe")]
        [Required(ErrorMessage = "Can not empty")]
        public int maTinhTrangXe { get; set; }

        [Display(Name = "Giá thuê xe")]
        [Required(ErrorMessage = "Can not empty")]
        public int giaThueXe { get; set; }

        [Display(Name = "Mã loại xe")]
        [Required(ErrorMessage = "Can not empty")]
        public int maLoaiXe { get; set; }

        [Display(Name = "Mã hiệu xe")]
        [Required(ErrorMessage = "Can not empty")]
        public int maHieuXe { get; set; }

        [Display(Name = "Hình")]
        [Required(ErrorMessage = "Can not empty")]
        public string hinh { get; set; }
        public string hinhplus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuPhat> CTPhieuPhats { get; set; }
        public virtual HieuXe HieuXe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoDatXe> SoDatXes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoXe> SoXes { get; set; }
        public virtual TinhTrangXe TinhTrangXe { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}
