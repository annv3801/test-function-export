// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverUpdated.Global

namespace ExportExcel.Models;

/// <summary>
/// Manage Issue
/// </summary>
public class IssueEntity
{
    public long Id { get; set; }
    public string BinId { get; set; }
    public string? PartName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? PositionLr { get; set; } = string.Empty;
    public string? PositionFr { get; set; } = string.Empty;
    public string? PositionWhich { get; set; } = string.Empty;
    public string? PositionWhere { get; set; } = string.Empty;
    public string? Variant { get; set; } = string.Empty;
    public string? Market { get; set; } = string.Empty;
    public string? ModelYear { get; set; } = string.Empty;
    public string? Factory { get; set; } = string.Empty;
    public DateTimeOffset? ProductionDate { get; set; }
    public int? Mfg { get; set; }
    public int? Sqe { get; set; }
    public int? Engineering { get; set; }
    public List<File> Files { get; set; } = new();
    public string IssueTitle { get; set; } = string.Empty;
    public string CtcCodeDescription { get; set; } = string.Empty;
    public string ConcernDescription { get; set; } = string.Empty;

    public DateTimeOffset CreatedTime { get; set; }
    public Guid? CreatedBy { get; set; }
    public string? CreatedName { get; set; }
    public DateTimeOffset ModifiedTime { get; set; }
    public Guid? ModifiedBy { get; set; }
    public string? ModifiedName { get; set; }

    public long ClaimId { get; set; }
    public ClaimEntity? Claim { get; set; }

    public long IssueGroupId { get; set; }
    public IssueGroupEntity? IssueGroup { get; set; }
    public uint ConcurrencyStamp { get; set; }
}

