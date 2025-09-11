using System;
using System.Collections.Generic;
using Auth_Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth_Demo1.Data;

public partial class BikeStoresContext : DbContext
{
    public BikeStoresContext(DbContextOptions<BikeStoresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<product> products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.product_id).HasName("PK__products__47027DF56DC1BCCB");

            entity.ToTable("products", "production");

            entity.Property(e => e.list_price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.product_name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
