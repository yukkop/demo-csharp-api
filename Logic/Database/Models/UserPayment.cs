namespace Logic.Database.Models;

public class UserPayment: Base
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; }
    
    public Guid TariffId { get; set; }
    public Tariff Tariff { get; set; }
}