using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductKeys.ViewModels
{
    public class SalesModelEntities : DbContext
    {
        public SalesModelEntities()
            : base("name=SalesModelEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerView>()
                .HasMany(e => e.ProductSolds)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductView>()
                .Property(e => e.Price);

            modelBuilder.Entity<ProductView>()
                .HasMany(e => e.ProductSolds)
                .WithRequired(e => e.ProductView)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StoreView>()
                .HasMany(e => e.ProductSolds)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);
        }

        public virtual DbSet<CustomerView> Customers { get; set; }
        public virtual DbSet<ProductView> Products { get; set; }
        public virtual DbSet<ProductSoldView> ProductSolds { get; set; }
        public virtual DbSet<StoreView> Stores { get; set; }
        public virtual DbSet<sysdiagramView> sysdiagrams { get; set; }
    }
}