using System;
using System.Collections.Generic;

namespace WHSAPI.Entities;

public partial class DimDate
{
    public int DateKey { get; set; }

    public int Year { get; set; }

    public short Month { get; set; }

    public short Day { get; set; }

    public virtual ICollection<FactWorksWithTask> FactWorksWithTaskEndDateKeyNavigations { get; set; } = new List<FactWorksWithTask>();

    public virtual ICollection<FactWorksWithTask> FactWorksWithTaskStartDateKeyNavigations { get; set; } = new List<FactWorksWithTask>();
}
