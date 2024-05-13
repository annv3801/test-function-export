// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverUpdated.Global

namespace ExportExcel.Models;

/// <summary>
/// Manage Claim
/// </summary>
public class ClaimEntity
{
    public long Id { get; set; }
    public string Status { get; set; } = "NOT_BINNED_YET";
    public string Type { get; set; } = string.Empty;

    // Field binning
    public string? SourceIssueId { get; set; }
    public string? CustomerIssueDescription { get; set; } = string.Empty;
    public string? TechnicianIssueDescription { get; set; } = string.Empty;
    public string? Showroom { get; set; } = string.Empty;
    public string? PartName { get; set; } = string.Empty;
    public string? PartNumber { get; set; } = string.Empty;
    public string? Model { get; set; } = string.Empty;
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
    public DateTimeOffset? IssueOccurrenceDate { get; set; }
    public DateTimeOffset? CustomerComplainDate { get; set; }
    public string? Vin { get; set; } = string.Empty;
    public DateTimeOffset? BuildDate { get; set; }
    public string? Variant { get; set; } = string.Empty;
    public string? Market { get; set; } = string.Empty;
    public string? CaseOwner { get; set; } = string.Empty;
    public string? CaseOwnerAccount { get; set; } = string.Empty;
    public string? CreateByMesOrDms { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public string? ServiceAdvisor { get; set; } = string.Empty;
    public string? TechnicalAdvisor { get; set; }
    public string? PersonInCharge { get; set; }
    public string? ModelYear { get; set; } = string.Empty;
    public string? BuildPlant { get; set; }
    public string? PartsWarrantyClaimAmount { get; set; } 
    public string? WorkWarrantyClaimAmount { get; set; } 
    public string? FinalManHourQuan { get; set; } 
    public string? TotalWarrantyClaimAmount { get; set; }
    public string? InteriorColor { get; set; }
    public string? ExteriorColor { get; set; }
    public string? Wo { get; set; }
    public string? CausalVerbatim { get; set; } = string.Empty;
    public string? IssueVerification { get; set; }
    public string? Bu { get; set; }
    public string? Country { get; set; }
    public string? RepairingDealerCountry { get; set; }
    public string? TireSize { get; set; }
    public string? BuildCountry { get; set; }
    public ConcernPhoto? ConcernPhoto { get; set; } = new();
    public BinningInformation? BinningInformation { get; set; } = new();
    public DateTimeOffset? ClaimCreatedTime { get; set; }
    public DateTimeOffset? CreatedTime { get; set; }
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
    public string? WarrantyClaimDetailId { get; set; }
    public string? ProductId { get; set; }
    public string? Dtr { get; set; }
    public string? IdUnique { get; set; }
    public DateTimeOffset? WarrantySubmitDate { get; set; }
    public IssueEntity? Issue { get; set; } 
}
