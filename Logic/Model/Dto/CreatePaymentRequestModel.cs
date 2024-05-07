namespace Logic.Model.Dto.VpnUser;

public class CreatePaymentRequestModel
{
    public int Value { get; set; }
    public string? ReturnUrl { get; set; }
    public Guid VpnUserId { get; set; }
    public int ValueToBalance { get; set; }
}