namespace ExportExcel.Models;

public class ListS3ObjectsEntity
{
    public long Id { get; set; }
    public string FileName { get; set; }
    public string Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public string CreatedName { get; set; }
}