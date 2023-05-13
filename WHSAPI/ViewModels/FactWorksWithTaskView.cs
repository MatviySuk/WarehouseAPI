namespace WHSAPI.ViewModels;

public class FactWorksWithTaskView
{
    public int ID { get; set; }
    
    public DimProjectView Project { get; set; } = null!;

    public DimDateView StartDate { get; set; } = null!;

    public DimDateView EndDate { get; set; } = null!;

    public DimEmployeeView Employee { get; set; } = null!;

    public int WorkedTimeMinutes { get; set; }

    public int EstimatedTimeMinutes { get; set; }

    public int DelayedTimeMinutes { get; set; }

    public int TotalWorksCount { get; set; }

    public int SuccessfulWorksCount { get; set; }

    public int DelayedWorksCount { get; set; }

    public int FailedWorksCount { get; set; }
}