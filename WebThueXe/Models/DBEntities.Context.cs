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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBCarRentalEntities : DbContext
    {
        public DBCarRentalEntities()
            : base("name=DBCarRentalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; }
        public virtual DbSet<CTPhieuPhat> CTPhieuPhats { get; set; }
        public virtual DbSet<HieuXe> HieuXes { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<LoaiPhat> LoaiPhats { get; set; }
        public virtual DbSet<LoaiXe> LoaiXes { get; set; }
        public virtual DbSet<NganHang> NganHangs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhieuPhat> PhieuPhats { get; set; }
        public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SoDatXe> SoDatXes { get; set; }
        public virtual DbSet<SoXe> SoXes { get; set; }
        public virtual DbSet<TinhTrangHopDong> TinhTrangHopDongs { get; set; }
        public virtual DbSet<TinhTrangXe> TinhTrangXes { get; set; }
        public virtual DbSet<Xe> Xes { get; set; }
    }
}
