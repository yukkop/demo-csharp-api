namespace Logic.Database.Models;

public class VpnUsersCertificates: Base
{
  public VpnUsersCertificates() { }
  public Guid? CertificateId { get; set; }
  public Certificate? Certificate { get; set; }
  public Guid? VpnUserId { get; set; }
  public VpnUser? VpnUser { get; set; }
}