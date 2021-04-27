//------------------------------------------------------------------------------
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
    
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            this.CTHoaDons = new HashSet<CTHoaDon>();
            this.CTHopDongs = new HashSet<CTHopDong>();
            this.CTPhieuPhats = new HashSet<CTPhieuPhat>();
            this.SoXes = new HashSet<SoXe>();
        }
    
        public int maXe { get; set; }
        public string tenXe { get; set; }
        public string bienSo { get; set; }
        public string giaXe { get; set; }
        public string moTaXe { get; set; }
        public int maTinhTrangXe { get; set; }
        public int giaThueXe { get; set; }
        public int maLoaiXe { get; set; }
        public int maHieuXe { get; set; }
        public string hinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHopDong> CTHopDongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuPhat> CTPhieuPhats { get; set; }
        public virtual HieuXe HieuXe { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoXe> SoXes { get; set; }
        public virtual TinhTrangXe TinhTrangXe { get; set; }
    }
}
