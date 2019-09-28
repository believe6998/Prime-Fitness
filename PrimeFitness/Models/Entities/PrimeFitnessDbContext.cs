namespace PrimeFitness.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PrimeFitnessDbContext : DbContext
    {
        public PrimeFitnessDbContext()
            : base("name=PrimeFitnessDbContext")
        {
        }

        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<GoiTap> GoiTaps { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTHD>()
                .Property(e => e.MaGT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.MaDM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GoiTap>()
                .Property(e => e.MaGT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GoiTap>()
                .Property(e => e.UrlAnh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GoiTap>()
                .Property(e => e.MaDM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GoiTap>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.GoiTap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SoDienThoaiKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.UserName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.HoTen)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
