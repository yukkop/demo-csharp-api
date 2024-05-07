namespace Logic.Model.Dto.VpnUser;

public class AddVpnUserRequestModel
{
    public long TelegramId { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}