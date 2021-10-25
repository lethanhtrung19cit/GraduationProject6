﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GraduationProject.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FurnitureEntities : DbContext
    {
        public FurnitureEntities()
            : base("name=FurnitureEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DesignFurniture> DesignFurnitures { get; set; }
        public virtual DbSet<DetailCart> DetailCarts { get; set; }
        public virtual DbSet<DetailImportGood> DetailImportGoods { get; set; }
        public virtual DbSet<DetailOrder> DetailOrders { get; set; }
        public virtual DbSet<DisCount> DisCounts { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<ImportGood> ImportGoods { get; set; }
        public virtual DbSet<ListRequest> ListRequests { get; set; }
        public virtual DbSet<ListTypeGood> ListTypeGoods { get; set; }
        public virtual DbSet<SubImgDesign> SubImgDesigns { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TableComment> TableComments { get; set; }
        public virtual DbSet<TypeGood> TypeGoods { get; set; }
        public virtual DbSet<SubImage> SubImages { get; set; }
    }
}
