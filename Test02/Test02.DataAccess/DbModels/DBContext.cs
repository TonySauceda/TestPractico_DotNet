using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test02.DataAccess.DbModels
{
    public partial class DBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<PhoneTypes> PhoneTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workshifts> Workshifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Gender");
            });

            modelBuilder.Entity<Phones>(entity =>
            {
                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Phone");

                entity.HasOne(d => d.KeyUserNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.KeyUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phones_Users");

                entity.HasOne(d => d.PhoneType);
            });

            modelBuilder.Entity<PhoneTypes>(entity =>
            {
                entity.Property(e => e.PhoneType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PhoneType");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.KeyUser);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender);

                entity.HasOne(d => d.Workshift);
            });

            modelBuilder.Entity<Workshifts>(entity =>
            {
                entity.Property(e => e.Workshift)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
