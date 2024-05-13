namespace ExportExcel.Models;

public class ReportClaimBinningEntity
{
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public string ModuleCode { get; set; }
    public string VfgCode { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public int CountNotBinned { get; set; }
    public int CountInProgress { get; set; }
    public int CountCompleted { get; set; }
}