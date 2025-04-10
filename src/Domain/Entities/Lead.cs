namespace Domain.Entities;

public class Lead
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Channel { get; set; } = string.Empty;
    public string Product { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Urgency { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime? FirstContact { get; set; }
    public string Response { get; set; } = string.Empty;
    public DateTime? Followup { get; set; }
    public string PurchaseProduct { get; set; } = string.Empty;
    public string Payment { get; set; } = string.Empty;
    public string PurchaseReason { get; set; } = string.Empty;
    public string FuturePurchase { get; set; } = string.Empty;
    public string Feedback { get; set; } = string.Empty;
    public string NoPurchaseReason { get; set; } = string.Empty;
    public string FollowupFuture { get; set; } = string.Empty;
    public string Messages { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}