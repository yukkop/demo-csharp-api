namespace logic.Model.Dto.Tariff;

public class AddTariffRequestModel
{
    public decimal Price { get; set; }
    public int MaxUserCount { get; set; }
    public int MinUserCount { get; set; }
    public int Period { get; set; }
    public Guid PeriodUnitId { get; set; }
}