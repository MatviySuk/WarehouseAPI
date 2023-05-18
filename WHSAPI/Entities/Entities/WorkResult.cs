using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class WorkResult
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public double Coeficient { get; set; }

    public virtual ICollection<WorksWithTask> WorksWithTasks { get; set; } = new List<WorksWithTask>();
}
