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
    using System.ComponentModel.DataAnnotations;

    public partial class LoaiPhat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhat()
        {
            this.CTPhieuPhats = new HashSet<CTPhieuPhat>();
        }



        [Display(Name = "Mã loại phạt")]
        public int maLoaiPhat { get; set; }


        [Display(Name = "Tên loại phạt")]
        [Required(ErrorMessage = "Can not empty")]
        public string tenLoaiPhat { get; set; }


        [Display(Name = "Tiền phạt")]
        [Required(ErrorMessage = "Can not empty")]
        public int tienPhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuPhat> CTPhieuPhats { get; set; }
    }
}