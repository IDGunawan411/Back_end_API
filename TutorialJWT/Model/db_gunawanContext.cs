using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TutorialJWT.Model
{
    public partial class db_gunawanContext : DbContext
    {

        public virtual DbSet<TblPegawai> TblPegawai { get; set; }
        public db_gunawanContext()
        {
        }

        public db_gunawanContext(DbContextOptions<db_gunawanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPegawai> TblPegawais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning 'To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-IM1D695S\\SQLEXPRESS;Initial Catalog=db_gunawan;User ID=sa;Password=Password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblPegawai>(entity =>
            {
                entity.HasKey(e => e.Idpegawai);

                entity.ToTable("tbl_pegawai");

                entity.Property(e => e.Idpegawai).HasColumnName("idpegawai");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nama");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
