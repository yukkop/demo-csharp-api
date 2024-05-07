namespace Logic.Database.Models;

// TODO отойти от этого в пользу UserPayment
public class VpnUsersPayments: Base
{
  public VpnUsersPayments() { }
  public Guid? PaymentId { get; set; }
  public Payment? Payment { get; set; }
  public Guid? VpnUserId { get; set; }
  public VpnUser? VpnUser { get; set; }
  public int ValueToBalance { get; set; }
}