﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdibahceCalismaCizelge
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdibahceContainer : DbContext
    {
        public AdibahceContainer()
            : base("name=AdibahceContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Antre> Antre { get; set; }
    }
}
