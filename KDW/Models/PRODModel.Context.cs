﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDW.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AIS20141015154903Entities : DbContext
    {
        public AIS20141015154903Entities()
            : base("name=AIS20141015154903Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ICMaxNumPROD> ICMaxNum { get; set; }
        public virtual DbSet<ICSubContractPROD> ICSubContract { get; set; }
        public virtual DbSet<ICSubContractEntryPROD> ICSubContractEntry { get; set; }
        public virtual DbSet<POOrderPROD> POOrder { get; set; }
        public virtual DbSet<POOrderEntryPROD> POOrderEntry { get; set; }
        public virtual DbSet<PPBOMPROD> PPBOM { get; set; }
        public virtual DbSet<PPBOMEntryPROD> PPBOMEntry { get; set; }
        public virtual DbSet<ICMOPROD> ICMO { get; set; }
    }
}