using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class WorkComment
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int WorkId { get; set; }

    public int RoledEmployeeId { get; set; }

    public virtual EmployeeRole RoledEmployee { get; set; } = null!;

    public virtual WorksWithTask Work { get; set; } = null!;
}
