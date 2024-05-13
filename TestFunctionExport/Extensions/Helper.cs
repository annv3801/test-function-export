using ExportExcel.Dtos;

namespace ExportExcel.Extensions;

public static class Helper
{
     public static string GetStatusByReport(List<MonthRolling> data, DateTimeOffset? lastIca, DateTimeOffset? lastPca)
    {
        const string greenStatus = "G";
        const string yellowStatus = "Y";
        const string redStatus = "R";
        const string redRedStatus = "RR";
        
        var result = string.Empty;

        // RR: Reoccurrence defect after applied PCA
        // R: No ICA/PCA or reoccurrence after applied ICA
        // Y: ICA already determined; No re-occurrence after applied ICA; PCA not yer defined 
        // G: ICA and PCA already determined, no re-occurrence defect
        if (lastIca == null && lastPca == null)
            result = redStatus;
        if (lastIca != null && lastPca == null)
        {
            var currentYearMonthIca = lastIca.Value.Year * 100 + lastIca.Value.Month;
            result = yellowStatus;
            if (data.Any(x =>
                {
                    var yearMonth = x.Year * 100 + x.Month;
                    return (yearMonth > currentYearMonthIca && x.TotalBinnedClaim > 0) || (x.LatestProductionDate != null && yearMonth == currentYearMonthIca && x.LatestProductionDate.Value > lastIca);
                }))
            {
                result = redStatus;
            }
        }

        if (lastIca != null && lastPca != null)
        {
            result = greenStatus;
            var currentYearMonthPca = lastPca.Value.Year * 100 + lastPca.Value.Month;
            if (data.Any(x =>
                {
                    var yearMonth = x.Year * 100 + x.Month;
                    return (yearMonth > currentYearMonthPca && x.TotalBinnedClaim > 0) || (x.LatestProductionDate != null && yearMonth == currentYearMonthPca && x.LatestProductionDate.Value > lastPca);
                }))
                result = redRedStatus;
        }

        return result;
    }
     

    public static void HighlightMonths(List<MonthRolling> twelveMonthRollings, List<DateTimeOffset?> icas, DateTimeOffset? lastIca, DateTimeOffset? lastPca)
    {
        const string greenColor = "Green";
        const string yellowColor = "Yellow";
        const string purpleColor = "Purple";
        const string blueColor = "Blue";

        foreach (var ica in icas)
        {
            AssignHighlightColor(twelveMonthRollings, ica, yellowColor);
        }

        AssignHighlightColor(twelveMonthRollings, lastPca, greenColor);

        if (lastIca.HasValue && lastPca.HasValue)
        {
            if (lastIca.Value.Year == lastPca.Value.Year && lastIca.Value.Month == lastPca.Value.Month)
            {
                if (lastIca.Value.Day == lastPca.Value.Day)
                    AssignHighlightColor(twelveMonthRollings, lastIca, purpleColor); // same day
                else
                    AssignHighlightColor(twelveMonthRollings, lastIca, blueColor); // different day
            }
        }
    }

    private static void AssignHighlightColor(List<MonthRolling> monthRollings, DateTimeOffset? dateTime, string color)
    {
        if (!dateTime.HasValue) return;
        var monthRolling = monthRollings.FirstOrDefault(x => x.Year == dateTime.Value.Year && x.Month == dateTime.Value.Month);
        if (monthRolling != null)
        {
            monthRolling.HighlightColor = color;
        }
    }
}