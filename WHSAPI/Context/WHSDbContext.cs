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

    public virtual DbSet<DimProject> DimProjects { get; set; }

    public virtual DbSet<DimRole> DimRoles { get; set; }

    public virtual DbSet<DimTask> DimTasks { get; set; }

    public virtual DbSet<FactWorksWithTask> FactWorksWithTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ITCompanyWHS;User=sa;Password=kjsfq3jkskj1kej;Persist Security Info=False;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DimDate>(entity =>
        {
            entity.HasKey(e => e.DateKey).HasName("PK__dim_date__67370B443A7A1F0D");

            entity.ToTable("dim_dates");

            entity.Property(e => e.DateKey).HasColumnName("date_key");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<DimEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeKey).HasName("PK__dim_empl__8DC077F829F58E34");

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

        modelBuilder.Entity<DimProject>(entity =>
        {
            entity.HasKey(e => e.ProjectKey).HasName("PK__dim_proj__30AB21DE83A3AE4F");

            entity.ToTable("dim_projects");

            entity.Property(e => e.ProjectKey).HasColumnName("project_key");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Industry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("industry");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Platforms)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("platforms");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectManagerKey).HasColumnName("project_manager_key");
            entity.Property(e => e.Regions)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("regions");

            entity.HasOne(d => d.ProjectManagerKeyNavigation).WithMany(p => p.DimProjects)
                .HasForeignKey(d => d.ProjectManagerKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dim_proje__proje__38845C1C");
        });

        modelBuilder.Entity<DimRole>(entity =>
        {
            entity.HasKey(e => e.RoleKey).HasName("PK__dim_role__515C181976E5C2AF");

            entity.ToTable("dim_roles");

            entity.Property(e => e.RoleKey).HasColumnName("role_key");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<DimTask>(entity =>
        {
            entity.HasKey(e => e.TaskKey).HasName("PK__dim_task__2205E620607C6CAC");

            entity.ToTable("dim_tasks");

            entity.Property(e => e.TaskKey).HasColumnName("task_key");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PricePerHour)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_per_hour");
            entity.Property(e => e.Priority)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("priority");
            entity.Property(e => e.ProjectKey).HasColumnName("project_key");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.ProjectKeyNavigation).WithMany(p => p.DimTasks)
                .HasForeignKey(d => d.ProjectKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dim_tasks__project_key_5CD6CB2B");
        });

        modelBuilder.Entity<FactWorksWithTask>(entity =>
        {
            entity.HasKey(e => e.WorkKey).HasName("PK__fact_wor__B0E591DE06638E7A");

            entity.ToTable("fact_works_with_task");

            entity.Property(e => e.WorkKey).HasColumnName("work_key");
            entity.Property(e => e.Category)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.DelayReason)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("delay_reason");
            entity.Property(e => e.DelayedTimeMinutes).HasColumnName("delayed_time_minutes");
            entity.Property(e => e.EmployeeKey).HasColumnName("employee_key");
            entity.Property(e => e.EndDateKey).HasColumnName("end_date_key");
            entity.Property(e => e.EstimatedCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("estimated_cost");
            entity.Property(e => e.EstimatedTimeMinutes).HasColumnName("estimated_time_minutes");
            entity.Property(e => e.FinalCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("final_cost");
            entity.Property(e => e.StartDateKey).HasColumnName("start_date_key");
            entity.Property(e => e.TaskChange)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("task_change");
            entity.Property(e => e.TaskKey).HasColumnName("task_key");
            entity.Property(e => e.WorkDescription)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("work_description");
            entity.Property(e => e.WorkId).HasColumnName("work_id");
            entity.Property(e => e.WorkResult)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("work_result");
            entity.Property(e => e.WorkedTimeMinutes).HasColumnName("worked_time_minutes");

            entity.HasOne(d => d.EmployeeKeyNavigation).WithMany(p => p.FactWorksWithTasks)
                .HasForeignKey(d => d.EmployeeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fact_work__emplo__4119A21D");

            entity.HasOne(d => d.EndDateKeyNavigation).WithMany(p => p.FactWorksWithTaskEndDateKeyNavigations)
                .HasForeignKey(d => d.EndDateKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fact_work__end_d__40257DE4")
                .IsRequired();

            entity.HasOne(d => d.StartDateKeyNavigation).WithMany(p => p.FactWorksWithTaskStartDateKeyNavigations)
                .HasForeignKey(d => d.StartDateKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fact_work__start__3F3159AB")
                .IsRequired();

            entity.HasOne(d => d.TaskKeyNavigation).WithMany(p => p.FactWorksWithTasks)
                .HasForeignKey(d => d.TaskKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fact_work__task___3E3D3572");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
