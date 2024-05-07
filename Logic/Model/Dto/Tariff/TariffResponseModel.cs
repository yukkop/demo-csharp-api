namespace logic.Model.Dto.Tariff;

public class TariffResponseModel
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int MaxUserCount { get; set; }
    public int MinUserCount { get; set; }
    public int Period { get; set; }
    public PeriodUnitResponseModel PeriodUnit { get; set; }
}