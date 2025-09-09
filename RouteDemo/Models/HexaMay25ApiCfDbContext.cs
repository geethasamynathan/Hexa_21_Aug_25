using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RouteDemo.Models;

public partial class HexaMay25ApiCfDbContext : DbContext
{
    public HexaMay25ApiCfDbContext()
    {
    }

    public HexaMay25ApiCfDbContext(DbContextOptions<HexaMay25ApiCfDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-0TBPBTEL\\SQLEXPRESS;Database=Hexa_may_25_api_CF_DB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("students");

            entity.HasIndex(e => e.CourseId, "IX_students_CourseId");

            entity.HasOne(d => d.Course).WithMany(p => p.Students).HasForeignKey(d => d.CourseId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
