using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WHSAPI.Entities;

namespace WHSAPI.Context;

public partial class WHSDbContext : DbContext
{
    public WHSDbContext()
    {
    }

    public WHSDbContext(DbContextOptions<WHSDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DimDate> DimDates { get; set; }

    public virtual DbSet<DimEmployee> DimEmployees { get; set; }

    public virtual DbSet<DimIndustry> DimIndustries { get; set; }

    public virtual DbSet<DimProject> DimProjects { get; set; }

    public virtual DbSet<DimRole> DimRoles { get; set; }

    public virtual DbSet<FactWorksWithTask> FactWorksWithTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ITCompanyWHS;User=sa;Password=kjsfq3jkskj1kej;Persist Security Info=False;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DimDate>(entity =>
        {
            entity.HasKey(e => e.DateKey).HasName("PK__dim_date__67370B448B65B044");

            entity.ToTable("dim_dates");

            entity.Property(e => e.DateKey).HasColumnName("date_key");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<DimEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeKey).HasName("PK__dim_empl__8DC077F8D28A0C83");

            entity.ToTable("dim_employees");

            entity.Property(e => e.EmployeeKey).HasColumnName("employee_key");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleKey).HasColumnName("role_key");

            entity.HasOne(d => d.RoleKeyNavigation).WithMany(p => p.DimEmployees)
                .HasForeignKey(d => d.RoleKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dim_employees_role_key_fk");
        });

        modelBuilder.Entity<DimIndustry>(entity =>
        {
            entity.HasKey(e => e.IndustryKey).HasName("PK__dim_indu__36519F1EE0575829");

            entity.ToTable("dim_industry");

            entity.Property(e => e.IndustryKey).HasColumnName("industry_key");
            entity.Property(e => e.IndustryId).HasColumnName("industry_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DimProject>(entity =>
        {
            entity.HasKey(e => e.ProjectKey).HasName("PK__dim_proj__30AB21DE84DD8BB2");

            entity.ToTable("dim_projects");

            entity.Property(e => e.ProjectKey).HasColumnName("project_key");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IndustryKey).HasColumnName("industry_key");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectManagerKey).HasColumnName("project_manager_key");

            entity.HasOne(d => d.IndustryKeyNavigation).WithMany(p => p.DimProjects)
                .HasForeignKey(d => d.IndustryKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dim_proje__indus__7B663F43");

            entity.HasOne(d => d.ProjectManagerKeyNavigation).WithMany(p => p.DimProjects)
                .HasForeignKey(d => d.ProjectManagerKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dim_proje__proje__7A721B0A");
        });

        modelBuilder.Entity<DimRole>(entity =>
        {
            entity.HasKey(e => e.RoleKey).HasName("PK__dim_role__515C1819F329445D");

            entity.ToTable("dim_roles");

            entity.Property(e => e.RoleKey).HasColumnName("role_key");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<FactWorksWithTask>(entity =>
        {
            entity.HasKey(e => e.WorksKey).HasName("PK__fact_wor__0635E4B83DC5C8F0");

            entity.ToTable("fact_works_with_task");

            entity.Property(e => e.WorksKey).HasColumnName("works_key");
            entity.Property(e => e.DelayedTimeMinutes).HasColumnName("delayed_time_minutes");
            entity.Property(e => e.DelayedWorksCount).HasColumnName("delayed_works_count");
            entity.Property(e => e.EmployeeKey).HasColumnName("employee_key");
            entity.Property(e => e.EndDateKey).HasColumnName("end_date_key");
            entity.Property(e => e.EstimatedTimeMinutes).HasColumnName("estimated_time_minutes");
            entity.Property(e => e.FailedWorksCount).HasColumnName("failed_works_count");
            entity.Property(e => e.ProjectKey).HasColumnName("project_key");
            entity.Property(e => e.StartDateKey).HasColumnName("start_date_key");
            entity.Property(e => e.SuccessfulWorksCount).HasColumnName("successful_works_count");
            entity.Property(e => e.TotalWorksCount).HasColumnName("total_works_count");
            entity.Property(e => e.WorkedTimeMinutes).HasColumnName("worked_time_minutes");

            entity.HasOne(d => d.EmployeeKeyNavigation).WithMany(p => p.FactWorksWithTasks)
                .HasForeignKey(d => d.EmployeeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fact_work__emplo__011F1899");

            entity.HasOne(d => d.EndDateKeyNavigation).WithMany(p => p.FactWorksWithTaskEndDateKeyNavigations)
                .HasForeignKey(d => d.EndDateKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fact_work__end_d__002AF460");

            entity.HasOne(d => d.ProjectKeyNavigation).WithMany(p => p.FactWorksWithTasks)
                .HasForeignKey(d => d.ProjectKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fact_work__proje__7E42ABEE");

            entity.HasOne(d => d.StartDateKeyNavigation).WithMany(p => p.FactWorksWithTaskStartDateKeyNavigations)
                .HasForeignKey(d => d.StartDateKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fact_work__start__7F36D027");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
