using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class DimProject
{
    public int ProjectId { get; set; }

    public int ProjectKey { get; set; }

    public int ProjectManagerKey { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Industry { get; set; } = null!;

    public string Platforms { get; set; } = null!;

    public string Regions { get; set; } = null!;

    public virtual ICollection<DimTask> DimTasks { get; set; } = new List<DimTask>();

    public virtual DimEmployee ProjectManagerKeyNavigation { get; set; } = null!;
}
