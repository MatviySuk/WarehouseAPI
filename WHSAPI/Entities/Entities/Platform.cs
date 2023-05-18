using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class Platform
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProjectPlatform> ProjectPlatforms { get; set; } = new List<ProjectPlatform>();
}
