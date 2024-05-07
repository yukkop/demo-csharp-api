namespace Logic.Database.Models;

public class Tariff: Base
{
    public decimal Price { get; set; }
    public int MaxUserCount { get; set; }
    public int MinUserCount { get; set; }
    public int Period { get; set; }
    public Guid PeriodUnitId { get; set; }
    public PeriodUnit PeriodUnit { get; set; }
}