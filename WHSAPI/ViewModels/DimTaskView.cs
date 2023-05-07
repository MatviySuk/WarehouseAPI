namespace WHSAPI.ViewModels;

public class DimTaskView
{
    public int ID { get; set; }
    
    public DimProjectView Project { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Priority { get; set; } = null!;

    public string Status { get; set; } = null!;

    public decimal PricePerHour { get; set; }
}