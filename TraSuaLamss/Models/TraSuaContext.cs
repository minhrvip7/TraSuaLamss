using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TraSuaLamss.Models
{
    public partial class TraSuaContext : DbContext
    {
        public TraSuaContext()
            : base("name=TraSuaContext")
        {
        }

        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<GIOHANG> GIOHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LIENHE> LIENHEs { get; set; }
        public virtual DbSet<NGUYENLIEU> NGUYENLIEUx { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHANLOAI> PHANLOAIs { get; set; }
        public virtual DbSet<SanPham> SANPHAMs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaDH)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.PhuongThucThanhToan)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.ThanhToan)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.DiaChiGiaoHang)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.TinhTrangGiaoHang)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<GIOHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<GIOHANG>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.GIOHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LIENHE>()
                .Property(e => e.MaLH)
                .IsUnicode(false);

            modelBuilder.Entity<LIENHE>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .Property(e => e.MaNL)
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.NGUYENLIEU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.NGUYENLIEUx)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.STK)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Luong)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PHANLOAI>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<PHANLOAI>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.PHANLOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaNL)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.GIOHANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.KHACHHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);
        }
    }
}
