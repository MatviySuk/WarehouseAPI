using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WHSAPI.Entities.Entities;

namespace WHSAPI.Context;

public partial class ITCompanyDbContext : DbContext
{
    public ITCompanyDbContext()
    {
    }

    public ITCompanyDbContext(DbContextOptions<ITCompanyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DelayReason> DelayReasons { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectCategory> ProjectCategories { get; set; }

    public virtual DbSet<ProjectPlatform> ProjectPlatforms { get; set; }

    public virtual DbSet<ProjectRegion> ProjectRegions { get; set; }

    public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StagingLoad> StagingLoads { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<TasksStatus> TaskStatuses { get; set; }

    public virtual DbSet<TaskType> TaskTypes { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamEmployee> TeamEmployees { get; set; }

    public virtual DbSet<TeamType> TeamTypes { get; set; }

    public virtual DbSet<WorkCategory> WorkCategories { get; set; }

    public virtual DbSet<WorkComment> WorkComments { get; set; }

    public virtual DbSet<WorkResult> WorkResults { get; set; }

    public virtual DbSet<WorksWithTask> WorksWithTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ITCompanyDB;User=sa;Password=kjsfq3jkskj1kej;Persist Security Info=False;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DelayReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__delay_re__3213E83F6F981821");

            entity.ToTable("delay_reasons", tb => tb.HasTrigger("tr_delay_reasons_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coeficient)
                .HasDefaultValueSql("((1.0))")
                .HasColumnName("coeficient");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83FEA66C5F3");

            entity.ToTable("employees", tb => tb.HasTrigger("tr_employees_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hire_date");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Notes)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salary");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F0DADB299");

            entity.ToTable("employee_roles", tb => tb.HasTrigger("tr_employees_roles_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeRoles)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_roles_employee_id_fk");

            entity.HasOne(d => d.Role).WithMany(p => p.EmployeeRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_roles_role_id_fk");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__industri__3213E83FF117680D");

            entity.ToTable("industries", tb => tb.HasTrigger("tr_industries_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__platform__3213E83F736326EB");

            entity.ToTable("platforms", tb => tb.HasTrigger("tr_platforms_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__prioriti__3213E83F01626A9A");

            entity.ToTable("priorities", tb => tb.HasTrigger("tr_priorities_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coeficient)
                .HasDefaultValueSql("((1.0))")
                .HasColumnName("coeficient");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83FB1AA91C3");

            entity.ToTable("projects", tb => tb.HasTrigger("tr_projects_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.IndustryId).HasColumnName("industry_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProjectManagerId).HasColumnName("project_manager_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Category).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_category_id_fk");

            entity.HasOne(d => d.Industry).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_industry_id_fk");

            entity.HasOne(d => d.ProjectManager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_project_manager_id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_status_id_fk");

            entity.HasOne(d => d.Team).WithMany(p => p.Projects)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_team_id_fk");
        });

        modelBuilder.Entity<ProjectCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__project___3213E83FE3EFCD1C");

            entity.ToTable("project_categories", tb => tb.HasTrigger("tr_project_categories_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProjectPlatform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__project___3213E83F76C75853");

            entity.ToTable("project_platforms", tb => tb.HasTrigger("tr_project_platforms_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PlatformId).HasColumnName("platform_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Platform).WithMany(p => p.ProjectPlatforms)
                .HasForeignKey(d => d.PlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_platforms_platform_id_fk");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectPlatforms)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_platforms_project_id_fk");
        });

        modelBuilder.Entity<ProjectRegion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__project___3213E83F4FCE0761");

            entity.ToTable("project_regions", tb => tb.HasTrigger("tr_project_regions_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectRegions)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__project_r__proje__14270015");

            entity.HasOne(d => d.Region).WithMany(p => p.ProjectRegions)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__project_r__regio__1332DBDC");
        });

        modelBuilder.Entity<ProjectStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__project___3213E83FC53C333E");

            entity.ToTable("project_status", tb => tb.HasTrigger("tr_project_status_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__regions__3213E83F82F59C52");

            entity.ToTable("regions", tb => tb.HasTrigger("tr_regions_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F9BAD0D5B");

            entity.ToTable("roles", tb => tb.HasTrigger("tr_roles_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<StagingLoad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("staging_load");

            entity.Property(e => e.LoadDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("load_datetime");
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tasks__3213E83F502C6CFB");

            entity.ToTable("tasks", tb => tb.HasTrigger("tr_tasks_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EstimatedTimeMins).HasColumnName("estimated_time_mins");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.StartDatetime)
                .HasColumnType("datetime")
                .HasColumnName("start_datetime");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tasks__priority___1CBC4616");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tasks__project_i__1BC821DD");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tasks__status_id__1DB06A4F");

            entity.HasOne(d => d.Type).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tasks__type_id__1EA48E88");
        });

        modelBuilder.Entity<TasksStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task_sta__3213E83F6DEBF98F");

            entity.ToTable("task_status", tb => tb.HasTrigger("tr_task_status_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TaskType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task_typ__3213E83F1F3970CE");

            entity.ToTable("task_types", tb => tb.HasTrigger("tr_task_types_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teams__3213E83FA02FC9E2");

            entity.ToTable("teams", tb => tb.HasTrigger("tr_teams_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TeamLeaderId).HasColumnName("team_leader_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.TeamLeader).WithMany(p => p.Teams)
                .HasForeignKey(d => d.TeamLeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teams_team_leader_id_fk");

            entity.HasOne(d => d.Type).WithMany(p => p.Teams)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teams_type_id_fk");
        });

        modelBuilder.Entity<TeamEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__team_emp__3213E83FC367B7DE");

            entity.ToTable("team_employees", tb => tb.HasTrigger("tr_team_employees_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.RoledEmployeeId).HasColumnName("roled_employee_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.RoledEmployee).WithMany(p => p.TeamEmployees)
                .HasForeignKey(d => d.RoledEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("team_employees_roled_employee_id_fk");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamEmployees)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("team_employees_team_id_fk");
        });

        modelBuilder.Entity<TeamType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__team_typ__3213E83FC62425AB");

            entity.ToTable("team_types", tb => tb.HasTrigger("tr_team_types_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<WorkCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__work_cat__3213E83F20175752");

            entity.ToTable("work_category", tb => tb.HasTrigger("tr_work_category_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<WorkComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__work_com__3213E83F18B73EE4");

            entity.ToTable("work_comments", tb => tb.HasTrigger("tr_work_comments_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.RoledEmployeeId).HasColumnName("roled_employee_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WorkId).HasColumnName("work_id");

            entity.HasOne(d => d.RoledEmployee).WithMany(p => p.WorkComments)
                .HasForeignKey(d => d.RoledEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__work_comm__roled__43D61337");

            entity.HasOne(d => d.Work).WithMany(p => p.WorkComments)
                .HasForeignKey(d => d.WorkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__work_comm__work___42E1EEFE");
        });

        modelBuilder.Entity<WorkResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__work_res__3213E83F15B449E7");

            entity.ToTable("work_results", tb => tb.HasTrigger("tr_work_results_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coeficient)
                .HasDefaultValueSql("((1.0))")
                .HasColumnName("coeficient");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<WorksWithTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__works_wi__3213E83F5BDC2179");

            entity.ToTable("works_with_task", tb => tb.HasTrigger("tr_works_with_task_updated_at"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignById).HasColumnName("assign_by_id");
            entity.Property(e => e.AssignToId).HasColumnName("assign_to_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DelayDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("delay_description");
            entity.Property(e => e.DelayReasonId).HasColumnName("delay_reason_id");
            entity.Property(e => e.EndDatetime)
                .HasColumnType("datetime")
                .HasColumnName("end_datetime");
            entity.Property(e => e.EstimatedTimeMinutes).HasColumnName("estimated_time_minutes");
            entity.Property(e => e.IsCompleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_completed");
            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.StartDatetime)
                .HasColumnType("datetime")
                .HasColumnName("start_datetime");
            entity.Property(e => e.TaskChanges)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("task_changes");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WorkDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("work_description");
            entity.Property(e => e.WorkedTimeMinutes).HasColumnName("worked_time_minutes");

            entity.HasOne(d => d.AssignBy).WithMany(p => p.WorksWithTaskAssignBies)
                .HasForeignKey(d => d.AssignById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__works_wit__assig__3A4CA8FD");

            entity.HasOne(d => d.AssignTo).WithMany(p => p.WorksWithTaskAssignTos)
                .HasForeignKey(d => d.AssignToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__works_wit__assig__3B40CD36");

            entity.HasOne(d => d.Category).WithMany(p => p.WorksWithTasks)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__works_wit__categ__3C34F16F");

            entity.HasOne(d => d.DelayReason).WithMany(p => p.WorksWithTasks)
                .HasForeignKey(d => d.DelayReasonId)
                .HasConstraintName("FK__works_wit__delay__3E1D39E1");

            entity.HasOne(d => d.Result).WithMany(p => p.WorksWithTasks)
                .HasForeignKey(d => d.ResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__works_wit__resul__3D2915A8");

            entity.HasOne(d => d.Task).WithMany(p => p.WorksWithTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__works_wit__task___395884C4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
