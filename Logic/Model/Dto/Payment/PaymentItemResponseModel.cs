namespace Logic.Model.Dto.Payment;
public class PaymentItemResponseModel 
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? PaymentId { get; set; }
    public string? IdempotenceKey { get; set; }
    public float Value { get; set; }
    public float IncomeValue { get; set; }
    public float RefundedValue { get; set; }
    public string? Currency { get; set; }
    public bool Paid { get; set; }
    public DateTime? CapturedAt { get; set; }
    public string? ConfirmationUrl { get; set; }
    public string? ReturnUrl { get; set; }
    public bool Test { get; set; }
    public string PaymentSystem { get; set; } = "Yookassa"; // TODO enum
}