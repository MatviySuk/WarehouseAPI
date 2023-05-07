using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class DimEmployee
{
    public int EmployeeId { get; set; }

    public int EmployeeKey { get; set; }

    public int RoleKey { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<DimProject> DimProjects { get; set; } = new List<DimProject>();

    public virtual ICollection<FactWorksWithTask> FactWorksWithTasks { get; set; } = new List<FactWorksWithTask>();

    public virtual DimRole RoleKeyNavigation { get; set; } = null!;
}
