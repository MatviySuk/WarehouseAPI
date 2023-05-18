using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class TeamEmployee
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int RoledEmployeeId { get; set; }

    public int TeamId { get; set; }

    public virtual EmployeeRole RoledEmployee { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
