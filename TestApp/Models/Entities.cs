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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<country>(entity =>
            {
                entity.HasKey(e => e.country_id)
                    .HasName("PK__countrie__7E8CD055A81B12E2");

                entity.Property(e => e.country_id)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.country_name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.region)
                    .WithMany(p => p.countries)
                    .HasForeignKey(d => d.region_id)
                    .HasConstraintName("FK__countries__regio__286302EC");
            });

            modelBuilder.Entity<department>(entity =>
            {
                entity.HasKey(e => e.department_id)
                    .HasName("PK__departme__C22324227CC5084F");

                entity.Property(e => e.department_name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.location)
                    .WithMany(p => p.departments)
                    .HasForeignKey(d => d.location_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__departmen__locat__35BCFE0A");
            });

            modelBuilder.Entity<dependent>(entity =>
            {
                entity.HasKey(e => e.dependent_id)
                    .HasName("PK__dependen__F25E28CE068989D7");

                entity.Property(e => e.first_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.last_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.relationship)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.employee)
                    .WithMany(p => p.dependents)
                    .HasForeignKey(d => d.employee_id)
                    .HasConstraintName("FK__dependent__emplo__412EB0B6");
            });

            modelBuilder.Entity<employee>(entity =>
            {
                entity.HasKey(e => e.employee_id)
                    .HasName("PK__employee__C52E0BA8CC340997");

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

                entity.HasOne(d => d.department)
                    .WithMany(p => p.employees)
                    .HasForeignKey(d => d.department_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__employees__depar__3D5E1FD2");

                entity.HasOne(d => d.job)
                    .WithMany(p => p.employees)
                    .HasForeignKey(d => d.job_id)
                    .HasConstraintName("FK__employees__job_i__3C69FB99");

                entity.HasOne(d => d.manager)
                    .WithMany(p => p.Inversemanager)
                    .HasForeignKey(d => d.manager_id)
                    .HasConstraintName("FK__employees__manag__3E52440B");
            });

            modelBuilder.Entity<job>(entity =>
            {
                entity.HasKey(e => e.job_id)
                    .HasName("PK__jobs__6E32B6A56AAC0B1B");

                entity.Property(e => e.job_title)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.max_salary).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.min_salary).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<location>(entity =>
            {
                entity.HasKey(e => e.location_id)
                    .HasName("PK__location__771831EA4AD55A9C");

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

                entity.HasOne(d => d.country)
                    .WithMany(p => p.locations)
                    .HasForeignKey(d => d.country_id)
                    .HasConstraintName("FK__locations__count__2E1BDC42");
            });

            modelBuilder.Entity<region>(entity =>
            {
                entity.HasKey(e => e.region_id)
                    .HasName("PK__regions__01146BAE581D3DA3");

                entity.Property(e => e.region_name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
