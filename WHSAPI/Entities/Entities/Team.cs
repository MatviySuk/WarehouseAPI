using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class Team
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public int TeamLeaderId { get; set; }

    public int TypeId { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<TeamEmployee> TeamEmployees { get; set; } = new List<TeamEmployee>();

    public virtual EmployeeRole TeamLeader { get; set; } = null!;

    public virtual TeamType Type { get; set; } = null!;
}
