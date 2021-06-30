using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TutorialJWT.Model
{
    public partial class db_latihan_gunawanContext : DbContext
    {
        public db_latihan_gunawanContext()
        {
        }

        public db_latihan_gunawanContext(DbContextOptions<db_latihan_gunawanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillLevel> SkillLevels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             optionsBuilder.UseSqlServer("Data Source=LAPTOP-IM1D695S\\SQLEXPRESS;Initial Catalog=db_latihan_gunawan;User ID=sa;Password=Password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.ToTable("SkillLevel");

                entity.Property(e => e.SkillLevelId).HasColumnName("skillLevelID");

                entity.Property(e => e.SkillLevelName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("skillLevelName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__F3DBC5732FD86361");

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserProfile");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Bod)
                    .HasColumnType("date")
                    .HasColumnName("bod");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_ToUser");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.Property(e => e.UserSkillId)
                    .ValueGeneratedNever()
                    .HasColumnName("userSkillId");

                entity.Property(e => e.SkillId).HasColumnName("skillID");

                entity.Property(e => e.SkillLevelId).HasColumnName("skillLevelID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_UserSkills_ToSkill");

                entity.HasOne(d => d.SkillLevel)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillLevelId)
                    .HasConstraintName("FK_UserSkills_ToSkillLevel");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_UserSkills_ToUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
