using Microsoft.EntityFrameworkCore;
using NecessaryDrugs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecessaryDrugs.Core.Contexts
{
    public class MedicineStoreContext : DbContext, IMedicineStoreContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public MedicineStoreContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Medicine>()
                .HasOne(p => p.Image)
                .WithOne(i => i.Medicine);

            builder.Entity<Medicine>()
                .HasOne(p => p.PriceDiscount)
                .WithOne(d => d.Medicine);

            builder.Entity<MedicineCategory>()
                .HasKey(pc => new { pc.MedicineId, pc.CategoryId });

            builder.Entity<MedicineCategory>()
                .HasOne(pc => pc.Medicine)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.MedicineId);

            builder.Entity<MedicineCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.Categories)
                .HasForeignKey(pc => pc.CategoryId);

            base.OnModelCreating(builder);
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineImage> MedicineImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MedicineCategory> MedicineCategories { get; set; }
        public DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
        public DbSet<PercentageDiscount> PercentageDiscounts { get; set; }
    }
}
