namespace Logic.Model.Dto;

public class DirectTelegramNotifyRequestModel
{
    public List<long>? telegramIds { get; set; }
    public string? message { get; set; }
}