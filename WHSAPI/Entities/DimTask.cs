using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class DimTask
{
    public int TaskId { get; set; }

    public int TaskKey { get; set; }

    public int ProjectKey { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Priority { get; set; } = null!;

    public string Status { get; set; } = null!;

    public decimal PricePerHour { get; set; }

    public virtual ICollection<FactWorksWithTask> FactWorksWithTasks { get; set; } = new List<FactWorksWithTask>();

    public virtual DimProject ProjectKeyNavigation { get; set; } = null!;
}
