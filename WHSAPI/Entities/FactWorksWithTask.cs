using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class FactWorksWithTask
{
    public int WorkId { get; set; }

    public int WorkKey { get; set; }

    public int TaskKey { get; set; }

    public int StartDateKey { get; set; }

    public int EndDateKey { get; set; }

    public int EmployeeKey { get; set; }

    public int WorkedTimeMinutes { get; set; }

    public int EstimatedTimeMinutes { get; set; }

    public int DelayedTimeMinutes { get; set; }

    public decimal FinalCost { get; set; }

    public decimal EstimatedCost { get; set; }

    public string Category { get; set; } = null!;

    public string TaskChange { get; set; } = null!;

    public string WorkDescription { get; set; } = null!;

    public string? DelayReason { get; set; }

    public string WorkResult { get; set; } = null!;

    public virtual DimEmployee EmployeeKeyNavigation { get; set; } = null!;

    public virtual DimDate EndDateKeyNavigation { get; set; } = null!;

    public virtual DimDate StartDateKeyNavigation { get; set; } = null!;

    public virtual DimTask TaskKeyNavigation { get; set; } = null!;
}
