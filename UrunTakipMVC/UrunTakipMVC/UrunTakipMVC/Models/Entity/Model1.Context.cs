﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrunTakipMVC.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbStokMVCEntities : DbContext
    {
        public DbStokMVCEntities()
            : base("name=DbStokMVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kategoriler> Kategorilers { get; set; }
        public virtual DbSet<Musteriler> Musterilers { get; set; }
        public virtual DbSet<Personeller> Personellers { get; set; }
        public virtual DbSet<Satislar> Satislars { get; set; }
        public virtual DbSet<Urunler> Urunlers { get; set; }
        public virtual DbSet<Adminler> Adminlers { get; set; }
    }
}
