using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class DimIndustry
{
    public int IndustryId { get; set; }

    public int IndustryKey { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DimProject> DimProjects { get; set; } = new List<DimProject>();
}
