﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TlcDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TLC_DBEntities : DbContext
    {
        public TLC_DBEntities()
            : base("name=TLC_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbFabric> tbFabrics { get; set; }
        public virtual DbSet<tbArtwork> tbArtworks { get; set; }
        public virtual DbSet<tbCustomerArtwork> tbCustomerArtworks { get; set; }
        public virtual DbSet<tbFrame> tbFrames { get; set; }
        public virtual DbSet<tbInstallationGuide> tbInstallationGuides { get; set; }
        public virtual DbSet<tbInStoreLocation> tbInStoreLocations { get; set; }
        public virtual DbSet<tbLookClientCustomer> tbLookClientCustomers { get; set; }
        public virtual DbSet<tbLookClient> tbLookClients { get; set; }
        public virtual DbSet<tbPromotionalMaterial> tbPromotionalMaterials { get; set; }
        public virtual DbSet<tbUser> tbUsers { get; set; }
        public virtual DbSet<UserLevelPermission> UserLevelPermissions { get; set; }
        public virtual DbSet<UserLevel> UserLevels { get; set; }
    }
}
