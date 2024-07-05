using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TTS3_LEHOAN.Models;

public partial class ShopspContext : DbContext
{
    public ShopspContext()
    {
    }

    public ShopspContext(DbContextOptions<ShopspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbDanhMuc> TbDanhMucs { get; set; }

    public virtual DbSet<TbSanPham> TbSanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=KENNE\\KENNE;Initial Catalog=shopsp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbDanhMuc>(entity =>
        {
            entity.HasKey(e => e.MaDanhMuc);

            entity.ToTable("tbDanhMuc");

            entity.Property(e => e.TenDanhMuc).HasMaxLength(100);
        });

        modelBuilder.Entity<TbSanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham);

            entity.ToTable("tbSanPham");

            entity.HasIndex(e => e.MaDanhMuc, "IX_tbSanPham_MaDanhMuc");

            entity.Property(e => e.TenSanPham).HasMaxLength(100);

            entity.HasOne(d => d.MaDanhMucNavigation).WithMany(p => p.TbSanPhams)
                .HasForeignKey(d => d.MaDanhMuc)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
