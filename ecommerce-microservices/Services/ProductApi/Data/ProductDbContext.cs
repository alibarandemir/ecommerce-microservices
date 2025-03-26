using Microsoft.EntityFrameworkCore;
using ProductApi.Models;
using System.Collections.Generic;

namespace ProductApi.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Category)
                .HasConversion<string>(); // Enum'ı string olarak sakla
        }
    }
}
