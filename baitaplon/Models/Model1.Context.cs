﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace baitaplon.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLSVEntities : DbContext
    {
        public QLSVEntities()
            : base("name=QLSVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<diemthi> diemthi { get; set; }
        public virtual DbSet<giangvien> giangvien { get; set; }
        public virtual DbSet<khoa> khoa { get; set; }
        public virtual DbSet<lop> lop { get; set; }
        public virtual DbSet<monhoc> monhoc { get; set; }
        public virtual DbSet<nganh> nganh { get; set; }
        public virtual DbSet<sinhvien> sinhvien { get; set; }
    }
}