namespace WHSAPI.ViewModels;

public class FactWorksWithTaskView
{
    public int ID { get; set; }
    
    public DimTaskView Task { get; set; } = null!;

    public DimDateView StartDate { get; set; } = null!;

    public DimDateView EndDate { get; set; } = null!;

    public DimEmployeeView Employee { get; set; } = null!;

    public int WorkedTimeMinutes { get; set; }

    public int EstimatedTimeMinutes { get; set; }

    public int DelayedTimeMinutes { get; set; }

    public decimal FinalCost { get; set; }

    public decimal EstimatedCost { get; set; }

    public string Category { get; set; } = null!;

    public string TaskChange { get; set; } = null!;

    public string WorkDescription { get; set; } = null!;

    public string? DelayReason { get; set; }

    public string WorkResult { get; set; } = null!;
}