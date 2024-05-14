namespace TestFunctionExport.Models;

public class CccCodeComparisonEntity
{
    public long Id { get; set; }
    public long? VrtCodeIdOld { get; set; }
    public string? VrtCodeValueOld { get; set; }
    public string? VrtCodeDescriptionOld { get; set; }
    public long? VfgCodeIdOld { get; set; }
    public string? VfgCodeValueOld { get; set; }
    public string? VfgCodeDescriptionOld { get; set; }
    public long? CtcCodeIdOld { get; set; }
    public string? CtcCodeValueOld { get; set; }
    public string? CtcCodeDescriptionOld { get; set; }
    public long? VrtCodeIdNew { get; set; }
    public string? VrtCodeValueNew { get; set; }
    public string? VrtCodeDescriptionNew { get; set; }
    public long? VfgCodeIdNew { get; set; }
    public string? VfgCodeValueNew { get; set; }
    public string? VfgCodeDescriptionNew { get; set; }
    public long? CtcCodeIdNew { get; set; }
    public string? CtcCodeValueNew { get; set; }
    public string? CtcCodeDescriptionNew { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public string Type { get; set; }
    public string Level { get; set; }
}