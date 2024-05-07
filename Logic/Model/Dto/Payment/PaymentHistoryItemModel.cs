using System.ComponentModel.DataAnnotations;
using Logic.Model.Dto.VpnUser;

namespace Logic.Model.Dto.Payment;

public class PaymentHistoryItemModel
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public VpnUserShortResponseModel? VpnUser { get; set; }
    [Required]
    public float Value { get; set; }
    [Required]
    public bool Paid { get; set; }
    [Required]
    public float IncomeValue { get; set; }
    [Required]
    public float RefundedValue { get; set; }
    [Required]
    public string? Currency { get; set; }
    [Required]
    public DateTime? CapturedAt { get; set; }
    [Required]
    public bool Test { get; set; }
    [Required]
    public string PaymentSystem { get; set; }
}