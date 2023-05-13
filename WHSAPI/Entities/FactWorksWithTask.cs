using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class FactWorksWithTask
{
    public int WorksKey { get; set; }

    public int ProjectKey { get; set; }

    public int StartDateKey { get; set; }

    public int EndDateKey { get; set; }

    public int EmployeeKey { get; set; }

    public int WorkedTimeMinutes { get; set; }

    public int EstimatedTimeMinutes { get; set; }

    public int DelayedTimeMinutes { get; set; }

    public int TotalWorksCount { get; set; }

    public int SuccessfulWorksCount { get; set; }

    public int DelayedWorksCount { get; set; }

    public int FailedWorksCount { get; set; }

    public virtual DimEmployee EmployeeKeyNavigation { get; set; } = null!;

    public virtual DimDate EndDateKeyNavigation { get; set; } = null!;

    public virtual DimProject ProjectKeyNavigation { get; set; } = null!;

    public virtual DimDate StartDateKeyNavigation { get; set; } = null!;
}
