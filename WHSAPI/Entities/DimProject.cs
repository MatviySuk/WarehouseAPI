using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class DimProject
{
    public int ProjectId { get; set; }

    public int ProjectKey { get; set; }

    public int ProjectManagerKey { get; set; }

    public int IndustryKey { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual ICollection<FactWorksWithTask> FactWorksWithTasks { get; set; } = new List<FactWorksWithTask>();

    public virtual DimIndustry IndustryKeyNavigation { get; set; } = null!;

    public virtual DimEmployee ProjectManagerKeyNavigation { get; set; } = null!;
}
