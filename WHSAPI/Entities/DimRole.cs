using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class DimRole
{
    public int RoleId { get; set; }

    public int RoleKey { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DimEmployee> DimEmployees { get; set; } = new List<DimEmployee>();
}
