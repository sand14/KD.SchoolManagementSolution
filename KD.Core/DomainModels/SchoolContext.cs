using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KD.Core.DomainModels
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK_Courses_Specializations");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId).HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Students");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.IdentificationNumber).ValueGeneratedOnAdd();

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(u => u.IdentificationNumber).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

                entity.HasMany(d => d.Courses)
                    .WithMany(p => p.Students)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentCourse",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_StudentCourse_Courses"),
                        r => r.HasOne<Student>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_StudentCourse_Students"),
                        j =>
                        {
                            j.HasKey("StudentId", "CourseId");

                            j.ToTable("StudentCourse");
                        });
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Teachers_Courses");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK_Teachers_Specializations");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
