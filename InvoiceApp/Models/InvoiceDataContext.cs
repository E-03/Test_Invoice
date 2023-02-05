using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace InvoiceApp.Models
{
    public partial class InvoiceDataContext : DbContext
    {
        public InvoiceDataContext()
            : base("name=InvoiceDataContext")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<CustomerTypes> CustomerTypes { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Invoice)
                .WithRequired(e => e.Customers)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<CustomerTypes>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.CustomerTypes)
                .HasForeignKey(e => e.CustomerTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalItbis)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceDetail)
                .WithRequired(e => e.Invoice)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.TotalItbis)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);
        }
    }
}
