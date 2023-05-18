using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class EmployeeRole
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int EmployeeId { get; set; }

    public int RoleId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<TeamEmployee> TeamEmployees { get; set; } = new List<TeamEmployee>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<WorkComment> WorkComments { get; set; } = new List<WorkComment>();

    public virtual ICollection<WorksWithTask> WorksWithTaskAssignBies { get; set; } = new List<WorksWithTask>();

    public virtual ICollection<WorksWithTask> WorksWithTaskAssignTos { get; set; } = new List<WorksWithTask>();
}
