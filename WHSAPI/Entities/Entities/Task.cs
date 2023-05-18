using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class Tasks
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDatetime { get; set; }

    public int EstimatedTimeMins { get; set; }

    public int ProjectId { get; set; }

    public int PriorityId { get; set; }

    public int StatusId { get; set; }

    public int TypeId { get; set; }

    public virtual Priority Priority { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual TasksStatus Status { get; set; } = null!;

    public virtual TaskType Type { get; set; } = null!;

    public virtual ICollection<WorksWithTask> WorksWithTasks { get; set; } = new List<WorksWithTask>();
}
