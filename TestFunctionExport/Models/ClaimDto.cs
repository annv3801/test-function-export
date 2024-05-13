namespace ExportExcel.Models;

public class ClaimDto
{
    public long Id { get; set; }
    public string? SourceIssueId { get; set; }
    public string Status { get; set; } = "NOT_BINNED_YET";
    public string Type { get; set; } = string.Empty;
    public string? CustomerIssueDescription { get; set; } = string.Empty;
    public string? TechnicianIssueDescription { get; set; } = string.Empty;
    public string? Vin { get; set; } = string.Empty;
    public string? Model { get; set; } = string.Empty;
    public string? PartName { get; set; } = string.Empty;
    public string? PartNumber { get; set; } = string.Empty;
    public string? ModuleCode { get; set; } = string.Empty;
    public string? ModuleDescriptionEnglish { get; set; } = string.Empty;
    public string? ModuleDescriptionVietnamese { get; set; } = string.Empty;
    public string? VfgCode { get; set; } = string.Empty;
    public string? VfgDescriptionEnglish { get; set; } = string.Empty;
    public string? VfgDescriptionVietnamese { get; set; } = string.Empty;
    public string? CtcCode { get; set; } = string.Empty;
    public string? CtcCodeDescriptionEnglish { get; set; } = string.Empty;
    public string? CtcCodeDescriptionVietnamese { get; set; } = string.Empty;
    public string? ConditionCode { get; set; } = string.Empty;
    public string? ConditionDescriptionEnglish { get; set; } = string.Empty;
    public string? ConditionDescriptionVietnamese { get; set; } = string.Empty;
    public DateTimeOffset? WarantyDate { get; set; } 
    public DateTimeOffset? RepairDate { get; set; }
    public string? Variant { get; set; } = string.Empty;
    public string? Market { get; set; } = string.Empty;
    public string? CaseOwner { get; set; } = string.Empty;
    public string? CaseOwnerAccount { get; set; } = string.Empty;
    public string? ServiceAdvisor { get; set; } = string.Empty;
    public string? ModelYear { get; set; } = string.Empty;
    public string? CausalVerbatim { get; set; } = string.Empty;
    public string? Showroom { get; set; } = string.Empty;
    public ConcernPhoto ConcernPhoto { get; set; } = new();
    public BinningInformation BinningInformation { get; set; } = new();
    public string? CreateByMesOrDms { get; set; }
    public DateTimeOffset? ClaimCreatedTime { get; set; }
    public DateTimeOffset? CustomerComplainDate { get; set; }
    public string? BuildPlant { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    public DateTimeOffset? BuildDate { get; set; }
    public DateTimeOffset? IssueOccurrenceDate { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public Guid? CreatedBy { get; set; }
    public string? CreatedName { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
    public Guid? ModifiedBy { get; set; }
    public string? ModifiedName { get; set; }
    public bool Deleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public string? DeletedByName { get; set; }
    public DateTimeOffset? DeletedTime { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public int? Group { get; set; }
    public DateTimeOffset? CrawlDataDate { get; set; }
}

public class ConcernPhoto
{
    public List<string> Photos { get; set; } = new();
}

public class BinningInformation
{
    public string? Model { get; set; }
    public string? ModuleCode { get; set; }
    public string? VfgCode { get; set; }
    public string? CtcCode { get; set; }
    public string? CtcCodeDescription { get; set; }
    public string? ConditionCode { get; set; }
    public string? ConcernDescription { get; set; }
    public Top20CtcCodeResponse Top20CtcCode { get; set; } = new();
    public string? PartName { get; set; }
    public string? Type { get; set; }
    public string? PositionLr { get; set; }
    public string? PositionFr { get; set; }
    public string? Severity { get; set; }
    public string? PositionWhich { get; set; }
    public string? PositionWhere { get; set; }
    public string? Variant { get; set; }
    public string? Market { get; set; }
    public string? ModelYear { get; set; }
    public string? Factory { get; set; }
    public DateTimeOffset? ProductionDate { get; set; }
    public int? Mfg { get; set; }
    public int? Sqe { get; set; }
    public int? Engineering { get; set; }
    public List<File>? Files { get; set; } = new();
    public string? Comments { get; set; }
}

public class File
{
    public string Name { get; set; }
    public string UploadedBy { get; set; }
    public DateTimeOffset UploadedDate { get; set; } 
}

