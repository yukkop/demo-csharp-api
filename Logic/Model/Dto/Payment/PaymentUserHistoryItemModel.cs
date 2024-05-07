namespace Logic.Model.Dto.Payment;

public class PaymentUserHistoryItemModel
{
    public Guid Id { get; set; }
    public float Value { get; set; }
    public float IncomeValue { get; set; }
    public float RefundedValue { get; set; }
    public string? Currency { get; set; }
    public DateTime? CapturedAt { get; set; }
    public bool Test { get; set; }
    public string PaymentSystem { get; set; }
}