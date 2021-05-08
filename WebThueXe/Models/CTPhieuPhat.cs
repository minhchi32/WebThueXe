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

    public partial class CTPhieuPhat
    {


        [Display(Name = "Mã chi tiết phiếu phạt")]
        public int maCTPhieuPhat { get; set; }


        [Display(Name = "Mã phiếu phạt")]
        [Required(ErrorMessage = "Can not empty")]
        public int maPhieuPhat { get; set; }


        [Display(Name = "Mã xe")]
        [Required(ErrorMessage = "Can not empty")]
        public int maXe { get; set; }


        [Display(Name = "Mã loại phạt")]
        [Required(ErrorMessage = "Can not empty")]
        public int maLoaiPhat { get; set; }
    
        public virtual LoaiPhat LoaiPhat { get; set; }
        public virtual PhieuPhat PhieuPhat { get; set; }
        public virtual Xe Xe { get; set; }
    }
}
