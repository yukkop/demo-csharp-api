namespace logic.Model.Dto;

public class CreateYookassaPaymentRequestModel
{
    public Guid TariffId { get; set; }
    public string? ReturnUrl { get; set; }
    public Guid VpnUserId { get; set; }
}