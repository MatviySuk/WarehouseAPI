using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class WorksWithTask
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime StartDatetime { get; set; }

    public DateTime? EndDatetime { get; set; }

    public int EstimatedTimeMinutes { get; set; }

    public int WorkedTimeMinutes { get; set; }

    public string? DelayDescription { get; set; }

    public bool? IsCompleted { get; set; }

    public string TaskChanges { get; set; } = null!;

    public string WorkDescription { get; set; } = null!;

    public int TaskId { get; set; }

    public int AssignById { get; set; }

    public int AssignToId { get; set; }

    public int CategoryId { get; set; }

    public int ResultId { get; set; }

    public int? DelayReasonId { get; set; }

    public virtual EmployeeRole AssignBy { get; set; } = null!;

    public virtual EmployeeRole AssignTo { get; set; } = null!;

    public virtual WorkCategory Category { get; set; } = null!;

    public virtual DelayReason? DelayReason { get; set; }

    public virtual WorkResult Result { get; set; } = null!;

    public virtual Tasks Task { get; set; } = null!;

    public virtual ICollection<WorkComment> WorkComments { get; set; } = new List<WorkComment>();
}
