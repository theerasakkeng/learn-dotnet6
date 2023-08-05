using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestApp.Models
{
    public partial class Entities : DbContext
    {
        public Entities()
        {
        }

        public Entities(DbContextOptions<Entities> options)
            : base(options)
        {
        }

        public virtual DbSet<country> countries { get; set; } = null!;
        public virtual DbSet<department> departments { get; set; } = null!;
        public virtual DbSet<dependent> dependents { get; set; } = null!;
        public virtual DbSet<employee> employees { get; set; } = null!;
        public virtual DbSet<job> jobs { get; set; } = null!;
        public virtual DbSet<location> locations { get; set; } = null!;
        public virtual DbSet<region> regions { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ExampleDB;User id=sa;Password=Keng1234");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<country>(entity =>
            {
                entity.HasKey(e => e.country_id)
                    .HasName("PK__countrie__7E8CD055E198F519");

                entity.Property(e => e.country_id)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.country_name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<department>(entity =>
            {
                entity.HasKey(e => e.department_id)
                    .HasName("PK__departme__C223242278A61985");

                entity.Property(e => e.department_name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<dependent>(entity =>
            {
                entity.HasKey(e => e.dependent_id)
                    .HasName("PK__dependen__F25E28CE3AEA3689");

                entity.Property(e => e.first_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.last_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.relationship)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<employee>(entity =>
            {
                entity.HasKey(e => e.employee_id)
                    .HasName("PK__employee__C52E0BA8894FA55E");

                entity.Property(e => e.email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.first_name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.hire_date).HasColumnType("date");

                entity.Property(e => e.last_name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.phone_number)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.salary).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<job>(entity =>
            {
                entity.HasKey(e => e.job_id)
                    .HasName("PK__jobs__6E32B6A5090F74D1");

                entity.Property(e => e.job_title)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.max_salary).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.min_salary).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<location>(entity =>
            {
                entity.HasKey(e => e.location_id)
                    .HasName("PK__location__771831EAF88813A1");

                entity.Property(e => e.city)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.country_id)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.postal_code)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.state_province)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.street_address)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<region>(entity =>
            {
                entity.HasKey(e => e.region_id)
                    .HasName("PK__regions__01146BAE06A5BD73");

                entity.Property(e => e.region_name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
