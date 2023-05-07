namespace WHSAPI.ViewModels;

public class DimEmployeeView
{
    public int ID { get; set; }

    public DimRoleView Role { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;
}