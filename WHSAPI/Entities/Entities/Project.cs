using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class Project
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int IndustryId { get; set; }

    public int ProjectManagerId { get; set; }

    public int TeamId { get; set; }

    public int CategoryId { get; set; }

    public int StatusId { get; set; }

    public virtual ProjectCategory Category { get; set; } = null!;

    public virtual Industry Industry { get; set; } = null!;

    public virtual EmployeeRole ProjectManager { get; set; } = null!;

    public virtual ICollection<ProjectPlatform> ProjectPlatforms { get; set; } = new List<ProjectPlatform>();

    public virtual ICollection<ProjectRegion> ProjectRegions { get; set; } = new List<ProjectRegion>();

    public virtual ProjectStatus Status { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();

    public virtual Team Team { get; set; } = null!;
}
