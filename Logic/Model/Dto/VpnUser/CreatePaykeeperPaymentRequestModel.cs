namespace Logic.Model.Dto.VpnUser;

public class CreatePaykeeperPaymentRequestModel
{
    public Guid TariffId { get; set; }
    public string? ReturnUrl { get; set; }
    public Guid VpnUserId { get; set; }
}