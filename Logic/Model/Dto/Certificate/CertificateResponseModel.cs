using Logic.Model.Dto.Server;

namespace Logic.Model.Dto.Certificate;
public class CertificateResponseModel
{
  public Guid Id { get; set; }
  public string? PublicKey { get; set; }
  public ServerResponseModel? Server { get; set; }
}