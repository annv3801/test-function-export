namespace ExportExcel.Dtos;

public class SyncLogHistoryResponse
{
    public long Id { get; set; }
    public long SyncedRecord { get; set; }
    public long Fail { get; set; }
    public long Success { get; set; }
    public DateTimeOffset Parameter { get; set; }
    public DateTimeOffset LastSynchronized { get; set; }
    public string Status { get; set; } = string.Empty;
}