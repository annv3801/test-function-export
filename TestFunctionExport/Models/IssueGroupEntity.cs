// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverUpdated.Global

namespace ExportExcel.Models;

/// <summary>
/// Manage Issue
/// </summary>
public class IssueGroupEntity
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public List<Jira> Jiras { get; set; } = new();
    public string Status { get; set; } = string.Empty;
    public string BinId { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
    public string Function { get; set; } = string.Empty;
    public string CtcCode { get; set; } = string.Empty;
    public string Concern { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string IssueTitle { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public DateTimeOffset CreatedTime { get; set; }
    public int IssueCount { get; set; } = 0;

    public Guid? CreatedBy { get; set; }
    public string? CreatedName { get; set; }
    public DateTimeOffset ModifiedTime { get; set; }
    public Guid? ModifiedBy { get; set; }
    public string? ModifiedName { get; set; }

    public ICollection<IssueEntity> Issues { get; set; } = new List<IssueEntity>();
    public uint ConcurrencyStamp { get; set; }
}

public class Jira
{
    public string? JiraTicket { get; set; }
    public string? JiraLink { get; set; }
    public DateTimeOffset? LastIca { get; set; }
    public DateTimeOffset? LastPca { get; set; }

    // public List<IcaAndPca>? PreviousIcaAndPca { get; set; }
}

public class IcaAndPca
{
    public DateTimeOffset? LastIca { get; set; }
    public DateTimeOffset? LastPca { get; set; }
}