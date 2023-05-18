using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class ProjectRegion
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int RegionId { get; set; }

    public int ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Region Region { get; set; } = null!;
}
