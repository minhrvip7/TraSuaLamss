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

        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LienHe> LienHe { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhanLoai> PhanLoai { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public object NHANVIEN { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.MaDH)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.PhuongThucThanhToan)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.ThanhToan)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.DiaChiGiaoHang)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TinhTrangGiaoHang)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonHang)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.GioHang)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.MaLH)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NguyenLieu>()
                .Property(e => e.MaNL)
                .IsUnicode(false);

            modelBuilder.Entity<NguyenLieu>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.SanPham)
                .WithRequired(e => e.NGUYENLIEU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.NguyenLieu)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.STK)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Luong)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhanLoai>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<PhanLoai>()
                .HasMany(e => e.SanPham)
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
                .HasMany(e => e.GioHang)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.KhachHang)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.NhanVien)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);
        }
    }
}
