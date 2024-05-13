namespace ExportExcel.Dtos;

public class BinningClaimReportResponse
{
    public List<DetailReport> DetailReports { get; set; }
    public int BinnedClaimOfAllSystem { get; set; }
    public int InProgressClaimOfAllSystem { get; set; }
    public int NotBinnedYetClaimOfAllSystem  { get; set; }
    public int TotalClaimOfAllSystem  { get; set; }
    public double PercentageOfAllSystem { get; set; }
}

public class DetailReport
{
    public string System { get; set; }
    public int BinnedClaim { get; set; }
    public int InProgressClaim { get; set; }
    public int NotBinnedYetClaim { get; set; }
    public int TotalClaim { get; set; }
    public double PercentageOfSystem { get; set; }
    public double PercentageOfAll { get; set; }
}