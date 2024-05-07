namespace Logic.Database.Models;

public class PeriodUnit: Base
{
    public string Unit { get; set; }
    public List<Tariff> Tariffs { get; set; }
}
