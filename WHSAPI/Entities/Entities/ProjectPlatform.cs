using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class ProjectPlatform
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int PlatformId { get; set; }

    public int ProjectId { get; set; }

    public virtual Platform Platform { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
