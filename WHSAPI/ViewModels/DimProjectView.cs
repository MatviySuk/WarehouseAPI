namespace WHSAPI.ViewModels;

public class DimProjectView
{
    public int ID { get; set; }

    public DimEmployeeView ProjectManager { get; set; }

    public DimIndustryView Industry { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;
}