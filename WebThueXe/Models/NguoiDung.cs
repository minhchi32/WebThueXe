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
    
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            this.HoaDons = new HashSet<HoaDon>();
            this.HoaDons1 = new HashSet<HoaDon>();
            this.PhieuPhats = new HashSet<PhieuPhat>();
            this.SoXes = new HashSet<SoXe>();
        }
    
        public int maNguoiDung { get; set; }
        public string ten { get; set; }
        public string SDT { get; set; }
        public string diaChi { get; set; }
        public string hoKhau { get; set; }
        public string soTKNganHang { get; set; }
        public int maNganHang { get; set; }
        public string CMND { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int maQuyen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons1 { get; set; }
        public virtual NganHang NganHang { get; set; }
        public virtual Quyen Quyen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuPhat> PhieuPhats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoXe> SoXes { get; set; }
    }
}