namespace ExportExcel.Models;

public class ConditionCodeEntity
{
    public long Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Description2 { get; set; } = string.Empty;
    public string Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public Guid? CreatedBy { get; set; }
    public string? CreatedName { get; set; }
    public DateTimeOffset ModifiedTime { get; set; }
    public Guid? ModifiedBy { get; set; }
    public string? ModifiedName { get; set; }
    public bool Deleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public string? DeletedName { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
}