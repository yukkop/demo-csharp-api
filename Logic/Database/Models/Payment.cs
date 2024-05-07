namespace Logic.Database.Models;

public class Payment: Base
{
    public string PaymentId { get; set; }
    // order id from paykeeper or identifier from yookassa
    public Guid IdempotenceKey { get; set; }
    public float Value { get; set; }
    public float IncomeValue { get; set; }
    public float RefundedValue { get; set; }
    public string Currency { get; set; }
    public bool Paid { get; set; }
    public DateTime? CapturedAt { get; set; }
    public string ConfirmationUrl { get; set; }
    public string ReturnUrl { get; set; }
    public bool Test { get; set; }
    public bool Refundable { get; set; }
    public string Integration { get; set; }
    
    public List<UserPayment> UserPayments { get; set; } = new();
}