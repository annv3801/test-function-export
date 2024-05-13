namespace ExportExcel.Models;

public class Top20CtcCodeResponse
{
    public List<TroubleCodeResponse> Module { get; set; } = new();
    public List<TroubleCodeResponse> Function { get; set; } = new();
    public List<TroubleCodeResponse> CtcCode { get; set; } = new();
    public List<MasterDataResponse> Concern { get; set; } = new();
}