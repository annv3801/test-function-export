namespace ExportExcel.Models;

public class SyncLogHistoriesEntity
{
    public long Id { get; set; }
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public long SyncedRecord { get; set; }
    public long Fail { get; set; }
    public long Success { get; set; }
    public long Error { get; set; }
    public long Duplicate { get; set; }
    public DateTimeOffset Parameter { get; set; }
    public DateTimeOffset LastSynchronized { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Message { get; set; }
    public double? ExecutionTime { get; set; }
}

public class DmsSyncLogHistoriesEntity : SyncLogHistoriesEntity
{
    
}

public class MesSyncLogHistoriesEntity : SyncLogHistoriesEntity
{
    public int CountInsertVin { get; set; }
    public int CountUpdateVin { get; set; }
}

public class SfSyncLogHistoriesEntity : SyncLogHistoriesEntity
{
    
}