using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KeHoachDaNgoai.Models;

public partial class QLDaNgoaiContext : DbContext
{
    public QLDaNgoaiContext()
    {
    }

    public QLDaNgoaiContext(DbContextOptions<QLDaNgoaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChuyenDi> ChuyenDis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-BHA07K98;Database=QL_DaNgoai;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChuyenDi>(entity =>
        {
            entity.HasKey(e => e.MaChuyen).HasName("PK__ChuyenDi__0ED32A47A0E954A1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
