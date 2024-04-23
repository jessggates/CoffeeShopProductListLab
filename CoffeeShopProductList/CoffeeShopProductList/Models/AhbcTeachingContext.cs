using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopProductList.Models;

public partial class AhbcTeachingContext : DbContext
{
    public AhbcTeachingContext()
    {
    }

    public AhbcTeachingContext(DbContextOptions<AhbcTeachingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductViewModel> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductViewModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC076C778D14");

            entity.Property(e => e.Category).HasMaxLength(30);
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
