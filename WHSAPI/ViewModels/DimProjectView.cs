namespace WHSAPI.ViewModels;

public class DimProjectView
{
    public int ID { get; set; }

    public DimEmployeeView ProjectManager { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Industry { get; set; } = null!;

    public string Platforms { get; set; } = null!;

    public string Regions { get; set; } = null!;
}