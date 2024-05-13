using ExportExcel.Models;

namespace ExportExcel.Dtos;

public class ReportCtcCodeResponse
{
    public int Priority { get; set; }
    public double Pscore { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
    public string Function { get; set; } = string.Empty;
    public string CtcCode { get; set; } = string.Empty;
    public string Concern { get; set; } = string.Empty;
    public string IssueTitle { get; set; } = string.Empty;
    public string GroupedBinId { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public List<Jira> Jiras { get; set; } = new();
    public string Status { get; set; } = string.Empty;
    public List<MonthRolling> MonthRollings { get; set; } = new();
    public DateTimeOffset? LastIca { get; set; }
    public DateTimeOffset? LastPca { get; set; }
    public int TotalLastFourMonthOfProduction { get; set; }
    public int TotalWarrantyLastFourMonthOfProduction { get; set; }
    public int TotalWarrantyRolling { get; set; }
    public int TotalVocLastFourMonthOfProduction { get; set; }
    public int TotalVocRolling { get; set; }
    public int TotalAtPlantLastFourMonthOfProduction { get; set; }
    public int TotalAtPlantRolling { get; set; }
    public int TotalIssueByRolling { get; set; }
    public List<TotalOfSourceByYear> TotalOfSourceByYears { get; set; } = new();

}

public class MonthRolling
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int? TotalBinnedClaim { get; set; }
    public int? TotalBinnedClaimByWarranty { get; set; }
    public int? TotalBinnedClaimByVoc { get; set; }
    public int? TotalBinnedClaimByAtPlant { get; set; }
    public string? HighlightColor { get; set; }
    public DateTimeOffset? LatestProductionDate { get; set; }
}

public class TotalOfSourceByYear
{
    public int Year { get; set; }
    public int Voc { get; set; }
    public int Warranty { get; set; }
    public int AtPlant { get; set; }
    public int TotalAll { get; set; }
}

