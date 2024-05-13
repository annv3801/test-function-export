namespace ExportExcel.Models;

public class TroubleCodeResponse
{
    public string Value { get; set; }
    public int Level { get; set; }
    public string Path { get; set; }
    public string? Description { get; set; }
}