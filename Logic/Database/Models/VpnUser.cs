namespace Logic.Database.Models;

public class VpnUser : Base
{
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    
    public long TelegramId { get; set; }
    
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public int Balance { get; set; } = 0;
    // TODO rename to LastBalanceDecreaseAt 
    public DateTime DateOfLastBalanceDecrease { get; set; }

    public bool FreePeriodUsed { get; set; } = false;
    
    public Guid? RegionId { get; set; }
    public Region? Region { get; set; }
    
    public Guid? CertificateId { get; set; }
    public Certificate? Certificate { get; set; }
    public List<VpnUsersCertificates>? CertificateHistory { get; set; }
    [Obsolete("Use VpnUser.User.PaymentHistory")]
    public List<VpnUsersPayments>? PaymentHistory { get; set; }
    public List<EmployeeAccess> EmployeeAccesses { get; set; }
}