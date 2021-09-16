using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class HUMGEDUContext : DbContext
    {
        public HUMGEDUContext()
        {

        }

        public HUMGEDUContext(DbContextOptions<HUMGEDUContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Baihoc> Baihocs { get; set; }
        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Khoahoc> Khoahocs { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<Thongbao> Thongbaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-6HLOTS1\\MSSQLSERVER01;Database=HUMGEDU;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Baihoc>(entity =>
            {
                entity.HasKey(e => e.Idbaihoc);

                entity.ToTable("baihoc");

                entity.Property(e => e.Idbaihoc).HasColumnName("idbaihoc");

                entity.Property(e => e.Linkbaihoc)
                    .HasColumnType("text")
                    .HasColumnName("linkbaihoc");

                entity.Property(e => e.Linkvideobaihoc)
                    .HasColumnType("text")
                    .HasColumnName("linkvideobaihoc");

                entity.Property(e => e.Motabaihoc)
                    .HasColumnType("text")
                    .HasColumnName("motabaihoc");

                entity.Property(e => e.Tenbaihoc)
                    .HasColumnType("text")
                    .HasColumnName("tenbaihoc");
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.Iddanhmuc);

                entity.ToTable("danhmuc");

                entity.Property(e => e.Iddanhmuc).HasColumnName("iddanhmuc");

                entity.Property(e => e.Idkhoahoc).HasColumnName("idkhoahoc");

                entity.Property(e => e.Linkdanhmuc)
                    .IsRequired()
                    .HasColumnName("linkdanhmuc");

                entity.Property(e => e.Tendanhmuc)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("tendanhmuc");

                entity.HasOne(d => d.IdkhoahocNavigation)
                    .WithMany(p => p.Danhmucs)
                    .HasForeignKey(d => d.Idkhoahoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_danhmuc_khoahoc");
            });

            modelBuilder.Entity<Khoahoc>(entity =>
            {
                entity.HasKey(e => e.Idkhoahoc);

                entity.ToTable("khoahoc");

                entity.Property(e => e.Idkhoahoc)
                    .ValueGeneratedNever()
                    .HasColumnName("idkhoahoc");

                entity.Property(e => e.Anhmotakhoahoc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("anhmotakhoahoc");

                entity.Property(e => e.Idbaihoc).HasColumnName("idbaihoc");

                entity.Property(e => e.Linkkhoahoc)
                    .IsRequired()
                    .HasColumnName("linkkhoahoc");

                entity.Property(e => e.Motakhoahoc)
                    .IsRequired()
                    .HasColumnName("motakhoahoc");

                entity.Property(e => e.Tenkhoahoc)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("tenkhoahoc");

                entity.HasOne(d => d.IdbaihocNavigation)
                    .WithMany(p => p.Khoahocs)
                    .HasForeignKey(d => d.Idbaihoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_khoahoc_baihoc");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("taikhoan");

                entity.Property(e => e.Iduser)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("iduser");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .HasColumnName("mail");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Thongbao>(entity =>
            {
                entity.HasKey(e => e.Idthongbao);

                entity.ToTable("thongbao");

                entity.Property(e => e.Idthongbao).HasColumnName("idthongbao");

                entity.Property(e => e.Linkthongbao)
                    .HasColumnType("text")
                    .HasColumnName("linkthongbao");

                entity.Property(e => e.Motathongbao)
                    .HasColumnType("text")
                    .HasColumnName("motathongbao");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
