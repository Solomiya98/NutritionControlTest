using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutritionControl.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ProductReceipt> ProductReceipts { get; set; }
        public DbSet<UserAdditionalInfo> UserAdditionalInfos { get; set; }
        public DbSet<WeightInfo> WeightInfos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReceipt>()
               .HasKey(t => new { t.ProductId, t.ReceiptId });

            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.Receipts)
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Receipt)
                .WithMany(p => p.Products)
                .HasForeignKey(pr => pr.ReceiptId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserAdditionalInfo)
                .WithOne(ui => ui.User)
                .HasForeignKey<UserAdditionalInfo>(ui => ui.UserId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
