namespace WHSAPI.ViewModels;

public class OLTPMetadata
{
    public string DbName { get; set; } = "";
    public bool IsConnected { get; set; } = true;
    public Dictionary<string, int> TablesInfo { get; set; } = new Dictionary<string, int>();
}
