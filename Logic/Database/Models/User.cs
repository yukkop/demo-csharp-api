using Logic.Model.Dto.VpnUser;
using Microsoft.AspNetCore.Identity;

namespace Logic.Database.Models;

public class User : IdentityUser<Guid>, IBase
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    /// <summary>
    /// Can be just single
    /// </summary>
    public List<VpnUser>? VpnUsers { get; set; } = new();
    public VpnUser VpnUser => VpnUsers?.SingleOrDefault();
    public List<UserPayment>? PaymentHistory { get; set; }
}